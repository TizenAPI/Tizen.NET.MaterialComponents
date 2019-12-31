using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public static class MTooltip
    {
        public static void UseMTooltip(this EvasObject control)
        {
            MaterialComponents.VerifyServiceEnabled((TargetProfile.Mobile | TargetProfile.Wearable));

            if(control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.TooltipStyle = Styles.Material;
            control.TooltipOrientation = TooltipOrientation.Bottom;
        }

        public static bool IsUsingMTooltip(this EvasObject control)
        {
            MaterialComponents.VerifyServiceEnabled((TargetProfile.Mobile | TargetProfile.Wearable));

            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return control.TooltipStyle == Styles.Material && control.TooltipOrientation == TooltipOrientation.Bottom;
        }
    }
}
