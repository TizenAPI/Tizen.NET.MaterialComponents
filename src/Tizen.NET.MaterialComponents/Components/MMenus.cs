using ElmSharp;
using System.IO;

namespace Tizen.NET.MaterialComponents
{
    public class MMenus : ContextPopup, IColorSchemeComponent
    {
        public MMenus(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            IsHorizontal = false;
            AutoHide = true;
            MColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            // TBD : if support additional themes, may need to change the color of the item text.
        }
    }
}
