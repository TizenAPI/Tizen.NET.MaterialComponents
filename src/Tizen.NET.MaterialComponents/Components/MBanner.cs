
using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MBanner : Layout, IOptionalComponent
    {
        Button _actionButton;
        Button _cancelButton;
        Image _icon;
        string _iconPath;
        string _style;
        int _iconSize = 80;
        int _padding = 32;
        int _maximumWidth = 568;

        public MBanner(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            AlignmentX = -1;
            AlignmentY = 0;
            WeightX = 1;
            WeightY = 0;

            _actionButton = new MPopupButton(this);
           
            _actionButton.Clicked += (s, e) =>
            {
                ActionClicked?.Invoke(this, EventArgs.Empty);
            };

            SetStyle(Styles.Banner.SingleLine);
            SetPartContent(Parts.Popup.ActionButton, _actionButton);
        }

        public event EventHandler<EventArgs> ActionClicked;

        public event EventHandler<EventArgs> Dismissed;

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.TV;

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                UpdateButtonSize();
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
                UpdateButtonSize();
            }
        }

        public string Cancel
        {
            get
            {
                return (_cancelButton != null) ? _cancelButton.Text : string.Empty;
            }
            set
            {
                if (_cancelButton == null)
                {
                    _cancelButton = new MPopupButton(this);
                    _cancelButton.Clicked += (s, e) =>
                    {
                        Unrealize();
                        Dismissed?.Invoke(this, EventArgs.Empty);
                    };

                    SetStyle(Styles.Banner.DoubleLine);
                    SetPartContent(Parts.Popup.ActionButton2, _cancelButton);
                }
                _cancelButton.Text = value;
                UpdateButtonSize();
            }
        }

        public string Icon
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
                if (_icon == null)
                {
                    _icon = new Image(this)
                    {
                        AlignmentX = -1,
                        AlignmentY = -1,
                        WeightX = 1,
                        WeightY = 1,
                        MinimumHeight = _iconSize,
                        MinimumWidth = _iconSize
                    };                    

                    SetStyle(Styles.Banner.DoubleLine);
                    SetPartContent(Parts.Popup.Icon, _icon);
                }
                _icon.Load(_iconPath);
            }
        }

        void SetStyle(string s)
        {
            if (_style != s)
            {
                SetTheme("layout", Styles.Material, s);
                _style = s;
            }
        }

        void UpdateButtonSize()
        {
            var textBlockWidth = this.EdjeObject[Parts.Popup.Text].TextBlockNativeSize.Width;
            var aButtonTextWidth = _actionButton.EdjeObject[Parts.Popup.Text].TextBlockNativeSize.Width;
            _actionButton.MinimumWidth = aButtonTextWidth + _padding;

            if ((textBlockWidth + aButtonTextWidth) > _maximumWidth)
            {
                SetStyle(Styles.Banner.DoubleLine);
            }

            if (_cancelButton != null)
            {
                var cButtonTextWidth = _cancelButton.EdjeObject[Parts.Popup.Text].TextBlockNativeSize.Width;
                _cancelButton.MinimumWidth = cButtonTextWidth + _padding;
            }
        }
    }
}
