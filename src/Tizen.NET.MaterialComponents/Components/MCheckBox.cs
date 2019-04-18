using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MCheckBox : Check, IColorSchemeComponent
    {
        Color _defaultBackground;
        Color _defaultBackgroundForDisable;

        public MCheckBox(EvasObject parent) : base(parent)
        {
            Style = Styles.CheckBox.Style;
            MColors.AddColorSchemeComponent(this);
        }

        public override Color Color
        {
            get
            {
                return GetPartColor(Parts.Check.Background);
            }
            set
            {
                SetPartColor(Parts.Check.Background, value);
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || this.Color == _defaultBackground;
            
            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultBackgroundForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.32);

            if (isDefaultBackground)
            {
                this.Color = _defaultBackground;
            }
            SetPartColor(Parts.Check.BackgroundDisabled, _defaultBackgroundForDisable);
        }
    }
}
