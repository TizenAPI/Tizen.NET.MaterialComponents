using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MConformant : Conformant
    {
        Box _box = null;
        SmartEvent _keypadOn;
        SmartEvent _keypadOff;

        public event EventHandler KeyPadOn;
        public event EventHandler KeyPadOff;

        public MConformant(Window parent) : base(parent)
        {
            _keypadOn = new SmartEvent(this, Events.VirtualKeypadOn);
            _keypadOn.On += (s, e) => KeyPadOn?.Invoke(this, EventArgs.Empty);

            _keypadOff = new SmartEvent(this, Events.VirtualKeypadOff);
            _keypadOff.On += (s, e) => KeyPadOff?.Invoke(this, EventArgs.Empty);
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
