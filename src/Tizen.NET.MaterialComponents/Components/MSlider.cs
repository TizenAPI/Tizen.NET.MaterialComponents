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
            (this as IColorSchemeComponent).OnColorSchemeChanged(true);
            MatrialColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultColor = fromConstructor || GetPartColor("bar") == _defaultBarColor;
            bool isDefaultBackgroundColor = fromConstructor || GetPartColor("bg") == _defaultBackgroundColor;


            _defaultBackgroundColor = MatrialColors.Current.PrimaryColor.WithAlpha(0.5);
            _defaultBackgroundColorForDisabled = MatrialColors.Current.OnSurfaceColor.WithAlpha(0.12);

            _defaultBarColor = MatrialColors.Current.PrimaryColor;
            _defaultBarColorForDisabled = MatrialColors.Current.OnSurfaceColor.WithAlpha(0.12);

            _defaultHandlerColor = MatrialColors.Current.PrimaryColor;
            _defaultHandlerColorForExtended = MatrialColors.Current.PrimaryColor.WithAlpha(0.32);
            _defaultHandlerColorForDisabled = MatrialColors.Current.OnSurfaceColor.WithAlpha(0.5);


            if (isDefaultColor)
            {
                SetPartColor("bar", _defaultBarColor);
                SetPartColor("bar_pressed", _defaultBarColor); // ??

                SetPartColor("handler", _defaultHandlerColor);
                SetPartColor("handler_pressed", _defaultHandlerColor);
                SetPartColor("handler2", _defaultHandlerColorForExtended);

            }

            if (isDefaultBackgroundColor)
            {
                SetPartColor("bg", _defaultBackgroundColor);
            }

            SetPartColor("bar_disabled", _defaultBarColorForDisabled);
            SetPartColor("handler_disabled", _defaultHandlerColorForDisabled);
            SetPartColor("bg_disabled", _defaultBackgroundColor);
        }
    }
}
