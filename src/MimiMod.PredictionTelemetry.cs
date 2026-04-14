using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using MelonLoader;
using UnityEngine;

public partial class SuperHackerGolf
{
    // ── Shot prediction telemetry ──────────────────────────────────────────────
    //
    // Captures every auto-fired shot so we can measure how close our wind
    // prediction was to reality. For each shot:
    //
    //   1. At the moment of release, snapshot:
    //      - frozen predicted landing (last point of frozenPredictedPathPoints)
    //      - ball origin, hole position, wind vector + magnitude
    //      - ball WindFactor / CrossWindFactor / airDragFactor
    //      - applied power, pitch, swing-power multiplier
    //
    //   2. Each frame after release, watch the ball:
    //      - record the first ground-impact position (when ballY <= holeY
    //        and velocity.y < 0, matching SimulateBallLandingPoint's termination)
    //      - wait until the ball comes to rest (velocity < 0.15)
    //
    //   3. When the ball stops, compute:
    //      - impact delta      = actual_impact - predicted_impact
    //      - final rest delta  = final_rest - predicted_impact
    //      - vs-hole miss      = actual_impact - hole_position
    //      Emit a structured log line and append a CSV row to
    //      Mods/SuperHackerGolf-telemetry.csv. Also keep the last 8 entries in
    //      memory so the settings GUI can show them live.
    //
    // Toggled by config key `telemetry_enabled` (default off). When off, no
    // captures, no logs, no CSV.

    private bool telemetryShotInProgress;
    private bool telemetryImpactRecorded;
    private float telemetryCaptureTime;
    private Vector3 telemetryPredictedLanding;
    private Vector3 telemetryShotOrigin;
    private Vector3 telemetryHolePosition;
    private Vector3 telemetryWindAtRelease;
    private Vector3 telemetryActualImpact;
    private float telemetryBallWindFactorAtRelease;
    private float telemetryBallCrossWindFactorAtRelease;
    private float telemetryAirDragFactorAtRelease;
    private float telemetrySwingPowerMultiplierAtRelease;
    private float telemetryAppliedPower;
    private float telemetryShotPitch;
    private int telemetryShotCounter;

    private readonly float telemetryBallStopSpeed = 0.15f;
    private readonly float telemetryBallImpactEpsilon = 0.10f;
    private readonly float telemetryMinShotTime = 0.15f;
    private readonly float telemetryMaxShotTime = 20f;
    private readonly int telemetryMaxHistory = 8;
    private readonly List<string> telemetryRecentSummaries = new List<string>(8);
    private string telemetryCsvPath;
    private bool telemetryCsvHeaderWritten;

    /// <summary>
    /// Called from AutoSwingRelease right after FreezePredictedTrajectorySnapshot,
    /// so the frozen trajectory is populated and the ball is about to launch.
    /// </summary>
    internal void CaptureShotTelemetry(float appliedPower, float shotPitch)
    {
        if (!telemetryEnabled)
        {
            return;
        }
        if (golfBall == null)
        {
            return;
        }
        if (frozenPredictedPathPoints == null || frozenPredictedPathPoints.Count == 0)
        {
            return;
        }

        telemetryShotInProgress = true;
        telemetryImpactRecorded = false;
        telemetryCaptureTime = Time.time;
        telemetryPredictedLanding = frozenPredictedPathPoints[frozenPredictedPathPoints.Count - 1];
        telemetryShotOrigin = golfBall.transform.position;
        telemetryHolePosition = holePosition;
        telemetryWindAtRelease = GetCachedWindVector();
        telemetryBallWindFactorAtRelease = GetBallWindFactor();
        telemetryBallCrossWindFactorAtRelease = GetBallCrossWindFactor();
        telemetryAirDragFactorAtRelease = GetRuntimeLinearAirDragFactor();
        telemetryAppliedPower = appliedPower;
        telemetryShotPitch = shotPitch;
        telemetrySwingPowerMultiplierAtRelease = 1f;
        TryGetServerSwingPowerMultiplier(out telemetrySwingPowerMultiplierAtRelease);
    }

