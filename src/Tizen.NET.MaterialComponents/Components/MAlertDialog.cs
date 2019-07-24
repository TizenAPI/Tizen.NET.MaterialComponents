using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MAlertDialog : MDialog
    {
        Button _confirmButton;
        Button _cancelButton;

        public MAlertDialog(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.Alert;

            _confirmButton = new MPopupButton(parent);

            _confirmButton.Clicked += (s, e) =>
            {
                Dismiss();
                Confirmed?.Invoke(this, EventArgs.Empty);
            };

            _cancelButton = new MPopupButton(this);

            _cancelButton.Clicked += (s, e) =>
            {
                Dismiss();
            };

            SetPartContent(Parts.Popup.Button2, _confirmButton);
            SetPartContent(Parts.Popup.Button1, _cancelButton);
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

    }
}
