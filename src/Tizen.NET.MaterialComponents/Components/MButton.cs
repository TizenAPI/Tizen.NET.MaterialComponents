using System.Text.RegularExpressions;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MButton : Button, IColorSchemeComponent
    {
        string _text;
        MButtonTypes _type = MButtonTypes.Contained;

        Color _defaultBackground;
        Color _defaultBackgroundForDisable;
        Color _defaultBackgroundForPressed;
        Color _defaultTextColor;
        Color _defaultTextColorForDisable;

        public MButtonTypes ButtonStyle
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                var str = value.ToUpper();
                if (str.Contains("<") && str.Contains(">"))
                {
                    var tagPattern = @"\<[^<&^>]+\>";
                    str = Regex.Replace(str, tagPattern, m => m.ToString().ToLower());
                }
                base.Text = str;
            }
        }

        public MButton(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            MColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || GetPartColor("bg") == _defaultBackground;
            bool isDefaultTextColor = fromConstructor || GetPartColor("text") == _defaultTextColor;

            // It comes from here
            // https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_bg_color_selector.xml
            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultBackgroundForPressed = MColors.Current.PrimaryColor.WithAlpha(0.32);
            _defaultBackgroundForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.12);

            // https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_text_color_selector.xml
            _defaultTextColor = MColors.Current.OnPrimaryColor;
            _defaultTextColorForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.38);

            if (isDefaultBackground)
            {
                SetPartColor("bg", _defaultBackground);
                SetPartColor("bg_pressed", _defaultBackground);
                SetPartColor("bg_disabled", _defaultBackgroundForDisable);
            }
            if (isDefaultTextColor)
            {
                SetPartColor("text", _defaultTextColor);
                SetPartColor("text_pressed", _defaultTextColor);
                SetPartColor("text_disabled", _defaultTextColorForDisable);
            }
        }
    }

    public enum MButtonTypes
    {
        Contained,
        Text,
        Outlined,
        Toggle
    }
}
