# SuperHackerGolf

Client-side cheat mod for **Super Battle Golf** built on MelonLoader.

Made by **[@luinbytes](https://github.com/luinbytes)** — Discord: `@luinbytes` · Portfolio: <https://luinbytes.github.io>

## Features

- **Aim assist** — orbit-camera auto-aim toward the hole
- **Auto-release** — releases the swing at the optimal power to land on the hole
- **Wind-aware trajectory prediction** — exact reimplementation of `Hittable.ApplyAirDamping` so the predicted line matches the real ball physics (reads `WindFactor` / `CrossWindFactor` from the game's `WindHittableSettings` via reflection)
- **Crosswind aim compensation** — 2D solver that nudges the aim target so the ball curves into the hole under wind (long shots only — skipped under 15m where drift is negligible)
- **Overcharge clamp** — disables the game's 115% overcharge cap by default so shots stay accurate
- **Manual-charge mode** — when off, the player charges the swing manually and the mod only releases at optimal power
- **Impact preview window** — offscreen camera showing the predicted landing zone
- **Trail visualizers** — predicted, frozen, and actual shot trails as LineRenderers
- **Anti-cheat bypass** — HarmonyX-patches `AntiCheatRateChecker.RegisterHit` and `AntiCheatPerPlayerRateChecker.RegisterHit` to always return `true`, so the game's rate-limit detection never fires (runs server-side; fully effective in solo / host play)
- **Cosmetics unlock** — unlocks all cosmetics via reflection
- **Coffee speed boost** + **nearest-ball mode** hotkeys
- **In-game clickable settings GUI** — IMGUI window (default F8) with toggles, sliders, and save/reload buttons

## Default hotkeys

| Key  | Action                        |
|------|-------------------------------|
| `F`  | Toggle aim assist             |
| `F2` | Coffee speed boost            |
| `F3` | Nearest-ball mode             |
| `F4` | Unlock all cosmetics          |
| `F8` | Open settings GUI             |
| RMB  | Auto-aim camera (hold)        |

## Requirements

- Super Battle Golf installed
- MelonLoader 0.7.2 installed into the game folder (do **not** use r2modman's BepInEx proxy — it shadows MelonLoader's `version.dll`)
- .NET SDK 6.0+ for building

Steam launch options must include the Wine DLL override so the game loads MelonLoader's `version.dll`:

```
WINEDLLOVERRIDES="version=n,b" %command%
```

## Building

```bash
dotnet build -c Release
./install.sh
```

Outputs `bin/Release/SuperHackerGolf.dll` and copies it into `<gamefolder>/Mods/`.

## Project structure

```
src/
  MimiMod.cs              — main partial class, reflection caches, fields
  MimiMod.AntiCheat.cs    — anti-cheat detection event canary
  MimiMod.AntiCheatBypass.cs — HarmonyX bypass for RegisterHit
  MimiMod.Camera.cs       — orbit-camera aim assist via reflection
  MimiMod.Config.cs       — plaintext key=value config parser
  MimiMod.Context.cs      — PlayerMovement / PlayerGolfer / GolfBall resolution
  MimiMod.Cosmetics.cs    — cosmetics unlock
  MimiMod.ImpactPreview.cs — offscreen RenderTexture impact preview window
  MimiMod.PitchSolver.cs  — analytic closed-form pitch / speed solver library
  MimiMod.Runtime.cs      — OnUpdate / OnLateUpdate lifecycle
  MimiMod.SettingsGui.cs  — IMGUI settings window
  MimiMod.Swing.cs        — auto swing release with binary-search timing
  MimiMod.Trajectory.cs   — exact game forward-sim + wind-aware solvers
  MimiMod.UI.cs           — Canvas + TextMeshProUGUI HUD
  MimiMod.Wind.cs         — WindManager + HittableSettings reflection
  Helpers/
    ModReflectionHelper.cs — reflection member caching + fallback cascades
    ModTextHelper.cs       — string helpers
```

## Anti-cheat audit

The game ships `AntiCheat.dll` containing `AntiCheatRateChecker` + `AntiCheatPerPlayerRateChecker` — a server-side rate limiter on networked actions. `RegisterHit` increments a counter when hits come faster than `expectedMinTimeBetweenHits`; crossing `minSuspiciousHitCount` / `minConfirmedCheatHitCount` fires detection events. The game's own `VoteKickManager` subscribes to these events and initiates an automatic vote-kick (not a ban). This mod Harmony-patches both `RegisterHit` methods with a prefix that returns `true` and skips the original, so the counter never increments and events never fire.

## Credits

Made by [@luinbytes](https://github.com/luinbytes) — <https://luinbytes.github.io>
