// Compile-time stubs for UnityEngine types used by SuperHackerGolf.
// Empty bodies — only the public API surface matters for the C# compiler.
// DO NOT use these at runtime; they exist solely so CI can build without
// access to the real Unity Editor / game DLLs.
//
// All members default to either `default`, `null`, `0`, `false` or empty
// arrays. IL bodies don't matter — at runtime the real Unity assemblies
// are loaded by MelonLoader and these stubs are not present in the bin
// folder of the actual mod.

using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0626, CS0649, CS0414, CS8618, CS8625

namespace UnityEngine
{
    // ── Attributes ─────────────────────────────────────────────────────────────
    [AttributeUsage(AttributeTargets.All)] public sealed class SerializeField : Attribute { }
    [AttributeUsage(AttributeTargets.Class)] public sealed class DefaultExecutionOrder : Attribute { public DefaultExecutionOrder(int order) { } }
    [AttributeUsage(AttributeTargets.Class)] public sealed class RequireComponent : Attribute { public RequireComponent(Type t) { } }
    [AttributeUsage(AttributeTargets.Class)] public sealed class AddComponentMenu : Attribute { public AddComponentMenu(string menu) { } }
    [AttributeUsage(AttributeTargets.Class)] public sealed class DisallowMultipleComponent : Attribute { }
    [AttributeUsage(AttributeTargets.All)] public sealed class HideInInspector : Attribute { }
    [AttributeUsage(AttributeTargets.All)] public sealed class TooltipAttribute : Attribute { public TooltipAttribute(string s) { } }

    // ── Enums ──────────────────────────────────────────────────────────────────
    [Flags]
    public enum HideFlags
    {
        None = 0,
        HideInHierarchy = 1,
        HideInInspector = 2,
        DontSaveInEditor = 4,
        NotEditable = 8,
        DontSaveInBuild = 16,
        DontUnloadUnusedAsset = 32,
        DontSave = 52,
        HideAndDontSave = 61,
    }

    public enum FilterMode { Point, Bilinear, Trilinear }
    public enum TextureWrapMode { Repeat, Clamp, Mirror, MirrorOnce }
    public enum TextureFormat
    {
        Alpha8 = 1, ARGB4444 = 2, RGB24 = 3, RGBA32 = 4, ARGB32 = 5, RGB565 = 7,
        R16 = 9, DXT1 = 10, DXT5 = 12, RGBA4444 = 13, BGRA32 = 14,
    }

    public enum FontStyle { Normal, Bold, Italic, BoldAndItalic }
    public enum TextAnchor { UpperLeft, UpperCenter, UpperRight, MiddleLeft, MiddleCenter, MiddleRight, LowerLeft, LowerCenter, LowerRight }
    public enum EventType { MouseDown, MouseUp, MouseMove, MouseDrag, KeyDown, KeyUp, ScrollWheel, Repaint, Layout, DragUpdated, DragPerform, DragExited, Ignore, Used, ValidateCommand, ExecuteCommand, ContextClick, MouseEnterWindow, MouseLeaveWindow, TouchDown, TouchUp, TouchMove, TouchEnter, TouchLeave, TouchStationary }
    public enum ScaleMode { StretchToFill, ScaleAndCrop, ScaleToFit }
    public enum QueryTriggerInteraction { UseGlobal, Ignore, Collide }
    public enum CameraClearFlags { Skybox = 1, Color = 2, SolidColor = 2, Depth = 3, Nothing = 4 }
    public enum DepthTextureMode { None = 0, Depth = 1, DepthNormals = 2, MotionVectors = 4 }
    public enum RenderingPath { UsePlayerSettings = -1, VertexLit = 0, Forward = 1, DeferredLighting = 2, DeferredShading = 3 }
    public enum LineAlignment { View, TransformZ, Local }
    public enum LineTextureMode { Stretch, Tile, DistributePerSegment, RepeatPerSegment }
    public enum FindObjectsInactive { Exclude, Include }
    public enum FindObjectsSortMode { None, InstanceID }
    public enum RenderMode { ScreenSpaceOverlay, ScreenSpaceCamera, WorldSpace }
    public enum GradientMode { Blend, Fixed }

