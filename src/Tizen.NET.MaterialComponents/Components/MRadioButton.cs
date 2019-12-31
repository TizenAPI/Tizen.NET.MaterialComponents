using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MRadioButton : Radio, IColorSchemeComponent, IOptionalComponent
    {
        Color _defaultIcon;
        Color _defaultIconForDisable;

        public MRadioButton(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            Style = Styles.RadioButton.Style;
            MColors.AddColorSchemeComponent(this);
        }

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.Wearable;

        public override Color Color
        {
            get
            {
                return GetPartColor(Parts.Radio.Icon);
            }
            set
            {
                SetPartColor(Parts.Radio.Icon, value);
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || this.Color == _defaultIcon;
            
            _defaultIcon = MColors.Current.PrimaryColor;
            _defaultIconForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.38);
            
            if (isDefaultBackground)
            {
                this.Color = _defaultIcon;
            }
            SetPartColor(Parts.Radio.IconDisabled, _defaultIconForDisable);
        }
    }
}
