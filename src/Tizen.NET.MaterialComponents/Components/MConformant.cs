using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MConformant : Conformant
    {
        Box _box = null;

        public MConformant(Window parent) : base(parent)
        {
        }

        public EvasObject FloatingLayout
        {
            get
            {
                if (_box == null)
                {
                    _box = new Box(this);
                    _box.Show();
                    SetPartContent(Parts.Layout.FloatingButton, _box);
                }
                return _box;
            }
        }
    }
}
