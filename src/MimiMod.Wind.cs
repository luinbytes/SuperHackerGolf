using System;
using System.Reflection;
using System.Text;
using MelonLoader;
using UnityEngine;

public partial class MimiMod
{
    // ── Wind compensation (D2 graft, E2 rewrite) ───────────────────────────────
    //
    // Full audit of the game's wind API from GameAssembly.dll strings. What we
    // know for sure about Super Battle Golf's WindManager (class name "WindManager"):
    //
    //   Source of truth (Mirror SyncVars):
    //     get_NetworkcurrentWindAngle    → float (degrees, 0 = north?)
    //     get_NetworkcurrentWindSpeed    → float (m/s or game units)
    //
    //   Exposed helpers (what most callers read):
    //     get_CurrentWindDirection       → Vector3 (unit vector derived from angle)
    //     get_CurrentWindSpeed           → float
    //     get_Wind                       → likely the already-scaled Vector3
    //                                      (CurrentWindDirection * CurrentWindSpeed)
    //
    //   Multipliers (per-match or per-course):
    //     get_CrossWindFactor            → float (applied to the cross-wind component)
    //     get_WindFactor                 → float (per-hittable wind response factor)
    //
    //   Event:
    //     add_WindUpdated                → fires whenever wind changes
    //
    // Ball-side: WindHittableSettings + ShouldApplyWind gate per-hittable. We
    // don't need to touch those — they only govern whether the *game* applies
    // wind, not whether our prediction should. We always predict wind effects.
    //
    // Why our first attempt failed: we used a hardcoded WIND_COEFF=0.08f that
    // was tuned for our old custom simulator, not Mimi's forward sim. Mimi's
    // sim integrates velocity explicitly with gravity + drag — wind needs to
    // be scaled to match the game's actual wind-to-velocity conversion.
    //
    // Fix: read a user-tunable windStrength coefficient from config + the
    // settings GUI, and multiply it by the game-provided wind vector. The
    // user can adjust it live until predicted and actual shots agree. Default
    // value (1.0f) is high enough to be clearly visible.

    private bool windReflectionInitialized;
    private Type cachedWindManagerType;
    private Component cachedWindManagerInstance;
    private PropertyInfo cachedWindVectorProperty;           // "Wind" — preferred, already scaled
    private PropertyInfo cachedWindDirectionProperty;        // "CurrentWindDirection"
    private PropertyInfo cachedWindSpeedProperty;            // "CurrentWindSpeed"
    private PropertyInfo cachedWindNetworkAngleProperty;     // "NetworkcurrentWindAngle"
    private PropertyInfo cachedWindNetworkSpeedProperty;     // "NetworkcurrentWindSpeed"
    private PropertyInfo cachedCrossWindFactorProperty;      // "CrossWindFactor"
    private Vector3 cachedWindVector = Vector3.zero;
    private float cachedWindCrossFactor = 1f;
    private float nextWindRefreshTime;
    private readonly float windCacheRefreshInterval = 0.2f;
    private string windDiagnosticReadout = "(wind: not initialized)";

    private void EnsureWindReflectionInitialized()
    {
        if (windReflectionInitialized)
        {
            return;
        }
        windReflectionInitialized = true;

        try
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                Type t = assemblies[i].GetType("WindManager");
                if (t != null)
                {
                    cachedWindManagerType = t;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            MelonLogger.Warning($"[MimiMod] Wind: assembly scan failed: {ex.GetType().Name}");
        }

        if (cachedWindManagerType == null)
        {
            MelonLogger.Warning("[MimiMod] Wind: WindManager type not found in any loaded assembly. Wind prediction disabled.");
            windDiagnosticReadout = "(WindManager type missing)";
            return;
        }

        // Resolve every candidate property via cascade — any one can populate
        // the wind vector, we pick the best available at read time.
        cachedWindVectorProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "Wind",
            "Wind");

        cachedWindDirectionProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "CurrentWindDirection",
            "CurrentWindDirection", "WindDirection", "Direction");

        cachedWindSpeedProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "CurrentWindSpeed",
            "CurrentWindSpeed", "WindSpeed", "Speed", "Magnitude");

        cachedWindNetworkAngleProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "NetworkcurrentWindAngle",
            "NetworkcurrentWindAngle");

        cachedWindNetworkSpeedProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "NetworkcurrentWindSpeed",
            "NetworkcurrentWindSpeed");

        cachedCrossWindFactorProperty = ModReflectionHelper.GetPropertyCascade(
            cachedWindManagerType,
            "CrossWindFactor",
            "CrossWindFactor", "WindFactor");

        LogWindApiSummary();
    }

    private void LogWindApiSummary()
    {
        try
        {
            StringBuilder sb = new StringBuilder(256);
            sb.Append("[MimiMod] Wind API resolved: ");
            sb.Append("Wind=").Append(cachedWindVectorProperty != null ? "Y" : "n");
            sb.Append(" CurDir=").Append(cachedWindDirectionProperty != null ? "Y" : "n");
            sb.Append(" CurSpd=").Append(cachedWindSpeedProperty != null ? "Y" : "n");
            sb.Append(" NetAng=").Append(cachedWindNetworkAngleProperty != null ? "Y" : "n");
            sb.Append(" NetSpd=").Append(cachedWindNetworkSpeedProperty != null ? "Y" : "n");
            sb.Append(" Cross=").Append(cachedCrossWindFactorProperty != null ? "Y" : "n");
            MelonLogger.Msg(sb.ToString());
        }
        catch
        {
        }
    }

    private Vector3 GetCachedWindVector()
    {
        EnsureWindReflectionInitialized();

        float currentTime = Time.time;
        if (currentTime < nextWindRefreshTime && cachedWindManagerInstance != null)
        {
            return cachedWindVector;
        }
        nextWindRefreshTime = currentTime + windCacheRefreshInterval;

        if (cachedWindManagerType == null)
        {
            cachedWindVector = Vector3.zero;
            windDiagnosticReadout = "(no WindManager type)";
            return cachedWindVector;
        }

        if (cachedWindManagerInstance == null || cachedWindManagerInstance.gameObject == null)
        {
            cachedWindManagerInstance = ResolveWindManagerInstance();
            if (cachedWindManagerInstance == null)
            {
                cachedWindVector = Vector3.zero;
                windDiagnosticReadout = "(WindManager instance not in scene)";
                return cachedWindVector;
            }
        }

        try
        {
            Vector3 rawWind = Vector3.zero;
            bool readSucceeded = false;
            string readSource = "-";

            // Preferred source: Wind property (already combined direction * speed).
            if (cachedWindVectorProperty != null)
            {
                object windValue = cachedWindVectorProperty.GetValue(cachedWindManagerInstance, null);
                if (windValue is Vector3 wv)
                {
                    rawWind = wv;
                    readSucceeded = true;
                    readSource = "Wind";
                }
            }

            // Fallback: CurrentWindDirection * CurrentWindSpeed.
            if (!readSucceeded && cachedWindDirectionProperty != null && cachedWindSpeedProperty != null)
            {
                object dirValue = cachedWindDirectionProperty.GetValue(cachedWindManagerInstance, null);
                object speedValue = cachedWindSpeedProperty.GetValue(cachedWindManagerInstance, null);
                Vector3 dir = dirValue is Vector3 dv ? dv : Vector3.zero;
                float spd = ConvertToFloat(speedValue);
                rawWind = (dir.sqrMagnitude > 0.0001f ? dir.normalized : Vector3.zero) * spd;
                readSucceeded = true;
                readSource = "Dir*Spd";
            }

            // Last resort: build from NetworkcurrentWindAngle + NetworkcurrentWindSpeed
            // (angle is degrees; assume 0 = north/+Z and rotates clockwise).
            if (!readSucceeded && cachedWindNetworkAngleProperty != null && cachedWindNetworkSpeedProperty != null)
            {
                object angleValue = cachedWindNetworkAngleProperty.GetValue(cachedWindManagerInstance, null);
                object speedValue = cachedWindNetworkSpeedProperty.GetValue(cachedWindManagerInstance, null);
                float angleDeg = ConvertToFloat(angleValue);
                float spd = ConvertToFloat(speedValue);
                float rad = angleDeg * Mathf.Deg2Rad;
                rawWind = new Vector3(Mathf.Sin(rad), 0f, Mathf.Cos(rad)) * spd;
                readSucceeded = true;
                readSource = "Net";
            }

            if (!readSucceeded)
            {
                windDiagnosticReadout = "(no readable wind property)";
                cachedWindVector = Vector3.zero;
                return cachedWindVector;
            }

            // Apply CrossWindFactor multiplier if present (per-match/per-course wind strength).
            if (cachedCrossWindFactorProperty != null)
            {
                object factorValue = cachedCrossWindFactorProperty.GetValue(cachedWindManagerInstance, null);
                float factor = ConvertToFloat(factorValue);
                if (factor > 0.0001f)
                {
                    cachedWindCrossFactor = factor;
                }
            }

            cachedWindVector = rawWind;
            windDiagnosticReadout = $"src={readSource} v=({rawWind.x:F2},{rawWind.z:F2}) mag={rawWind.magnitude:F2} cwf={cachedWindCrossFactor:F2}";
        }
        catch (Exception ex)
        {
            windDiagnosticReadout = $"(exception: {ex.GetType().Name})";
            cachedWindVector = Vector3.zero;
        }

        return cachedWindVector;
    }

    private static float ConvertToFloat(object value)
    {
        if (value is float f) return f;
        if (value is double d) return (float)d;
        if (value is int i) return i;
        return 0f;
    }

    private Component ResolveWindManagerInstance()
    {
        if (cachedWindManagerType == null)
        {
            return null;
        }

        try
        {
            // Try FindFirstObjectByType first.
            UnityEngine.Object obj = UnityEngine.Object.FindFirstObjectByType(cachedWindManagerType);
            if (obj != null)
            {
                return obj as Component;
            }

            // Fallback: include inactive objects in the search.
            UnityEngine.Object[] allInstances = UnityEngine.Object.FindObjectsByType(
                cachedWindManagerType,
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);
            if (allInstances != null && allInstances.Length > 0)
            {
                return allInstances[0] as Component;
            }
        }
        catch (Exception ex)
        {
            MelonLogger.Warning($"[MimiMod] Wind: FindObjectsByType failed: {ex.GetType().Name}");
        }

        return null;
    }

    /// <summary>
    /// Human-readable current wind state for the settings GUI.
    /// </summary>
    internal string GetWindDiagnosticReadout()
    {
        return windDiagnosticReadout;
    }
}
