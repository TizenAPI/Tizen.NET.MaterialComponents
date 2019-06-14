using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public abstract class MDialog : MPopup
    {
        public MDialog(EvasObject parent) : base(parent)
        {
            AlignmentX = 0.5;
            AlignmentY = 0.5;
        }
    }
}
