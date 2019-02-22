using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSlider : Slider
    {
        public MSlider(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
        }
    }
}
