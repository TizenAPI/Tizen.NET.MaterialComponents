using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MProgressIndicator : ProgressBar
    {
        MProgressIndicatorType _type;

        public MProgressIndicator(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
        }

        protected MProgressIndicator(EvasObject parent, string style) : base(parent)
        {
            Style = style;
        }

        public MProgressIndicatorType Type
        {
            get => _type;
            set
            {
                switch (value)
                {
                    case MProgressIndicatorType.Determinate:
                        IsPulseMode = false;
                        break;
                    case MProgressIndicatorType.Indeterminate:
                        IsPulseMode = true;
                        PlayPulse();
                        break;
                }
                _type = value;
            }
        }
    }

    public enum MProgressIndicatorType
    {
        Determinate,
        Indeterminate
    }
}
