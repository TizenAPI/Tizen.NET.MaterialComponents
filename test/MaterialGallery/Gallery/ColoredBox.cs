using System;
using System.Collections.Generic;
using ElmSharp;
using ElmSharp.Wearable;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public class ColoredBox : Box, IColorSchemeComponent
    {
        public ColoredBox(EvasObject parent) : base(parent)
        {
            AlignmentX = -1;
            AlignmentY = -1;
            WeightX = 1;
            WeightY = 1;
            
            OnColorSchemeChanged(true);
            MColors.AddColorSchemeComponent(this);
        }

        public void OnColorSchemeChanged(bool fromConstructor = false)
        {
            BackgroundColor = MColors.Current.SurfaceColor;
        }
    }
}