    /// <summary>
    /// Called every frame from OnUpdate while a shot is in flight. Watches for
    /// first ground impact, then for ball stop, then logs + appends CSV.
    /// </summary>
    internal void UpdateShotTelemetry()
    {
        if (!telemetryShotInProgress)
        {
            return;
        }
        if (golfBall == null || golfBall.gameObject == null)
        {
            telemetryShotInProgress = false;
            return;
        }

        float elapsed = Time.time - telemetryCaptureTime;
        if (elapsed > telemetryMaxShotTime)
        {
            // Something went wrong — ball never stopped. Abort without logging.
            telemetryShotInProgress = false;
            return;
        }

        Vector3 ballPos = golfBall.transform.position;

        if (!TryGetGolfBallVelocity(out Vector3 ballVel))
        {
            return;
        }

        // Record first ground impact: matches SimulateBallLandingPoint's termination
        // condition (ball crosses target height going down).
        if (!telemetryImpactRecorded &&
            elapsed > telemetryMinShotTime &&
            ballVel.y < 0f &&
            ballPos.y <= telemetryHolePosition.y + telemetryBallImpactEpsilon)
        {
            telemetryActualImpact = ballPos;
            telemetryImpactRecorded = true;
        }

        // Wait for ball to rest before logging the final result.
        if (elapsed < telemetryMinShotTime || ballVel.sqrMagnitude > telemetryBallStopSpeed * telemetryBallStopSpeed)
        {
            return;
        }

        // Ball has stopped — log.
        telemetryShotCounter++;
        Vector3 finalRest = ballPos;
        Vector3 actualImpact = telemetryImpactRecorded ? telemetryActualImpact : finalRest;
        Vector3 impactDelta = actualImpact - telemetryPredictedLanding;
        Vector3 restDelta = finalRest - telemetryPredictedLanding;
        Vector3 vsHole = actualImpact - telemetryHolePosition;

        float windMag = telemetryWindAtRelease.magnitude;
        float shotDistance = new Vector3(
            telemetryHolePosition.x - telemetryShotOrigin.x,
            0f,
            telemetryHolePosition.z - telemetryShotOrigin.z).magnitude;

        string summary = $"#{telemetryShotCounter} dist={shotDistance:F1}m " +
                         $"pwr={telemetryAppliedPower * 100f:F0}% " +
                         $"pitch={telemetryShotPitch:F1}° " +
                         $"wind=({telemetryWindAtRelease.x:F1},{telemetryWindAtRelease.z:F1}) |{windMag:F1}| " +
                         $"impactΔ=({impactDelta.x:+0.00;-0.00},{impactDelta.z:+0.00;-0.00}) |{impactDelta.magnitude:F2}|m " +
                         $"vsHole=|{vsHole.magnitude:F2}|m";

        MelonLogger.Msg("[SuperHackerGolf] Telemetry " + summary);

        telemetryRecentSummaries.Add(summary);
        if (telemetryRecentSummaries.Count > telemetryMaxHistory)
        {
            telemetryRecentSummaries.RemoveAt(0);
        }

        AppendTelemetryCsv(
            shotDistance: shotDistance,
            finalRest: finalRest,
            actualImpact: actualImpact,
            impactDelta: impactDelta,
            restDelta: restDelta,
            vsHole: vsHole,
            flightTime: elapsed);

        telemetryShotInProgress = false;
    }

