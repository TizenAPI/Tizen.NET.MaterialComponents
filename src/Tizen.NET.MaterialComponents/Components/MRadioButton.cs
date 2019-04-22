using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MRadioButton : Radio, IColorSchemeComponent
    {
        Color _defaultIcon;
        Color _defaultIconForDisable;

        public MRadioButton(EvasObject parent) : base(parent)
        {
            Style = Styles.RadioButton.Style;
            MColors.AddColorSchemeComponent(this);
        }

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
            _defaultIconForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.32);            
            
            if (isDefaultBackground)
            {
                this.Color = _defaultIcon;
            }
            SetPartColor(Parts.Radio.IconDisabled, _defaultIconForDisable);
        }
    }
}
