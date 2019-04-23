using System;
using System.Collections.Generic;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSnackBars : Popup, IColorSchemeComponent
    {
        Color _defaultBackgroundColor;
        Color _defaultTextColor;
        Button _actionButton;

        public MSnackBars(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.SnackBars;
            Orientation = PopupOrientation.Bottom;
            MColors.AddColorSchemeComponent(this);
        }

        public event EventHandler ActionClicked;

        public override string Text
        {
            get
            {
                return GetPartText("elm.text.label");
            }
            set
            {
                SetPartText("elm.text.label", value);
            }
        }

        public string ActionText
        {
            get
            {
                return _actionButton?.Text;
            }
            set
            {
                if (_actionButton == null)
                {
                    _actionButton = new Button(this)
                    {
                        Style = Styles.Popup.ActionButton,
                    };
                    _actionButton.Show();
                    _actionButton.Clicked += (s, e) => { ActionClicked?.Invoke(this, EventArgs.Empty); };
                    this.SetPartContent(Parts.Popup.ActionButton, _actionButton);
                }
                _actionButton.Text = value;
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackgroundColor = fromConstructor || _defaultBackgroundColor == GetPartColor(Parts.Widget.Background);
            bool isDefaultTextColor = fromConstructor || GetPartColor(Parts.Widget.Text) == _defaultTextColor;

            _defaultBackgroundColor = MColors.Current.OnBackgroundColor.WithAlpha(0.7);
            _defaultTextColor = MColors.Current.OnPrimaryColor;

            if (isDefaultBackgroundColor)
            {
                SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
            }
            if (isDefaultTextColor)
            {
                SetPartColor(Parts.Widget.Text, _defaultTextColor);
            }
        }
    }
}
