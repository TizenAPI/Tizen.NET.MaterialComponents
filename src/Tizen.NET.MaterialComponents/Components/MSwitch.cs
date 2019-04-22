using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSwitch: Check, IColorSchemeComponent
    {
        Color _defaultShapeOn;

        public MSwitch(EvasObject parent) : base(parent)
        {
            Style = Styles.Switch.Style;
            MColors.AddColorSchemeComponent(this);
        }

        public override Color Color
        {
            get
            {
                return GetPartColor(Parts.Switch.ShapeOn);
            }
            set
            {
                SetPartColor(Parts.Switch.ShapeOn, value);
                SetPartColor(Parts.Switch.SliderOn, value.WithAlpha(0.5));
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultShapeOn = fromConstructor || this.Color == _defaultShapeOn;

            _defaultShapeOn = MColors.Current.PrimaryColor;

            if (isDefaultShapeOn)
            {
                this.Color = _defaultShapeOn;
            }
        }
    }
}
