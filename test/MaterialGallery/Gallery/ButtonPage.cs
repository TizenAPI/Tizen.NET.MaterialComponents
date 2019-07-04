using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public class ButtonPage : BaseGalleryPage
    {
        public override string Name => "Button Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            var box = new ColoredBox(parent);
            box.Show();

            var button = new MButton(parent)
            {
                Text= "Button",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button);
            button.Show();

            var button2 = new MButton(parent)
            {
                IsEnabled = false,
                Text = "Disabled",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button2);
            button2.Show();

            var button3 = new MButton(parent)
            {
                IsEnabled = true,
                Text = "Custom Color",
                BackgroundColor = Color.FromHex("#03A9F4"),
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button3);
            button3.Show();

            return box;
        }
    }
}
