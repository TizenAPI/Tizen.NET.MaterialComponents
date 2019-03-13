using System;
using System.Collections.Generic;
using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public class ColoredBox : Box, IColorSchemeComponent
    {
        public ColoredBox(EvasObject parent) : base(parent)
        {
            OnColorSchemeChanged(true);
            MatrialColors.AddColorSchemeComponent(this);
        }

        public void OnColorSchemeChanged(bool fromConstructor = false)
        {
            BackgroundColor = MatrialColors.Current.SurfaceColor;
        }
    }
}
