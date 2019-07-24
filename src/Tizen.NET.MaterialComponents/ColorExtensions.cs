using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public static class ColorExtensions
    {
        public static Color Blending(this Color color, Color blendingColor, int density = 80)
        {
            var r = color.R + (blendingColor.R - color.R) * density / 100;
            var g = color.G + (blendingColor.G - color.G) * density / 100;
            var b = color.B + (blendingColor.B - color.B) * density / 100;

            return new Color(r, g, b);
        }

        public static Color WithAlpha(this Color color, double alpha)
        {
            return new Color(color.R, color.G, color.B, (int)(255 * alpha));
        }

        public static string ToHex(this Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
