// Compile-time stubs for UnityEngine.UI types used by SuperHackerGolf.

using UnityEngine;

#pragma warning disable CS0626, CS0649, CS8618, CS8625

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
}
