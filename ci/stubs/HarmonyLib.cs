// Compile-time stubs for HarmonyLib (0Harmony) types used by SuperHackerGolf.

using System;
using System.Reflection;

#pragma warning disable CS0626, CS0649, CS8618, CS8625

namespace HarmonyLib
{
    public class Harmony
    {
        public Harmony(string id) { Id = id; }
        public string Id { get; }
        public MethodBase Patch(
            MethodBase original,
            HarmonyMethod prefix = null,
            HarmonyMethod postfix = null,
            HarmonyMethod transpiler = null,
            HarmonyMethod finalizer = null) => null;
        public void Unpatch(MethodBase original, HarmonyPatchType type) { }
        public void Unpatch(MethodBase original, HarmonyPatchType type, string harmonyID) { }
        public void UnpatchSelf() { }
        public void UnpatchAll() { }
        public void UnpatchAll(string harmonyID) { }
    }

    public class HarmonyMethod
    {
        public MethodInfo method;
        public HarmonyMethod() { }
        public HarmonyMethod(MethodInfo method) { this.method = method; }
        public HarmonyMethod(MethodInfo method, int priority) { this.method = method; }
        public HarmonyMethod(Type methodType, string methodName, Type[] argumentTypes = null) { }
    }

    public enum HarmonyPatchType
    {
        All, Prefix, Postfix, Transpiler, Finalizer, ReversePatch,
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HarmonyPatch : Attribute
    {
        public HarmonyPatch() { }
        public HarmonyPatch(Type declaringType) { }
        public HarmonyPatch(Type declaringType, string methodName) { }
        public HarmonyPatch(string methodName) { }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HarmonyPrefix : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class HarmonyPostfix : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class HarmonyTranspiler : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class HarmonyFinalizer : Attribute { }

    public static class AccessTools
    {
        public static readonly BindingFlags all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        public static Type TypeByName(string name) => null;
        public static MethodInfo Method(Type type, string name) => null;
        public static MethodInfo Method(Type type, string name, Type[] parameters) => null;
        public static MethodInfo Method(Type type, string name, Type[] parameters, Type[] generics) => null;
        public static MethodInfo Method(string typeColonName) => null;
        public static FieldInfo Field(Type type, string name) => null;
        public static PropertyInfo Property(Type type, string name) => null;
        public static ConstructorInfo Constructor(Type type, Type[] parameters = null) => null;
    }
}
