using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MProgressIndicator : ProgressBar, IColorSchemeComponent
    {
        MProgressIndicatorType _type;

        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisable;
        Color _defaultBarColor;
        Color _defaultBarColorForDisable;


        public MProgressIndicator(EvasObject parent) : this(parent, Styles.Material) { }

        protected MProgressIndicator(EvasObject parent, string style) : base(parent)
        {
            Style = style;
            MColors.AddColorSchemeComponent(this);
        }

        public MProgressIndicatorType Type
        {
            get => _type;
            set
            {
                switch (value)
                {
                    case MProgressIndicatorType.Determinate:
                        IsPulseMode = false;
                        break;
                    case MProgressIndicatorType.Indeterminate:
                        IsPulseMode = true;
                        PlayPulse();
                        break;
                }
                _type = value;
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBarColor = (fromConstructor || GetPartColor("bar") == _defaultBarColor);
            bool isDefaultBackgroundColor = (fromConstructor || GetPartColor("bg") == _defaultBackgroundColor);


            _defaultBackgroundColor = MColors.Current.PrimaryColor.WithAlpha(0.32);
            _defaultBackgroundColorForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.12);
            _defaultBarColor = MColors.Current.PrimaryColor;
            _defaultBarColorForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.38);

            if (isDefaultBarColor)
            {
                SetPartColor("bar", _defaultBarColor);
            }
            if (isDefaultBackgroundColor)
            {
                SetPartColor("bg", _defaultBackgroundColor);
            }

            SetPartColor("bg_disabled", _defaultBackgroundColorForDisable);
            SetPartColor("bar_disabled", _defaultBarColorForDisable);
        }
    }

    public enum MProgressIndicatorType
    {
        Determinate,
        Indeterminate
    }
}
