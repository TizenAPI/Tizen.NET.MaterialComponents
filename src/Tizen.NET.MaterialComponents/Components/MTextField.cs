using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTextField : Entry
    {
        Layout _layout;
        SmartEvent _changed;
        Color _defaultTextColor;
        Color _defaultLabelColor;
        Color _defaultBackgroundColor;
        Color _backgroundColor;
        MTextFieldType _type = MTextFieldType.Default;

        public event EventHandler TextChanged;

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
                return _layout.GetPartText(Parts.TextLabel);
            }
            set
            {
                _layout.SetPartText(Parts.TextLabel, value);
                SetPartText(Parts.Guide, value);
            }
        }

        public Color LabelColor
        {
            get
            {
                return _layout.GetPartColor(Parts.Label);
            }
            set
            {
                var color = value.IsDefault ? _defaultLabelColor : value;
                _layout.SetPartColor(Parts.Label, color);
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
                return GetPartColor(Parts.TextEdit);
            }
            set
            {
                var color = value.IsDefault ? _defaultTextColor : value;

                SetPartColor(Parts.TextEdit, color);
                SetPartColor(Parts.TextEditFocused, color);
                _layout.SetPartColor(Parts.Underline, color);
                _layout.SetPartColor(Parts.UnderlineFocused, color);

                if (_backgroundColor.IsDefault)
                {
                    var bgColor = value.IsDefault ? _defaultBackgroundColor : value.Blending(Color.White, 95);
                    _layout.BackgroundColor = bgColor;
                }
            }
        }

        public override Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                if(value.IsDefault)
                {
                    var color = TextColor.IsDefault ? _defaultBackgroundColor : TextColor.Blending(Color.White, 95);
                    _layout.BackgroundColor = color;
                }
                else
                {
                    _layout.BackgroundColor = value;
                }
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
            _changed = new SmartEvent(this, this.RealHandle, Events.Changed);
            _changed.On += OnChanged;

            _defaultTextColor = GetPartColor(Parts.TextEdit);
            _defaultLabelColor = _layout.GetPartColor(Parts.Label);
            _defaultBackgroundColor = _layout.BackgroundColor;

            Focused += OnFocused;
            Unfocused += OnUnfocused;

            IsSingleLine = true;
        }

        void OnFocused(object sender, EventArgs args)
        {
            Activate();
            _layout.SignalEmit(States.Focused, "");
        }

        void OnUnfocused(object sender, EventArgs args)
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

        void OnChanged(object sender, EventArgs args)
        {
            if(string.IsNullOrEmpty(Text) && !IsFocused)
            {
                Deactivate();
            }
            TextChanged?.Invoke(this, EventArgs.Empty);
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
            _layout.SetPartContent(Parts.Content, this);

            _layout.Focused += (s, e) =>
            {
                AllowFocus(true);
                SetFocus(true);
            };

            _layout.Unfocused += (s, e) =>
            {
                SetFocus(false);
                AllowFocus(false);
            };

            AllowFocus(false);

            _layout.RaiseTop();
            _layout.AllowFocus(true);

            return _layout;
        }


        void Activate()
        {
            _layout.SignalEmit(States.Activate, "");
            SetPartText(Parts.Guide, "");
        }

        void Deactivate()
        {
            if (IsFocused)
                return;

            _layout.SignalEmit(States.Unactivate, "");
            var guide = _layout.GetPartText(Parts.TextLabel);
            SetPartText(Parts.Guide, guide);
        }

        public enum MTextFieldType
        {
            Default,
            Outlined
        }
    }
}
