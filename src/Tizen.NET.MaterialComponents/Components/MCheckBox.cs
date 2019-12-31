using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MCheckBox : Check, IColorSchemeComponent, IOptionalComponent
    {
        Color _defaultBackground;
        Color _defaultBackgroundForDisable;

        public MCheckBox(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);
            Style = Styles.CheckBox.Style;
            MColors.AddColorSchemeComponent(this);
        }

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.Wearable;

        public override Color Color
        {
            get
            {
                return GetPartColor(Parts.Check.BackgroundOn);
            }
            set
            {
                SetPartColor(Parts.Check.BackgroundOn, value);
                SetPartColor(Parts.Check.Stroke, value);
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || this.Color == _defaultBackground;
            
            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultBackgroundForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.38);

            if (isDefaultBackground)
            {
                this.Color = _defaultBackground;
            }
            SetPartColor(Parts.Check.BackgroundOnDisabled, _defaultBackgroundForDisable);
            SetPartColor(Parts.Check.StrokeDisabled, _defaultBackgroundForDisable);
        }
    }
}
