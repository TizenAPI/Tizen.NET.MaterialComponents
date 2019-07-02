using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SwitchPage : BaseGalleryPage
    {
        public override string Name => "Switch Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var switch1 = new MSwitch(parent)
            {
                IsChecked = true,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch1);
            switch1.Show();

            var switch2 = new MSwitch(parent)
            {
                IsChecked = true,
                Color = Color.FromHex("#E30425"),
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch2);
            switch2.Show();

            var switch3 = new MSwitch(parent)
            {
                IsEnabled = false,
                IsChecked = true,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch3);
            switch3.Show();

            return box;
        }
    }
}
