using System;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MFullScreenDialog : MDialog, IColorSchemeComponent
    {
        EvasObject _content;
        Button _actionButton;
        Layout _titleLayout;
        Color _defaultBackground;
        Color _defaultTextColor;

        public MFullScreenDialog(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.FullScreen;

            _titleLayout = new Layout(this);
            _titleLayout.SetTheme("layout", Styles.Material, Styles.Popup.FullScreenTitle);
            _titleLayout.EdjeObject.AddSignalAction(Signal.ActionClick, "*", (s, e) =>
            {
                Dismiss();
            });

            _actionButton = new MButton(this)
            {
                Style = Styles.Popup.PopupButton2,
            };
            _titleLayout.SetPartContent(Parts.Popup.ActionButton, _actionButton);

            _actionButton.Clicked += (s, e) =>
            {
                Dismiss();
                ActionClicked?.Invoke(this, EventArgs.Empty);
            };

            SetPartContent(Parts.Layout.Title, _titleLayout);

            MColors.AddColorSchemeComponent(this);
        }

        public event EventHandler ActionClicked;

        public string Title
        {
            get
            {
                return _titleLayout.GetPartText(Parts.Popup.ElmTitle);
            }
            set
            {
                _titleLayout.SetPartText(Parts.Popup.ElmTitle, value);
            }
        }

        public string Action
        {
            get
            {
                return _actionButton.Text;
            }
            set
            {
                _actionButton.Text = value;
            }
        }

        public EvasObject Content
        {
            get
            {
                return _content;
            }
            set
            {
                if(value != null)
                {
                    _content = value;
                    _content.Show();
                    SetPartContent(Parts.Layout.Content, _content);
                }
                
            }
        }        

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            //// It comes from here
            //// https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_bg_color_selector.xml
            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultTextColor = MColors.Current.OnPrimaryColor;
            
            _titleLayout.SetPartColor(Parts.Widget.Background, _defaultBackground);
            _titleLayout.SetPartColor(Parts.Widget.Title, _defaultTextColor);

            _actionButton.SetPartColor(Parts.Button.Effect, _defaultTextColor.WithAlpha(0.32));
        }
    }
}

