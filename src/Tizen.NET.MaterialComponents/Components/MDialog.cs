using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public abstract class MDialog : MPopup, IOptionalComponent
    {
        public MDialog(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            AlignmentX = 0.5;
            AlignmentY = 0.5;
        }

        public TargetProfile SupportedProfiles => TargetProfile.Mobile;
    }
}
