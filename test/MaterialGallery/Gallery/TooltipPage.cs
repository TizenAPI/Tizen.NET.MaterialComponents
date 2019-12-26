using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TooltipPage : BaseGalleryPage
    {
        public override string Name => "Tooltip Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var button = new MButton(parent)
            {
                Text = "show tooltip",
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = 0.5
            };
            button.Show();

            var button2 = new MButton(parent)
            {
                IsEnabled = true,
                Text = "Chage Tooltip Button2",
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = 0.5,
                BackgroundColor = Color.FromHex("#03A9F4"),
            };
            button2.Show();

            button.UseMTooltip();
            button2.UseMTooltip();

            button.SetTooltipText("Tooltip Test");
            button2.SetTooltipText("#03A9F4");

            button2.Clicked += (s, e) =>
            {
                button.SetTooltipText("Chage Tooltip");
            };

            box.PackEnd(button);
            box.PackEnd(button2);

            return box;
        }
    }
}