    private void AppendTelemetryCsv(float shotDistance, Vector3 finalRest, Vector3 actualImpact,
                                     Vector3 impactDelta, Vector3 restDelta, Vector3 vsHole, float flightTime)
    {
        try
        {
            if (string.IsNullOrEmpty(telemetryCsvPath))
            {
                telemetryCsvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mods", "SuperHackerGolf-telemetry.csv");
            }

            CultureInfo ic = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder(512);

            if (!telemetryCsvHeaderWritten && !File.Exists(telemetryCsvPath))
            {
                sb.AppendLine("shot,shot_distance_m,flight_s,wind_x,wind_z,wind_mag,wind_factor,cross_wind_factor,air_drag,swing_power_mul,power_pct,pitch_deg,origin_x,origin_y,origin_z,hole_x,hole_y,hole_z,predict_x,predict_y,predict_z,impact_x,impact_y,impact_z,final_x,final_y,final_z,impact_delta_x,impact_delta_y,impact_delta_z,impact_delta_mag,rest_delta_mag,vs_hole_mag");
                telemetryCsvHeaderWritten = true;
            }

            sb.Append(telemetryShotCounter.ToString(ic)).Append(',')
              .Append(shotDistance.ToString("0.###", ic)).Append(',')
              .Append(flightTime.ToString("0.###", ic)).Append(',')
              .Append(telemetryWindAtRelease.x.ToString("0.###", ic)).Append(',')
              .Append(telemetryWindAtRelease.z.ToString("0.###", ic)).Append(',')
              .Append(telemetryWindAtRelease.magnitude.ToString("0.###", ic)).Append(',')
              .Append(telemetryBallWindFactorAtRelease.ToString("0.####", ic)).Append(',')
              .Append(telemetryBallCrossWindFactorAtRelease.ToString("0.####", ic)).Append(',')
              .Append(telemetryAirDragFactorAtRelease.ToString("0.######", ic)).Append(',')
              .Append(telemetrySwingPowerMultiplierAtRelease.ToString("0.####", ic)).Append(',')
              .Append((telemetryAppliedPower * 100f).ToString("0.##", ic)).Append(',')
              .Append(telemetryShotPitch.ToString("0.##", ic)).Append(',')
              .Append(telemetryShotOrigin.x.ToString("0.##", ic)).Append(',')
              .Append(telemetryShotOrigin.y.ToString("0.##", ic)).Append(',')
              .Append(telemetryShotOrigin.z.ToString("0.##", ic)).Append(',')
              .Append(telemetryHolePosition.x.ToString("0.##", ic)).Append(',')
              .Append(telemetryHolePosition.y.ToString("0.##", ic)).Append(',')
              .Append(telemetryHolePosition.z.ToString("0.##", ic)).Append(',')
              .Append(telemetryPredictedLanding.x.ToString("0.##", ic)).Append(',')
              .Append(telemetryPredictedLanding.y.ToString("0.##", ic)).Append(',')
              .Append(telemetryPredictedLanding.z.ToString("0.##", ic)).Append(',')
              .Append(actualImpact.x.ToString("0.##", ic)).Append(',')
              .Append(actualImpact.y.ToString("0.##", ic)).Append(',')
              .Append(actualImpact.z.ToString("0.##", ic)).Append(',')
              .Append(finalRest.x.ToString("0.##", ic)).Append(',')
              .Append(finalRest.y.ToString("0.##", ic)).Append(',')
              .Append(finalRest.z.ToString("0.##", ic)).Append(',')
              .Append(impactDelta.x.ToString("0.###", ic)).Append(',')
              .Append(impactDelta.y.ToString("0.###", ic)).Append(',')
              .Append(impactDelta.z.ToString("0.###", ic)).Append(',')
              .Append(impactDelta.magnitude.ToString("0.###", ic)).Append(',')
              .Append(restDelta.magnitude.ToString("0.###", ic)).Append(',')
              .Append(vsHole.magnitude.ToString("0.###", ic))
              .AppendLine();

            File.AppendAllText(telemetryCsvPath, sb.ToString());
        }
        catch (Exception ex)
        {
            MelonLogger.Warning($"[SuperHackerGolf] Telemetry CSV write failed: {ex.GetType().Name}: {ex.Message}");
        }
    }

    internal IList<string> GetTelemetryRecentSummaries() => telemetryRecentSummaries;
    internal int GetTelemetryShotCount() => telemetryShotCounter;
}
