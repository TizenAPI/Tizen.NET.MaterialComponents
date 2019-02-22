using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public static class ColorExtensions
    {
        internal static Color Blending(this Color color, Color blendingColor, int density = 80)
        {
            var r = color.R + (blendingColor.R - color.R) * density / 100;
            var g = color.G + (blendingColor.G - color.G) * density / 100;
            var b = color.B + (blendingColor.B - color.B) * density / 100;

            return new Color(r, g, b);
        }
    }
}
