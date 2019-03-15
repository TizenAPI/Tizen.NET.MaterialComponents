using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSlider : Slider, IColorSchemeComponent
    {
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;

        Color _defaultBarColor;
        Color _defaultBarColorForDisabled;

        Color _defaultHandlerColor;
        Color _defaultHandlerColorForExtended;
        Color _defaultHandlerColorForDisabled;


        public MSlider(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            MColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultColor = fromConstructor || GetPartColor(Parts.Slider.Bar) == _defaultBarColor;
            bool isDefaultBackgroundColor = fromConstructor || GetPartColor(Parts.Widget.Background) == _defaultBackgroundColor;


            _defaultBackgroundColor = MColors.Current.PrimaryColor.WithAlpha(0.5);
            _defaultBackgroundColorForDisabled = MColors.Current.OnSurfaceColor.WithAlpha(0.12);

            _defaultBarColor = MColors.Current.PrimaryColor;
            _defaultBarColorForDisabled = MColors.Current.OnSurfaceColor.WithAlpha(0.12);

            _defaultHandlerColor = MColors.Current.PrimaryColor;
            _defaultHandlerColorForExtended = MColors.Current.PrimaryColor.WithAlpha(0.32);
            _defaultHandlerColorForDisabled = MColors.Current.OnSurfaceColor.WithAlpha(0.5);


            if (isDefaultColor)
            {
                SetPartColor(Parts.Slider.Bar, _defaultBarColor);
                SetPartColor(Parts.Slider.BarPressed, _defaultBarColor); // ??

                SetPartColor(Parts.Slider.Handler, _defaultHandlerColor);
                SetPartColor(Parts.Slider.HandlerPressed, _defaultHandlerColor);
                SetPartColor(Parts.Slider.Handler2, _defaultHandlerColorForExtended);

            }

            if (isDefaultBackgroundColor)
            {
                SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
            }

            SetPartColor(Parts.Slider.BarDisabled, _defaultBarColorForDisabled);
            SetPartColor(Parts.Slider.HandlerDisabled, _defaultHandlerColorForDisabled);
            SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColor);
        }
    }
}
