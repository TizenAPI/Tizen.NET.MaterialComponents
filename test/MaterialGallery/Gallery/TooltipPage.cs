using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TooltipPage : BaseGalleryPage
    {
        public override string Name => "Tooltip Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var rect = new Rectangle(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1
            };

            box.PackEnd(rect);

            var button = new MButton(parent)
            {
                Text = "Button",
            };
            button.Resize(400, 80);
            button.Move(180, 300);
            button.Show();

            var button2 = new MButton(parent)
            {
                Text = "Button2",
            };
            button2.Resize(400, 80);
            button2.Move(180, 600);
            button2.Show();

            var button3 = new MButton(parent)
            {
                IsEnabled = true,
                Text = "Chage Tooltip Button2",
                BackgroundColor = Color.FromHex("#03A9F4"),
            };
            button3.Resize(600, 80);
            button3.Move(80, 900);
            button3.Show();

            button.UseMTooltip();
            button2.UseMTooltip();
            button3.UseMTooltip();

            button.SetTooltipText("Button");

            button2.SetTooltipText("Tooltip Test");

            button3.SetTooltipText("#03A9F4");

            button3.Clicked += (s, e) =>
            {
                button2.SetTooltipText("Chage Tooltip");
            };

            return box;
        }
    }
}
