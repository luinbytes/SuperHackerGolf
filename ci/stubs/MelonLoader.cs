// Compile-time stubs for MelonLoader types used by SuperHackerGolf.
// Only the API surface required by the mod is modelled; everything else
// is either omitted or stubbed empty.

using System;

#pragma warning disable CS0626, CS0649, CS8618, CS8625

namespace MelonLoader
{
    // MelonLoader uses C# attribute-suffix elision: the runtime classes are
    // named MelonInfoAttribute / MelonGameAttribute, callers use [MelonInfo(...)]
    // and [MelonGame]. We model only the *Attribute variants; the compiler will
    // resolve the short form automatically. Declaring both forms produces
    // CS1614 ambiguity errors.
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MelonInfoAttribute : Attribute
    {
        public MelonInfoAttribute(Type type, string name, string version, string author) { }
        public MelonInfoAttribute(Type type, string name, string version, string author, string downloadLink) { }
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MelonGameAttribute : Attribute
    {
        public MelonGameAttribute() { }
        public MelonGameAttribute(string developer, string name) { }
    }

    public abstract class MelonBase
    {
        public virtual void OnApplicationStart() { }
        public virtual void OnApplicationQuit() { }
        public virtual void OnUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnGUI() { }
        public virtual void OnSceneWasLoaded(int buildIndex, string sceneName) { }
        public virtual void OnSceneWasInitialized(int buildIndex, string sceneName) { }
        public virtual void OnSceneWasUnloaded(int buildIndex, string sceneName) { }
    }

    public abstract class MelonMod : MelonBase { }
    public abstract class MelonPlugin : MelonBase { }

    public static class MelonLogger
    {
        public static void Msg(string text) { }
        public static void Msg(object obj) { }
        public static void Msg(string format, params object[] args) { }
        public static void Warning(string text) { }
        public static void Warning(object obj) { }
        public static void Warning(string format, params object[] args) { }
        public static void Error(string text) { }
        public static void Error(object obj) { }
        public static void Error(string format, params object[] args) { }
        public static void BigError(string category, string message) { }
    }
}
