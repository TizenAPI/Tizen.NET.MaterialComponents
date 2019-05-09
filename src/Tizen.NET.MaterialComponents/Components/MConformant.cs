using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MConformant : Conformant
    {
        Layout _layout = null;
        Box _box = null;

        public MConformant(Window parent) : base(parent)
        {
            SetContent(_layout);
        }

        public EvasObject FloatingLayout
        {
            get
            {
                if (_box == null)
                {
                    _box = new Box(_layout);
                    _box.Show();
                    _layout.SetPartContent(Parts.Layout.FloatingButton, _box);
                }
                return _box;
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            _layout = new Layout(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            _layout.SetTheme("layout", Styles.MaterialApplication, "default");
            RealHandle = _layout;
            return _layout;
        }
    }
}
