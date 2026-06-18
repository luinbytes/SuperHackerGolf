// Compile-time stubs for TextMeshPro types used by SuperHackerGolf.

using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0626, CS0649, CS8618, CS8625

namespace TMPro
{
    public enum TextAlignmentOptions
    {
        TopLeft = 257, Top = 258, TopRight = 260, TopJustified = 264, TopFlush = 272, TopGeoAligned = 288,
        Left = 513, Center = 514, Right = 516, Justified = 520, Flush = 528, CenterGeoAligned = 544,
        BottomLeft = 1025, Bottom = 1026, BottomRight = 1028, BottomJustified = 1032, BottomFlush = 1040, BottomGeoAligned = 1056,
        BaselineLeft = 2049, Baseline = 2050, BaselineRight = 2052, BaselineJustified = 2056, BaselineFlush = 2064, BaselineGeoAligned = 2080,
        MidlineLeft = 4097, Midline = 4098, MidlineRight = 4100, MidlineJustified = 4104, MidlineFlush = 4112, MidlineGeoAligned = 4128,
        CaplineLeft = 8193, Capline = 8194, CaplineRight = 8196, CaplineJustified = 8200, CaplineFlush = 8208, CaplineGeoAligned = 8224,
        Converted = 65535,
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
