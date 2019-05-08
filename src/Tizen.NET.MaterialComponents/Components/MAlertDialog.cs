using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MAlertDialog : MDialog, IColorSchemeComponent
    {
        Color _defaultTextColor;
        Color _defaultTextColorForDisable;
        Button _confirmButton;
        Button _cancelButton;

        public MAlertDialog(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.Alert;

            _confirmButton = new Button(parent)
            {
                Style = Styles.Popup.PopupButton
            };

            _confirmButton.Clicked += (s, e) =>
            {
                Dismiss();
                Confirmed?.Invoke(this, EventArgs.Empty);
            };

            _cancelButton = new Button(this)
            {
                Style = Styles.Popup.PopupButton
            };

            _cancelButton.Clicked += (s, e) =>
            {
                Dismiss();
            };

            SetPartContent(Parts.Popup.Button2, _confirmButton);
            SetPartContent(Parts.Popup.Button1, _cancelButton);

            MColors.AddColorSchemeComponent(this);
        }

        public event EventHandler Confirmed;

        public string Message
        {
            get
            {
                return GetPartText(Parts.Popup.TextLabel);
            }
            set
            {
                SetPartText(Parts.Popup.TextLabel, value);
            }
        }

        public string Cancel
        {
            get
            {
                return _cancelButton.Text;
            }
            set
            {
                _cancelButton.Text = value;
            }
        }

        public string Confirm
        {
            get
            {
                return _confirmButton.Text;
            }
            set
            {
                _confirmButton.Text = value;
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            // It comes from here
            // https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_bg_color_selector.xml
            _defaultTextColor = MColors.Current.PrimaryColor;
            _defaultTextColorForDisable = MColors.Current.PrimaryColor.WithAlpha(0.38);

            _confirmButton.SetPartColor(Parts.Widget.Text, _defaultTextColor);
            _confirmButton.SetPartColor(Parts.Widget.TextPressed, _defaultTextColor);
            _confirmButton.SetPartColor(Parts.Widget.TextDisabled, _defaultTextColorForDisable);

            _cancelButton.SetPartColor(Parts.Widget.Text, _defaultTextColor);
            _cancelButton.SetPartColor(Parts.Widget.TextPressed, _defaultTextColor);
            _cancelButton.SetPartColor(Parts.Widget.TextDisabled, _defaultTextColorForDisable);
        }
    }
}
