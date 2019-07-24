
using System;
using System.Text.RegularExpressions;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    internal class MPopupButton : Button, IColorSchemeComponent
    {
        string _text;
        Color _defaultTextColor;
        Color _defaultTextColorForDisable;

        internal MPopupButton(EvasObject parent) : base (parent)
        {
            Style = Styles.Popup.PopupButton;
            MColors.AddColorSchemeComponent(this);
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

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            // It comes from here
            // https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_bg_color_selector.xml
            _defaultTextColor = MColors.Current.PrimaryColor;
            _defaultTextColorForDisable = MColors.Current.PrimaryColor.WithAlpha(0.38);

            SetPartColor(Parts.Widget.Text, _defaultTextColor);
            SetPartColor(Parts.Widget.TextPressed, _defaultTextColor);
            SetPartColor(Parts.Widget.TextDisabled, _defaultTextColorForDisable);
        }
    }
}
