using ElmSharp;
using System.IO;

namespace Tizen.NET.MaterialComponents
{
    public class MMenus : ContextPopup, IColorSchemeComponent, IOptionalComponent
    {
        public MMenus(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            Style = Styles.Material;
            IsHorizontal = false;
            AutoHide = true;
            MColors.AddColorSchemeComponent(this);
        }
        public TargetProfile SupportedProfiles => TargetProfile.Mobile;

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            // TBD : if support additional themes, may need to change the color of the item text.
        }
    }
}
