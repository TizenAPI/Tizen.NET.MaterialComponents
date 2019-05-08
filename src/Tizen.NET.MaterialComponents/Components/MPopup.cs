using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public abstract class MPopup : Layout
    {
        Popup _popup;

        public MPopup(EvasObject parent) : base(parent)
        {
        }

        public event EventHandler Dismissed;

        public event EventHandler OutsideClicked;

        protected event EventHandler TimedOut;

        protected event EventHandler ShowAnimationFinished;

        public override double AlignmentX
        {
            get
            {
                return _popup.AlignmentX;
            }
            set
            {
                _popup.AlignmentX = value;
            }
        }

        public override double AlignmentY
        {
            get
            {
                return _popup.AlignmentY;
            }
            set
            {
                _popup.AlignmentY = value;
            }
        }

        public virtual void Dismiss()
        {
            _popup.Dismiss();
        }

        protected bool AllowEvents
        {
            get
            {
                return _popup.AllowEvents;
            }
            set
            {
                _popup.AllowEvents = value;
            }
        } 

        protected double Timeout
        {
            get
            {
                return _popup.Timeout;
            }
            set
            {
                _popup.Timeout = value;
            }
        }

        protected PopupOrientation Orientation
        {
            get
            {
                return _popup.Orientation;
            }
            set
            {
                _popup.Orientation = value;
            }
        }

        protected WrapType ContentTextWrapType
        {
            get
            {
                return _popup.ContentTextWrapType;
            }
            set
            {
                _popup.ContentTextWrapType = value;
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            _popup = new Popup(parent);

            _popup.Dismissed += (s, e) =>
            {
                OnDismissed();
                Dismissed?.Invoke(s, e);
            };
            _popup.OutsideClicked += (s, e) =>
            {
                OutsideClicked?.Invoke(s, e);
            };
            _popup.TimedOut += (s, e) =>
            {
                TimedOut?.Invoke(s, e);
            };
            _popup.ShowAnimationFinished += (s, e) =>
            {
                ShowAnimationFinished?.Invoke(s, e);
            };

            return _popup;
        }

        protected virtual void OnDismissed()
        {
        }
    }
}