    // ── Primitives ─────────────────────────────────────────────────────────────
    public struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y) { this.x = x; this.y = y; }
        public float magnitude => 0f;
        public float sqrMagnitude => 0f;
        public Vector2 normalized => default;
        public static Vector2 zero => default;
        public static Vector2 one => default;
        public static Vector2 up => default;
        public static Vector2 right => default;
        public static Vector2 operator +(Vector2 a, Vector2 b) => default;
        public static Vector2 operator -(Vector2 a, Vector2 b) => default;
        public static Vector2 operator -(Vector2 a) => default;
        public static Vector2 operator *(Vector2 a, float b) => default;
        public static Vector2 operator *(float a, Vector2 b) => default;
        public static Vector2 operator /(Vector2 a, float b) => default;
        public static bool operator ==(Vector2 a, Vector2 b) => false;
        public static bool operator !=(Vector2 a, Vector2 b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
        public static implicit operator Vector3(Vector2 v) => default;
    }

    public struct Vector3
    {
        public float x, y, z;
        public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
        public Vector3(float x, float y) { this.x = x; this.y = y; this.z = 0f; }
        public float magnitude => 0f;
        public float sqrMagnitude => 0f;
        public Vector3 normalized => default;
        public static Vector3 zero => default;
        public static Vector3 one => default;
        public static Vector3 up => default;
        public static Vector3 down => default;
        public static Vector3 left => default;
        public static Vector3 right => default;
        public static Vector3 forward => default;
        public static Vector3 back => default;
        public static float Distance(Vector3 a, Vector3 b) => 0f;
        public static float Dot(Vector3 a, Vector3 b) => 0f;
        public static Vector3 Cross(Vector3 a, Vector3 b) => default;
        public static float Angle(Vector3 a, Vector3 b) => 0f;
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => default;
        public static Vector3 Project(Vector3 vector, Vector3 onNormal) => default;
        public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal) => default;
        public static Vector3 Normalize(Vector3 v) => default;
        public void Normalize() { }
        public static Vector3 operator +(Vector3 a, Vector3 b) => default;
        public static Vector3 operator -(Vector3 a, Vector3 b) => default;
        public static Vector3 operator -(Vector3 a) => default;
        public static Vector3 operator *(Vector3 a, float b) => default;
        public static Vector3 operator *(float a, Vector3 b) => default;
        public static Vector3 operator /(Vector3 a, float b) => default;
        public static bool operator ==(Vector3 a, Vector3 b) => false;
        public static bool operator !=(Vector3 a, Vector3 b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }

    public struct Vector4
    {
        public float x, y, z, w;
        public Vector4(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }
        public static Vector4 zero => default;
    }

    public struct Quaternion
    {
        public float x, y, z, w;
        public Quaternion(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }
        public static Quaternion identity => default;
        public Vector3 eulerAngles { get => default; set { } }
        public static Quaternion Euler(float x, float y, float z) => default;
        public static Quaternion Euler(Vector3 e) => default;
        public static Quaternion Slerp(Quaternion a, Quaternion b, float t) => default;
        public static Quaternion Lerp(Quaternion a, Quaternion b, float t) => default;
        public static Quaternion LookRotation(Vector3 forward) => default;
        public static Quaternion LookRotation(Vector3 forward, Vector3 upwards) => default;
        public static Quaternion AngleAxis(float angle, Vector3 axis) => default;
        public static Quaternion FromToRotation(Vector3 from, Vector3 to) => default;
        public static Quaternion Inverse(Quaternion rotation) => default;
        public static Quaternion operator *(Quaternion a, Quaternion b) => default;
        public static Vector3 operator *(Quaternion rotation, Vector3 point) => default;
    }

    public struct Color
    {
        public float r, g, b, a;
        public Color(float r, float g, float b) { this.r = r; this.g = g; this.b = b; this.a = 1f; }
        public Color(float r, float g, float b, float a) { this.r = r; this.g = g; this.b = b; this.a = a; }
        public static Color white => default;
        public static Color black => default;
        public static Color red => default;
        public static Color green => default;
        public static Color blue => default;
        public static Color yellow => default;
        public static Color cyan => default;
        public static Color magenta => default;
        public static Color gray => default;
        public static Color grey => default;
        public static Color clear => default;
        public static Color Lerp(Color a, Color b, float t) => default;
        public static bool operator ==(Color a, Color b) => false;
        public static bool operator !=(Color a, Color b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }

    public struct Color32
    {
        public byte r, g, b, a;
        public Color32(byte r, byte g, byte b, byte a) { this.r = r; this.g = g; this.b = b; this.a = a; }
    }

    public struct Rect
    {
        public float x, y, width, height;
        public Rect(float x, float y, float width, float height) { this.x = x; this.y = y; this.width = width; this.height = height; }
        public Rect(Vector2 position, Vector2 size) { x = position.x; y = position.y; width = size.x; height = size.y; }
        public float xMin { get => 0f; set { } }
        public float yMin { get => 0f; set { } }
        public float xMax { get => 0f; set { } }
        public float yMax { get => 0f; set { } }
        public Vector2 center => default;
        public Vector2 size { get => default; set { } }
        public Vector2 position { get => default; set { } }
        public bool Contains(Vector2 point) => false;
        public bool Contains(Vector3 point) => false;
    }

    public struct RectInt
    {
        public int x, y, width, height;
    }

    public struct Bounds
    {
        public Vector3 center;
        public Vector3 extents;
        public Vector3 size { get => default; set { } }
        public Vector3 min => default;
        public Vector3 max => default;
        public Bounds(Vector3 center, Vector3 size) { this.center = center; this.extents = default; }
        public void Encapsulate(Bounds b) { }
        public void Encapsulate(Vector3 point) { }
        public bool Contains(Vector3 point) => false;
        public bool Intersects(Bounds bounds) => false;
    }

    public struct Plane
    {
        public Vector3 normal;
        public float distance;
        public Plane(Vector3 normal, float distance) { this.normal = normal; this.distance = distance; }
        public Plane(Vector3 normal, Vector3 point) { this.normal = normal; this.distance = 0f; }
    }

    public struct Matrix4x4
    {
        public static Matrix4x4 identity => default;
        public Vector4 GetColumn(int i) => default;
        public Vector4 GetRow(int i) => default;
        public Matrix4x4 inverse => default;
        public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s) => default;
    }

    public struct LayerMask
    {
        public int value;
        public static implicit operator int(LayerMask m) => m.value;
        public static implicit operator LayerMask(int i) => new LayerMask { value = i };
        public static int GetMask(params string[] layerNames) => 0;
        public static int NameToLayer(string layerName) => 0;
        public static string LayerToName(int layer) => "";
    }

    public struct Ray
    {
        public Vector3 origin;
        public Vector3 direction;
        public Ray(Vector3 origin, Vector3 direction) { this.origin = origin; this.direction = direction; }
        public Vector3 GetPoint(float distance) => default;
    }

    public struct RaycastHit
    {
        public Vector3 point;
        public Vector3 normal;
        public float distance;
        public Collider collider;
        public Transform transform;
        public Rigidbody rigidbody;
        public Vector2 textureCoord;
        public int triangleIndex;
    }

    // ── Math ───────────────────────────────────────────────────────────────────
    public static class Mathf
    {
        public const float Deg2Rad = 0.0174533f;
        public const float Rad2Deg = 57.29578f;
        public const float PI = 3.14159274f;
        public const float Infinity = float.PositiveInfinity;
        public const float NegativeInfinity = float.NegativeInfinity;
        public const float Epsilon = 1.401298E-45f;
        public static float Sqrt(float f) => 0f;
        public static float Abs(float f) => 0f;
        public static int Abs(int i) => 0;
        public static float Sin(float f) => 0f;
        public static float Cos(float f) => 0f;
        public static float Tan(float f) => 0f;
        public static float Asin(float f) => 0f;
        public static float Acos(float f) => 0f;
        public static float Atan(float f) => 0f;
        public static float Atan2(float y, float x) => 0f;
        public static float Exp(float f) => 0f;
        public static float Log(float f) => 0f;
        public static float Log(float f, float p) => 0f;
        public static float Log10(float f) => 0f;
        public static float Pow(float f, float p) => 0f;
        public static float Clamp(float v, float min, float max) => 0f;
        public static int Clamp(int v, int min, int max) => 0;
        public static float Clamp01(float v) => 0f;
        public static float Lerp(float a, float b, float t) => 0f;
        public static float LerpUnclamped(float a, float b, float t) => 0f;
        public static float LerpAngle(float a, float b, float t) => 0f;
        public static float InverseLerp(float a, float b, float v) => 0f;
        public static float Max(float a, float b) => 0f;
        public static float Max(float a, float b, float c) => 0f;
        public static float Max(params float[] values) => 0f;
        public static int Max(int a, int b) => 0;
        public static float Min(float a, float b) => 0f;
        public static float Min(float a, float b, float c) => 0f;
        public static int Min(int a, int b) => 0;
        public static float MoveTowards(float cur, float tgt, float maxDelta) => 0f;
        public static float MoveTowardsAngle(float cur, float tgt, float maxDelta) => 0f;
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime) => 0f;
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed) => 0f;
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime) => 0f;
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime) => 0f;
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed) => 0f;
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime) => 0f;
        public static float DeltaAngle(float cur, float tgt) => 0f;
        public static bool Approximately(float a, float b) => false;
        public static float Sign(float f) => 0f;
        public static float Round(float f) => 0f;
        public static float Ceil(float f) => 0f;
        public static float Floor(float f) => 0f;
        public static int CeilToInt(float f) => 0;
        public static int FloorToInt(float f) => 0;
        public static int RoundToInt(float f) => 0;
        public static int NextPowerOfTwo(int v) => 0;
        public static int ClosestPowerOfTwo(int v) => 0;
        public static bool IsPowerOfTwo(int v) => false;
    }

    public static class Random
    {
        public static float value => 0f;
        public static float Range(float min, float max) => 0f;
        public static int Range(int min, int max) => 0;
        public static Vector3 insideUnitSphere => default;
        public static Vector2 insideUnitCircle => default;
    }

    // ── Time / Screen / Application ────────────────────────────────────────────
    public static class Time
    {
        public static float deltaTime => 0f;
        public static float fixedDeltaTime => 0f;
        public static float unscaledDeltaTime => 0f;
        public static float time => 0f;
        public static double timeAsDouble => 0d;
        public static float unscaledTime => 0f;
        public static float realtimeSinceStartup => 0f;
        public static double realtimeSinceStartupAsDouble => 0d;
        public static int frameCount => 0;
        public static float timeScale { get; set; }
    }

    public static class Screen
    {
        public static int width => 0;
        public static int height => 0;
        public static float dpi => 0f;
    }

    public static class Application
    {
        public static string dataPath => "";
        public static string persistentDataPath => "";
        public static bool isPlaying => false;
        public static string version => "";
    }

    // ── Physics ────────────────────────────────────────────────────────────────
    public static class Physics
    {
        public static Vector3 gravity => default;
        public const int DefaultRaycastLayers = -5;
        public static bool Raycast(Vector3 origin, Vector3 direction) => false;
        public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance) => false;
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo) { hitInfo = default; return false; }
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance) { hitInfo = default; return false; }
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask) { hitInfo = default; return false; }
        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { hitInfo = default; return false; }
        public static bool Raycast(Ray ray, out RaycastHit hitInfo) { hitInfo = default; return false; }
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance) { hitInfo = default; return false; }
        public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask) { hitInfo = default; return false; }
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results) => 0;
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance) => 0;
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask) => 0;
        public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) => 0;
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction) => System.Array.Empty<RaycastHit>();
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance) => System.Array.Empty<RaycastHit>();
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask) => System.Array.Empty<RaycastHit>();
        public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) => System.Array.Empty<RaycastHit>();
        public static bool Linecast(Vector3 start, Vector3 end) => false;
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo) { hitInfo = default; return false; }
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask) { hitInfo = default; return false; }
        public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { hitInfo = default; return false; }
        // Stub for ContactModifyEvent reference (used as type ref only)
        public class ContactModifyEvent { }
    }

    // ── Object hierarchy ───────────────────────────────────────────────────────
    public class Object
    {
        public string name { get; set; } = "";
        public HideFlags hideFlags { get; set; }
        public int GetInstanceID() => 0;
        public override string ToString() => "";
        public static implicit operator bool(Object o) => false;
        public static bool operator ==(Object a, Object b) => false;
        public static bool operator !=(Object a, Object b) => false;
        public override bool Equals(object other) => false;
        public override int GetHashCode() => 0;

        public static T FindObjectOfType<T>() where T : Object => null;
        public static T[] FindObjectsOfType<T>() where T : Object => System.Array.Empty<T>();
        public static Object FindObjectOfType(Type t) => null;
        public static Object[] FindObjectsOfType(Type t) => System.Array.Empty<Object>();
        public static T FindFirstObjectByType<T>() where T : Object => null;
        public static Object FindFirstObjectByType(Type type) => null;
        public static T[] FindObjectsByType<T>(FindObjectsSortMode sortMode) where T : Object => System.Array.Empty<T>();
        public static T[] FindObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Object => System.Array.Empty<T>();
        public static Object[] FindObjectsByType(Type type, FindObjectsSortMode sortMode) => System.Array.Empty<Object>();
        public static Object[] FindObjectsByType(Type type, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) => System.Array.Empty<Object>();
        public static void DontDestroyOnLoad(Object o) { }
        public static void Destroy(Object o) { }
        public static void Destroy(Object o, float t) { }
        public static void DestroyImmediate(Object o) { }
        public static T Instantiate<T>(T original) where T : Object => null;
        public static T Instantiate<T>(T original, Transform parent) where T : Object => null;
    }

    public class Component : Object
    {
        public Transform transform => null;
        public GameObject gameObject => null;
        public string tag { get; set; } = "";
        public T GetComponent<T>() => default;
        public Component GetComponent(Type t) => null;
        public Component GetComponent(string t) => null;
        public T GetComponentInParent<T>() => default;
        public Component GetComponentInParent(Type t) => null;
        public T GetComponentInChildren<T>() => default;
        public Component GetComponentInChildren(Type t) => null;
        public T[] GetComponents<T>() => System.Array.Empty<T>();
        public Component[] GetComponents(Type t) => System.Array.Empty<Component>();
        public T[] GetComponentsInChildren<T>() => System.Array.Empty<T>();
        public Component[] GetComponentsInChildren(Type t) => System.Array.Empty<Component>();
        public T[] GetComponentsInParent<T>() => System.Array.Empty<T>();
    }

    public class Transform : Component, IEnumerable
    {
        public Vector3 position { get; set; }
        public Vector3 localPosition { get; set; }
        public Vector3 eulerAngles { get; set; }
        public Vector3 localEulerAngles { get; set; }
        public Quaternion rotation { get; set; }
        public Quaternion localRotation { get; set; }
        public Vector3 forward { get; set; }
        public Vector3 right { get; set; }
        public Vector3 up { get; set; }
        public Vector3 lossyScale => default;
        public Vector3 localScale { get; set; }
        public Transform parent { get; set; }
        public Transform root => null;
        public int childCount => 0;
        public Transform GetChild(int i) => null;
        public Transform Find(string name) => null;
        public void SetParent(Transform p) { }
        public void SetParent(Transform p, bool worldPositionStays) { }
        public Vector3 TransformPoint(Vector3 position) => default;
        public Vector3 TransformDirection(Vector3 direction) => default;
        public Vector3 InverseTransformPoint(Vector3 position) => default;
        public Vector3 InverseTransformDirection(Vector3 direction) => default;
        public void LookAt(Transform target) { }
        public void LookAt(Vector3 worldPosition) { }
        public void Rotate(Vector3 eulerAngles) { }
        public void Translate(Vector3 translation) { }
        public bool IsChildOf(Transform parent) => false;
        public IEnumerator GetEnumerator() => null;
    }

    public class GameObject : Object
    {
        public GameObject() { }
        public GameObject(string name) { this.name = name; }
        public GameObject(string name, params Type[] components) { this.name = name; }
        public Transform transform => null;
        public bool activeSelf => true;
        public bool activeInHierarchy => true;
        public int layer { get; set; }
        public Scene scene => default;
        public void SetActive(bool v) { }
        public T AddComponent<T>() where T : Component => null;
        public Component AddComponent(Type t) => null;
        public T GetComponent<T>() => default;
        public Component GetComponent(Type t) => null;
        public Component GetComponent(string t) => null;
        public T GetComponentInChildren<T>() => default;
        public T GetComponentInParent<T>() => default;
        public T[] GetComponents<T>() => System.Array.Empty<T>();
        public T[] GetComponentsInChildren<T>() => System.Array.Empty<T>();
    }

    public struct Scene { }

    public class Behaviour : Component
    {
        public bool enabled { get; set; }
        public bool isActiveAndEnabled => true;
    }

    public class MonoBehaviour : Behaviour
    {
        public Coroutine StartCoroutine(IEnumerator routine) => null;
        public Coroutine StartCoroutine(string methodName) => null;
        public Coroutine StartCoroutine(string methodName, object value) => null;
        public void StopCoroutine(Coroutine c) { }
        public void StopCoroutine(IEnumerator routine) { }
        public void StopAllCoroutines() { }
        public void Invoke(string methodName, float time) { }
        public void InvokeRepeating(string methodName, float time, float repeatRate) { }
        public void CancelInvoke() { }
    }

    public class ScriptableObject : Object { }
    public class Coroutine : YieldInstruction { }
    public class YieldInstruction { }
    public class WaitForSeconds : YieldInstruction { public WaitForSeconds(float seconds) { } }
    public class WaitForEndOfFrame : YieldInstruction { }
    public class WaitForFixedUpdate : YieldInstruction { }
    public class CustomYieldInstruction : IEnumerator { public virtual bool keepWaiting => false; public object Current => null; public bool MoveNext() => false; public void Reset() { } }

    // ── Camera ─────────────────────────────────────────────────────────────────
    public class Camera : Behaviour
    {
        public static Camera main => null;
        public static Camera current => null;
        public static event Action<Camera> onPreRender;
        public static event Action<Camera> onPostRender;
        public bool orthographic { get; set; }
        public float orthographicSize { get; set; }
        public float fieldOfView { get; set; }
        public float nearClipPlane { get; set; }
        public float farClipPlane { get; set; }
        public float depth { get; set; }
        public CameraClearFlags clearFlags { get; set; }
        public Color backgroundColor { get; set; }
        public int cullingMask { get; set; }
        public bool allowHDR { get; set; }
        public bool allowMSAA { get; set; }
        public bool useOcclusionCulling { get; set; }
        public DepthTextureMode depthTextureMode { get; set; }
        public RenderingPath renderingPath { get; set; }
        public RenderTexture targetTexture { get; set; }
        public Vector3 WorldToScreenPoint(Vector3 position) => default;
        public Vector3 WorldToViewportPoint(Vector3 position) => default;
        public Vector3 ScreenToWorldPoint(Vector3 position) => default;
        public Ray ScreenPointToRay(Vector3 pos) => default;
        public Matrix4x4 projectionMatrix { get; set; }
        public Matrix4x4 worldToCameraMatrix { get; set; }
        public void Render() { }
    }

    // ── Renderer hierarchy ─────────────────────────────────────────────────────
    public class Renderer : Component
    {
        public Bounds bounds => default;
        public bool enabled { get; set; }
        public Material material { get; set; }
        public Material[] materials { get; set; }
        public Material sharedMaterial { get; set; }
        public Material[] sharedMaterials { get; set; }
        public bool receiveShadows { get; set; }
        public Rendering.ShadowCastingMode shadowCastingMode { get; set; }
        public int sortingOrder { get; set; }
    }

    public class MeshRenderer : Renderer { }
    public class MeshFilter : Component { public Mesh mesh { get; set; } public Mesh sharedMesh { get; set; } }
    public class Mesh : Object { }
    public class Material : Object
    {
        public Material(Shader shader) { }
        public Material(Material source) { }
        public Color color { get; set; }
        public Shader shader { get; set; }
        public int renderQueue { get; set; }
        public Texture mainTexture { get; set; }
        public bool HasProperty(string name) => false;
        public bool HasProperty(int nameID) => false;
        public void SetInt(string name, int value) { }
        public void SetFloat(string name, float value) { }
        public void SetColor(string name, Color value) { }
        public void SetVector(string name, Vector4 value) { }
        public void SetTexture(string name, Texture value) { }
        public float GetFloat(string name) => 0f;
        public Color GetColor(string name) => default;
    }

    public class Shader : Object
    {
        public static Shader Find(string name) => null;
    }

    public class Texture : Object
    {
        public int width => 0;
        public int height => 0;
        public FilterMode filterMode { get; set; }
        public TextureWrapMode wrapMode { get; set; }
    }

    public class Texture2D : Texture
    {
        public Texture2D(int width, int height) { }
        public Texture2D(int width, int height, TextureFormat format, bool mipChain) { }
        public Texture2D(int width, int height, TextureFormat format, bool mipChain, bool linear) { }
        public void SetPixel(int x, int y, Color color) { }
        public void SetPixels(Color[] colors) { }
        public void SetPixels(Color[] colors, int miplevel) { }
        public Color GetPixel(int x, int y) => default;
        public void Apply() { }
        public void Apply(bool updateMipmaps) { }
        public void Apply(bool updateMipmaps, bool makeNoLongerReadable) { }
    }

    public class RenderTexture : Texture
    {
        public RenderTexture(int width, int height, int depth) { }
        public new int width { get; set; }
        public new int height { get; set; }
        public int antiAliasing { get; set; }
        public bool Create() => false;
        public void Release() { }
    }

    public class Sprite : Object { }
    public class Light : Behaviour { }

    public class LineRenderer : Renderer
    {
        public int positionCount { get; set; }
        public float startWidth { get; set; }
        public float endWidth { get; set; }
        public Color startColor { get; set; }
        public Color endColor { get; set; }
        public Gradient colorGradient { get; set; }
        public bool useWorldSpace { get; set; }
        public int numCornerVertices { get; set; }
        public int numCapVertices { get; set; }
        public bool loop { get; set; }
        public LineAlignment alignment { get; set; }
        public LineTextureMode textureMode { get; set; }
        public void SetPosition(int index, Vector3 position) { }
        public void SetPositions(Vector3[] positions) { }
        public Vector3 GetPosition(int index) => default;
    }

    public class Gradient
    {
        public GradientColorKey[] colorKeys { get; set; }
        public GradientAlphaKey[] alphaKeys { get; set; }
        public GradientMode mode { get; set; }
        public Color Evaluate(float time) => default;
        public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys) { }
    }
    public struct GradientColorKey { public Color color; public float time; public GradientColorKey(Color col, float time) { color = col; this.time = time; } }
    public struct GradientAlphaKey { public float alpha; public float time; public GradientAlphaKey(float alpha, float time) { this.alpha = alpha; this.time = time; } }

    public struct Keyframe
    {
        public float time;
        public float value;
        public float inTangent;
        public float outTangent;
        public Keyframe(float time, float value) { this.time = time; this.value = value; inTangent = 0f; outTangent = 0f; }
    }

    public class AnimationCurve
    {
        public Keyframe[] keys { get; set; }
        public int length => 0;
        public AnimationCurve() { }
        public AnimationCurve(params Keyframe[] keys) { this.keys = keys; }
        public float Evaluate(float time) => 0f;
        public int AddKey(float time, float value) => 0;
        public int AddKey(Keyframe key) => 0;
        public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public static AnimationCurve Constant(float timeStart, float timeEnd, float value) => new AnimationCurve();
    }

    // ── Colliders / Physics components ─────────────────────────────────────────
    public enum PhysicsMaterialCombine { Average, Minimum, Multiply, Maximum }
    // Pre-6.0 Unity kept the old name. Some reflected code still references it.
    public enum PhysicMaterialCombine { Average, Minimum, Multiply, Maximum }

    public class PhysicsMaterial : Object
    {
        public float dynamicFriction { get; set; }
        public float staticFriction { get; set; }
        public float bounciness { get; set; }
        public PhysicsMaterialCombine bounceCombine { get; set; }
        public PhysicsMaterialCombine frictionCombine { get; set; }
    }

    // Alias the pre-6.0 Unity name kept around for backwards-compat.
    public class PhysicMaterial : PhysicsMaterial { }

    public class Collider : Component
    {
        public Bounds bounds => default;
        public bool enabled { get; set; }
        public bool isTrigger { get; set; }
        public Rigidbody attachedRigidbody => null;
        public PhysicsMaterial material { get; set; }
        public PhysicsMaterial sharedMaterial { get; set; }
    }
    public class BoxCollider : Collider { public Vector3 center { get; set; } public Vector3 size { get; set; } }
    public class SphereCollider : Collider { public Vector3 center { get; set; } public float radius { get; set; } }
    public class CapsuleCollider : Collider { public Vector3 center { get; set; } public float radius { get; set; } public float height { get; set; } }
    public class MeshCollider : Collider { public Mesh sharedMesh { get; set; } }
    public class CharacterController : Collider
    {
        public Vector3 center { get; set; }
        public float radius { get; set; }
        public float height { get; set; }
        public bool isGrounded => false;
    }
    public class Rigidbody : Component
    {
        public Vector3 velocity { get; set; }
        public Vector3 linearVelocity { get; set; }
        public Vector3 angularVelocity { get; set; }
        public float mass { get; set; }
        public float drag { get; set; }
        public bool useGravity { get; set; }
        public bool isKinematic { get; set; }
        public void AddForce(Vector3 force) { }
    }

    public class SkinnedMeshRenderer : Renderer
    {
        public Mesh sharedMesh { get; set; }
        public bool updateWhenOffscreen { get; set; }
    }

    // ── Geometry / Frustum ────────────────────────────────────────────────────
    public static class GeometryUtility
    {
        public static void CalculateFrustumPlanes(Camera camera, Plane[] planes) { }
        public static Plane[] CalculateFrustumPlanes(Camera camera) => System.Array.Empty<Plane>();
        public static bool TestPlanesAABB(Plane[] planes, Bounds bounds) => false;
    }

    // ── Font / Text rendering ──────────────────────────────────────────────────
    public class Font : Object
    {
        public Font() { }
        public Font(string name) { }
        public static Font CreateDynamicFontFromOSFont(string fontName, int size) => null;
        public static Font CreateDynamicFontFromOSFont(string[] fontNames, int size) => null;
        public static string[] GetOSInstalledFontNames() => System.Array.Empty<string>();
    }

    // ── IMGUI ──────────────────────────────────────────────────────────────────
    public class GUIStyleState
    {
        public Color textColor { get; set; }
        public Texture2D background { get; set; }
    }

    public class RectOffset
    {
        public int left, right, top, bottom;
        public RectOffset() { }
        public RectOffset(int left, int right, int top, int bottom) { this.left = left; this.right = right; this.top = top; this.bottom = bottom; }
        public int horizontal => 0;
        public int vertical => 0;
    }

    public class GUIStyle
    {
        public GUIStyle() { }
        public GUIStyle(GUIStyle other) { }
        public Font font { get; set; }
        public int fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
        public bool wordWrap { get; set; }
        public bool richText { get; set; }
        public TextAnchor alignment { get; set; }
        public RectOffset padding { get; set; } = new RectOffset();
        public RectOffset margin { get; set; } = new RectOffset();
        public RectOffset border { get; set; } = new RectOffset();
        public RectOffset overflow { get; set; } = new RectOffset();
        public Vector2 contentOffset { get; set; }
        public float fixedWidth { get; set; }
        public float fixedHeight { get; set; }
        public bool stretchHeight { get; set; }
        public bool stretchWidth { get; set; }
        public GUIStyleState normal { get; set; } = new GUIStyleState();
        public GUIStyleState hover { get; set; } = new GUIStyleState();
        public GUIStyleState active { get; set; } = new GUIStyleState();
        public GUIStyleState focused { get; set; } = new GUIStyleState();
        public GUIStyleState onNormal { get; set; } = new GUIStyleState();
        public GUIStyleState onHover { get; set; } = new GUIStyleState();
        public GUIStyleState onActive { get; set; } = new GUIStyleState();
        public Vector2 CalcSize(GUIContent content) => default;
        public float CalcHeight(GUIContent content, float width) => 0f;
    }

    public class GUIContent
    {
        public static GUIContent none { get; } = new GUIContent();
        public string text { get; set; }
        public string tooltip { get; set; }
        public Texture image { get; set; }
        public GUIContent() { }
        public GUIContent(string text) { this.text = text; }
        public GUIContent(string text, string tooltip) { this.text = text; this.tooltip = tooltip; }
        public GUIContent(Texture image) { this.image = image; }
    }

    public class GUISkin : ScriptableObject
    {
        public GUIStyle box { get; set; } = new GUIStyle();
        public GUIStyle label { get; set; } = new GUIStyle();
        public GUIStyle button { get; set; } = new GUIStyle();
        public GUIStyle toggle { get; set; } = new GUIStyle();
        public GUIStyle window { get; set; } = new GUIStyle();
        public GUIStyle textField { get; set; } = new GUIStyle();
        public GUIStyle textArea { get; set; } = new GUIStyle();
        public GUIStyle horizontalSlider { get; set; } = new GUIStyle();
        public GUIStyle horizontalSliderThumb { get; set; } = new GUIStyle();
        public GUIStyle verticalSlider { get; set; } = new GUIStyle();
        public GUIStyle verticalSliderThumb { get; set; } = new GUIStyle();
        public GUIStyle horizontalScrollbar { get; set; } = new GUIStyle();
        public GUIStyle verticalScrollbar { get; set; } = new GUIStyle();
        public Font font { get; set; }
    }

    public delegate void WindowFunction(int id);

    public static class GUI
    {
        public static Color color { get; set; }
        public static Color contentColor { get; set; }
        public static Color backgroundColor { get; set; }
        public static GUISkin skin { get; set; } = new GUISkin();
        public static Matrix4x4 matrix { get; set; }
        public static int depth { get; set; }
        public static bool enabled { get; set; }
        public static void Box(Rect position, GUIContent content, GUIStyle style) { }
        public static void Box(Rect position, string text) { }
        public static void Box(Rect position, string text, GUIStyle style) { }
        public static void Box(Rect position, GUIContent content) { }
        public static void Label(Rect position, string text) { }
        public static void Label(Rect position, GUIContent content) { }
        public static void Label(Rect position, string text, GUIStyle style) { }
        public static void Label(Rect position, GUIContent content, GUIStyle style) { }
        public static bool Button(Rect position, string text) => false;
        public static bool Button(Rect position, GUIContent content) => false;
        public static bool Button(Rect position, string text, GUIStyle style) => false;
        public static bool Button(Rect position, GUIContent content, GUIStyle style) => false;
        public static bool RepeatButton(Rect position, string text) => false;
        public static bool Toggle(Rect position, bool value, string text) => false;
        public static bool Toggle(Rect position, bool value, GUIContent content, GUIStyle style) => false;
        public static string TextField(Rect position, string text) => "";
        public static string TextField(Rect position, string text, GUIStyle style) => "";
        public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue) => 0f;
        public static void DrawTexture(Rect position, Texture image) { }
        public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode) { }
        public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend) { }
        public static void BeginGroup(Rect position) { }
        public static void EndGroup() { }
        public static Rect Window(int id, Rect clientRect, WindowFunction func, string text) => default;
        public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent content) => default;
        public static Rect Window(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style) => default;
        public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style) => default;
        public static void DragWindow() { }
        public static void DragWindow(Rect position) { }
        public static void BringWindowToFront(int windowID) { }
        public static void FocusWindow(int windowID) { }
    }

    public static class GUILayout
    {
        public static void BeginArea(Rect screenRect) { }
        public static void BeginArea(Rect screenRect, GUIStyle style) { }
        public static void EndArea() { }
        public static void BeginHorizontal(params GUILayoutOption[] options) { }
        public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options) { }
        public static void EndHorizontal() { }
        public static void BeginVertical(params GUILayoutOption[] options) { }
        public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options) { }
        public static void EndVertical() { }
        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) => default;
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options) => default;
        public static void EndScrollView() { }
        public static void Box(string text, params GUILayoutOption[] options) { }
        public static void Box(GUIContent content, params GUILayoutOption[] options) { }
        public static void Box(string text, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Box(GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label(string text, params GUILayoutOption[] options) { }
        public static void Label(GUIContent content, params GUILayoutOption[] options) { }
        public static void Label(string text, GUIStyle style, params GUILayoutOption[] options) { }
        public static void Label(GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }
        public static bool Button(string text, params GUILayoutOption[] options) => false;
        public static bool Button(GUIContent content, params GUILayoutOption[] options) => false;
        public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options) => false;
        public static bool Button(GUIContent content, GUIStyle style, params GUILayoutOption[] options) => false;
        public static bool Toggle(bool value, string text, params GUILayoutOption[] options) => false;
        public static bool Toggle(bool value, GUIContent content, GUIStyle style, params GUILayoutOption[] options) => false;
        public static bool Toggle(bool value, string text, GUIStyle style, params GUILayoutOption[] options) => false;
        public static float HorizontalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options) => 0f;
        public static void Space(float pixels) { }
        public static void FlexibleSpace() { }
        public static GUILayoutOption Width(float width) => null;
        public static GUILayoutOption Height(float height) => null;
        public static GUILayoutOption MinWidth(float minWidth) => null;
        public static GUILayoutOption MaxWidth(float maxWidth) => null;
        public static GUILayoutOption MinHeight(float minHeight) => null;
        public static GUILayoutOption MaxHeight(float maxHeight) => null;
        public static GUILayoutOption ExpandWidth(bool expand) => null;
        public static GUILayoutOption ExpandHeight(bool expand) => null;
    }

    public class GUILayoutOption { }

    public static class GUIUtility
    {
        public static void RotateAroundPivot(float angle, Vector2 pivotPoint) { }
        public static int hotControl { get; set; }
        public static int keyboardControl { get; set; }
    }

    public static class GUILayoutUtility
    {
        public static Rect GetRect(float width, float height) => default;
        public static Rect GetRect(float width, float height, params GUILayoutOption[] options) => default;
        public static Rect GetRect(float width, float height, GUIStyle style) => default;
        public static Rect GetRect(float width, float height, GUIStyle style, params GUILayoutOption[] options) => default;
        public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight) => default;
        public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, params GUILayoutOption[] options) => default;
        public static Rect GetRect(GUIContent content, GUIStyle style) => default;
        public static Rect GetRect(GUIContent content, GUIStyle style, params GUILayoutOption[] options) => default;
        public static Rect GetLastRect() => default;
    }

    public static class ColorUtility
    {
        public static bool TryParseHtmlString(string htmlString, out Color color) { color = default; return false; }
        public static string ToHtmlStringRGB(Color color) => "";
        public static string ToHtmlStringRGBA(Color color) => "";
    }

    public class Event
    {
        public static Event current => null;
        public EventType type { get; set; }
        public Vector2 mousePosition { get; set; }
        public int button { get; set; }
        public bool shift { get; set; }
        public bool control { get; set; }
        public bool alt { get; set; }
        public KeyCode keyCode { get; set; }
        public void Use() { }
    }

    public enum KeyCode { None = 0, Space = 32, Escape = 27, Return = 13 }

    public static class Cursor
    {
        public static bool visible { get; set; }
        public static CursorLockMode lockState { get; set; }
    }

    public enum CursorLockMode { None, Locked, Confined }

    public static class Debug
    {
        public static void Log(object message) { }
        public static void LogWarning(object message) { }
        public static void LogError(object message) { }
        public static void DrawLine(Vector3 a, Vector3 b) { }
        public static void DrawLine(Vector3 a, Vector3 b, Color color) { }
        public static void DrawRay(Vector3 origin, Vector3 dir, Color color) { }
    }

    public static class Resources
    {
        public static T Load<T>(string path) where T : Object => null;
        public static Object Load(string path) => null;
        public static T[] FindObjectsOfTypeAll<T>() => System.Array.Empty<T>();
    }
}

