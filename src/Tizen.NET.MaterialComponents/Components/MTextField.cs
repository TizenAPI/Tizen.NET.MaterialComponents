using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTextField : Entry, IColorSchemeComponent
    {
        Layout _layout;
        Color _defaultTextColor;
        Color _defaultLabelColor;
        Color _defaultBackgroundColor;

        MTextFieldType _type = MTextFieldType.Default;

        public MTextFieldType Type
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

        public string Label
        {
            get
            {
                return _layout.GetPartText(Parts.Entry.TextLabel);
            }
            set
            {
                _layout.SetPartText(Parts.Entry.TextLabel, value);
                SetPartText(Parts.Entry.Guide, value);
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (string.IsNullOrEmpty(base.Text))
                {
                    Deactivate();
                }
                else
                {
                    Activate();
                }
            }
        }

        public Color TextColor
        {
            get
            {
                return GetPartColor(Parts.Entry.TextEdit);
            }
            set
            {
                var color = value.IsDefault ? _defaultTextColor : value;
                SetPartColor(Parts.Entry.TextEdit, color);
            }
        }

        public Color TextFocusedColor
        {
            get
            {
                return _layout.GetPartColor(Parts.Entry.TextEditFocused);
            }
            set
            {
                var color = value.IsDefault ? _defaultTextColor : value;
                _layout.SetPartColor(Parts.Entry.TextEditFocused, color);
            }
        }

        public Color LabelColor
        {
            get
            {
                return _layout.GetPartColor(Parts.Entry.Label);
            }
            set
            {
                var color = value.IsDefault ? _defaultLabelColor : value;
                _layout.SetPartColor(Parts.Entry.Label, color);
            }
        }

        public Color UnderlineColor
        {
            get
            {
                return _layout.GetPartColor(Parts.Entry.Underline);
            }
            set
            {
                var color = value.IsDefault ? _defaultLabelColor : value;
                _layout.SetPartColor(Parts.Entry.Underline, color);
            }
        }

        public Color UnderlineFocusedColor
        {
            get
            {
                return _layout.GetPartColor(Parts.Entry.UnderlineFocused);
            }
            set
            {
                var color = value.IsDefault ? _defaultLabelColor : value;
                _layout.SetPartColor(Parts.Entry.UnderlineFocused, color);
            }
        }

        public Color CursorColor
        {
            get
            {
                return GetPartColor(Parts.Entry.Cursor);
            }
            set
            {
                var color = value.IsDefault ? _defaultTextColor : value;
                SetPartColor(Parts.Entry.Cursor, color);
            }
        }

        public override Color BackgroundColor
        {
            get
            {
                return _layout.BackgroundColor;
            }
            set
            {
                var color = value.IsDefault ? _defaultBackgroundColor : value;
                _layout.BackgroundColor = value;
            }
        }

        protected Layout Layout
        {
            get
            {
                return _layout;
            }
        }

        public MTextField(EvasObject parent) : base(parent)
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;

            IsSingleLine = true;

            MColors.AddColorSchemeComponent(this);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || _layout.BackgroundColor == _defaultBackgroundColor;
            bool isDefaultTextColor = fromConstructor || GetPartColor(Parts.Entry.TextEdit) == _defaultTextColor;
            bool isDefaultLabelColor = fromConstructor || _layout.GetPartColor(Parts.Entry.Label) == _defaultLabelColor;

            _defaultBackgroundColor = MColors.Current.OnSurfaceColor.WithAlpha(0.04);
            _defaultLabelColor = MColors.Current.PrimaryColor;
            _defaultTextColor = MColors.Current.OnSurfaceColor;

            if (isDefaultBackground)
            {
                _layout.BackgroundColor = _defaultBackgroundColor;
            }
            if (isDefaultTextColor)
            {
                SetPartColor(Parts.Entry.TextEdit, _defaultTextColor);
                SetPartColor(Parts.Entry.TextEditFocused, _defaultTextColor);
                SetPartColor(Parts.Entry.Cursor, _defaultTextColor);
            }
            if (isDefaultLabelColor)
            {
                _layout.SetPartColor(Parts.Entry.Label, _defaultLabelColor);
                _layout.SetPartColor(Parts.Entry.Underline, _defaultLabelColor);
                _layout.SetPartColor(Parts.Entry.UnderlineFocused, _defaultLabelColor);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            var handle = base.CreateHandle(parent);
            _layout = new Layout(parent);
            if (RealHandle == IntPtr.Zero)
            {
                RealHandle = handle;
            }
            Handle = handle;

            _layout.SetTheme("layout", Styles.Material, "textfields");
            _layout.SetPartContent(Parts.Layout.Content, this);

            _layout.Focused += OnLayoutFocused;
            _layout.Unfocused += OnLayoutUnFocused;

            AllowFocus(false);

            _layout.RaiseTop();
            _layout.AllowFocus(true);

            return _layout;
        }

        protected virtual void OnFocused(object sender, EventArgs args)
        {
            Activate();
            _layout.SignalEmit(States.Focused, "");
        }

        protected virtual void OnUnfocused(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Deactivate();
            }
            else
            {
                Activate();
            }
            _layout.SignalEmit(States.Unfocused, "");
        }

        protected virtual void OnLayoutFocused(object sender, EventArgs args)
        {
            AllowFocus(true);
            SetFocus(true);
        }

        protected virtual void OnLayoutUnFocused(object sender, EventArgs args)
        {
            SetFocus(false);
            AllowFocus(false);
        }

        void Activate()
        {
            _layout.SignalEmit(States.Activate, "");
            SetPartText(Parts.Entry.Guide, "");
        }

        void Deactivate()
        {
            if (IsFocused)
                return;

            _layout.SignalEmit(States.Unactivate, "");
            var guide = _layout.GetPartText(Parts.Entry.TextLabel);
            SetPartText(Parts.Entry.Guide, guide);
        }

        public enum MTextFieldType
        {
            Default,
            Outlined
        }
    }
}
