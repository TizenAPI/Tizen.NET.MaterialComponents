using System;
using System.Collections.Generic;
using System.Linq;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MCard : Box, IOptionalComponent
    {
        Layout _layout;
        bool _hasShadow;
        Color _borderColor;

        public MCard(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);
        }

        public new IEnumerable<EvasObject> Children => base.Children.ToList<EvasObject>();

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.TV;

        public bool HasShadow
        {
            get
            {
                return _hasShadow;
            }
            set
            {
                _hasShadow = value;
                if (_hasShadow)
                {
                    _layout.SignalEmit(Actions.ShowShadow, "");
                }
                else
                {
                    _layout.SignalEmit(Actions.HideShadow, "");
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                if (_borderColor == Color.Default)
                {
                    _layout.SetPartColor(Parts.Layout.Border, Color.Transparent);
                }
                else
                {
                    _layout.SetPartColor(Parts.Layout.Border, _borderColor);
                }
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            var handle =  base.CreateHandle(parent);
            _layout = new Layout(parent);

            if (RealHandle == IntPtr.Zero)
            {
                RealHandle = handle;
            }
            Handle = handle;

            _layout.SetTheme("layout", Styles.Material, "frame");
            _layout.SetPartContent(Parts.Layout.Content, this);
            _layout.SignalEmit(Actions.ShowShadow, "");

            return _layout;
        }
    }
}
