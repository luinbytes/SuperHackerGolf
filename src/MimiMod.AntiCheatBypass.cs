using System;
using System.Reflection;
using HarmonyLib;
using MelonLoader;

public partial class SuperHackerGolf
{
    // ── Anti-cheat bypass (D5 rewrite) ─────────────────────────────────────────
    //
    // D5 was awareness-only — we stayed under the detection thresholds. User
    // wants a real bypass now. Decompiled AntiCheat.dll with Mono.Cecil:
    //
    //   public bool AntiCheatRateChecker.RegisterHit()
    //     - measures time since last hit
    //     - if timeSince > expectedMinTimeBetweenHits: returns true (OK)
    //     - else increments rateExceededHitCount; if it crosses
    //       minSuspiciousHitCount or minConfirmedCheatHitCount, fires the
    //       detection events and returns FALSE (rate-limited)
    //
    //   public bool AntiCheatPerPlayerRateChecker.RegisterHit(NetworkConnectionToClient)
    //     - looks up or creates a per-connection AntiCheatRateChecker
    //     - delegates to the inner RegisterHit
    //
    // The rate limiters are members of Hittable (serverHitWithGolfSwingCommandRateLimiter,
    // serverHitWithSwingProjectileCommandRateLimiter, etc.) and are called from the
    // [Command] handlers (CmdHitWithGolfSwing etc.) — so they run SERVER-SIDE.
    //
    // Patching both RegisterHit methods with a prefix that sets __result=true
    // and skips the original disables every rate check on whichever instance
    // runs this mod. For solo/host play this fully bypasses detection; for a
    // non-host client, the host still enforces its own limits.
    //
    // Uses runtime reflection to find the AntiCheat types so the mod doesn't
    // need to reference AntiCheat.dll at compile time.

    private static bool antiCheatBypassInstalled;

    internal void TryInstallAntiCheatBypass()
    {
        if (antiCheatBypassInstalled)
        {
            return;
        }
        antiCheatBypassInstalled = true;

        try
        {
            HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.lumods.mimimod.anticheatbypass");

            Type rateCheckerType = null;
            Type perPlayerType = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (rateCheckerType == null)
                {
                    rateCheckerType = assemblies[i].GetType("AntiCheatRateChecker");
                }
                if (perPlayerType == null)
                {
                    perPlayerType = assemblies[i].GetType("AntiCheatPerPlayerRateChecker");
                }
                if (rateCheckerType != null && perPlayerType != null)
                {
                    break;
                }
            }

            int patched = 0;

            if (rateCheckerType != null)
            {
                MethodInfo target = AccessTools.Method(rateCheckerType, "RegisterHit", Type.EmptyTypes);
                if (target != null)
                {
                    MethodInfo prefix = typeof(SuperHackerGolf).GetMethod(
                        nameof(AntiCheatRegisterHitPrefix),
                        BindingFlags.NonPublic | BindingFlags.Static);
                    harmony.Patch(target, new HarmonyMethod(prefix));
                    patched++;
                    MelonLogger.Msg("[SuperHackerGolf] Patched AntiCheatRateChecker.RegisterHit");
                }
                else
                {
                    MelonLogger.Warning("[SuperHackerGolf] AntiCheatRateChecker.RegisterHit method not found for patching");
                }
            }
            else
            {
                MelonLogger.Warning("[SuperHackerGolf] AntiCheatRateChecker type not found — bypass will be partial");
            }

            if (perPlayerType != null)
            {
                // The per-player method takes a NetworkConnectionToClient — resolve by name to avoid a Mirror reference.
                MethodInfo target = null;
                foreach (var m in perPlayerType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    if (m.Name == "RegisterHit" && m.GetParameters().Length == 1)
                    {
                        target = m;
                        break;
                    }
                }

                if (target != null)
                {
                    MethodInfo prefix = typeof(SuperHackerGolf).GetMethod(
                        nameof(AntiCheatPerPlayerRegisterHitPrefix),
                        BindingFlags.NonPublic | BindingFlags.Static);
                    harmony.Patch(target, new HarmonyMethod(prefix));
                    patched++;
                    MelonLogger.Msg("[SuperHackerGolf] Patched AntiCheatPerPlayerRateChecker.RegisterHit");
                }
                else
                {
                    MelonLogger.Warning("[SuperHackerGolf] AntiCheatPerPlayerRateChecker.RegisterHit method not found for patching");
                }
            }

            if (patched == 0)
            {
                MelonLogger.Warning("[SuperHackerGolf] Anti-cheat bypass installed 0 patches — types unavailable at startup");
            }
            else
            {
                MelonLogger.Msg($"[SuperHackerGolf] Anti-cheat bypass online ({patched} patches applied)");
            }
        }
        catch (Exception ex)
        {
            MelonLogger.Warning($"[SuperHackerGolf] Anti-cheat bypass install failed: {ex.GetType().Name}: {ex.Message}");
        }
    }

    // Harmony prefix: set __result = true, return false to skip the original body.
    private static bool AntiCheatRegisterHitPrefix(ref bool __result)
    {
        __result = true;
        return false;
    }

    private static bool AntiCheatPerPlayerRegisterHitPrefix(ref bool __result)
    {
        __result = true;
        return false;
    }
}
