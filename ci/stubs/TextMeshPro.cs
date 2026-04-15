// Compile-time stubs for TextMeshPro types used by SuperHackerGolf.

using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0626, CS0649, CS8618, CS8625

namespace TMPro
{
    public enum TextAlignmentOptions
    {
        TopLeft, Top, TopRight, TopJustified, TopFlush, TopGeoAligned,
        Left, Center, Right, Justified, Flush, CenterGeoAligned,
        BottomLeft, Bottom, BottomRight, BottomJustified, BottomFlush, BottomGeoAligned,
        BaselineLeft, Baseline, BaselineRight, BaselineJustified, BaselineFlush, BaselineGeoAligned,
        MidlineLeft, Midline, MidlineRight, MidlineJustified, MidlineFlush, MidlineGeoAligned,
        CaplineLeft, Capline, CaplineRight, CaplineJustified, CaplineFlush, CaplineGeoAligned,
        Converted = 255,
    }

    public enum TextWrappingModes { NoWrap, Normal, PreserveWhitespace, PreserveWhitespaceNoWrap }
    public enum TextOverflowModes { Overflow, Ellipsis, Masking, Truncate, ScrollRect, Page, Linked }
    public enum FontStyles { Normal = 0, Bold = 1, Italic = 2, Underline = 4, LowerCase = 8, UpperCase = 16, SmallCaps = 32, Strikethrough = 64, Superscript = 128, Subscript = 256, Highlight = 512 }

    public class TMP_Text : Graphic
    {
        public string text { get; set; }
        public int fontSize { get; set; }
        public TextAlignmentOptions alignment { get; set; }
        public bool richText { get; set; }
        public TextWrappingModes textWrappingMode { get; set; }
        public TextOverflowModes overflowMode { get; set; }
        public FontStyles fontStyle { get; set; }
        public Color outlineColor { get; set; }
        public float outlineWidth { get; set; }
        public bool enableAutoSizing { get; set; }
        public float fontSizeMin { get; set; }
        public float fontSizeMax { get; set; }
    }

    public class TextMeshProUGUI : TMP_Text { }
    public class TextMeshPro : TMP_Text { }
}
