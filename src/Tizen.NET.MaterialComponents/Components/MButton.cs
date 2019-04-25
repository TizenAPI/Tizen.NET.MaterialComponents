using System.Text.RegularExpressions;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MButton : Button, IColorSchemeComponent
    {
        string _text;
        Image _icon = null;
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

        public Image Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                if (_icon != null)
                {
                    SetPartContent(Parts.Widget.Icon, _icon);
                }
                else
                {
                    SetPartContent(Parts.Widget.Icon, null);
                }
            }
        }

        public MButton(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            MColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || GetPartColor(Parts.Widget.Background) == _defaultBackground;
            bool isDefaultTextColor = fromConstructor || GetPartColor(Parts.Widget.Text) == _defaultTextColor;

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
                SetPartColor(Parts.Widget.Background, _defaultBackground);
                SetPartColor(Parts.Widget.BackgroundPressed, _defaultBackground);
                SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundForDisable);
            }
            if (isDefaultTextColor)
            {
                SetPartColor(Parts.Widget.Text, _defaultTextColor);
                SetPartColor(Parts.Widget.TextPressed, _defaultTextColor);
                SetPartColor(Parts.Widget.TextDisabled, _defaultTextColorForDisable);
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
