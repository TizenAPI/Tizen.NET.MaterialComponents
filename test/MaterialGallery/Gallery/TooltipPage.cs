using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TooltipPage : BaseGalleryPage
    {
        public override string Name => "Tooltip Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new ColoredBox(window);
            conformant.SetContent(box);
            box.Show();

            var button = new MButton(window)
            {
                Text = "Button",
            };
            button.Resize(400, 80);
            button.Move(180, 300);
            button.Show();

            var button2 = new MButton(window)
            {
                Text = "Button2",
            };
            button2.Resize(400, 80);
            button2.Move(180, 600);
            button2.Show();

            var button3 = new MButton(window)
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
        }
    }
}