namespace UnityEngine.Rendering
{
    public enum CompareFunction
    {
        Disabled = 0, Never = 1, Less = 2, Equal = 3, LessEqual = 4,
        Greater = 5, NotEqual = 6, GreaterEqual = 7, Always = 8,
    }

    public enum ShadowCastingMode
    {
        Off = 0, On = 1, TwoSided = 2, ShadowsOnly = 3,
    }
}

namespace UnityEngine.SceneManagement
{
    public static class SceneManager
    {
        public static Scene GetActiveScene() => default;
    }
}

namespace UnityEngine.UI
{
    public class Graphic : Behaviour
    {
        public Color color { get; set; }
        public bool raycastTarget { get; set; }
        public Material material { get; set; }
    }

    public class Image : Graphic
    {
        public Sprite sprite { get; set; }
    }

    public class RawImage : Graphic
    {
        public Texture texture { get; set; }
    }

    public class Canvas : Behaviour
    {
        public RenderMode renderMode { get; set; }
        public int sortingOrder { get; set; }
        public Camera worldCamera { get; set; }
        public float planeDistance { get; set; }
        public bool overrideSorting { get; set; }
    }

    public class CanvasScaler : Behaviour
    {
        public enum ScaleMode { ConstantPixelSize, ScaleWithScreenSize, ConstantPhysicalSize }
        public enum ScreenMatchMode { MatchWidthOrHeight, Expand, Shrink }
        public ScaleMode uiScaleMode { get; set; }
        public Vector2 referenceResolution { get; set; }
        public ScreenMatchMode screenMatchMode { get; set; }
        public float matchWidthOrHeight { get; set; }
    }

    public class GraphicRaycaster : Behaviour { }

    public class RectTransform : Transform
    {
        public Vector2 anchorMin { get; set; }
        public Vector2 anchorMax { get; set; }
        public Vector2 anchoredPosition { get; set; }
        public Vector2 offsetMin { get; set; }
        public Vector2 offsetMax { get; set; }
        public Vector2 sizeDelta { get; set; }
        public Vector2 pivot { get; set; }
        public Rect rect => default;
    }
}
