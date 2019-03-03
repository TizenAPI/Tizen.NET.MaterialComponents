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

                var bgColor = value.IsDefault ? _defaultBackgroundColor : value.Blending(Color.White, 95);
                _layout.BackgroundColor = bgColor;
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
            if(string.IsNullOrEmpty(Text))
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

            if(RealHandle == IntPtr.Zero)
            {
                RealHandle = handle;
            }
            Handle = handle;

            _layout.SetTheme("layout", "editfield", Styles.Singleline);
            _layout.SetTheme("layout", "editfield", Styles.Material);
            _layout.SetPartContent(Parts.Content, this);

            return _layout;
        }

        void Activate()
        {
            _layout.SignalEmit(States.Activate, "");
            SetPartText(Parts.Guide, "");
        }

        void Deactivate()
        {
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
