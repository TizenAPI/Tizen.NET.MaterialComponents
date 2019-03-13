using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class ButtonPage : BaseGalleryPage
    {
        public override string Name => "Button Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new ColoredBox(window);
            conformant.SetContent(box);
            box.Show();

#region ThemeButton
            Box hbox = new Box(window)
            {
                IsHorizontal = true,
                WeightX = 1,
                WeightY = 0.2,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            hbox.Show();
            box.PackEnd(hbox);

            var defaultColor = new MButton(window)
            {
                Text = "default",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var light = new MButton(window)
            {
                Text = "light",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var dark = new MButton(window)
            {
                Text = "Dark",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            defaultColor.Show();
            light.Show();
            dark.Show();
            hbox.PackEnd(defaultColor);
            hbox.PackEnd(light);
            hbox.PackEnd(dark);

            defaultColor.Clicked += (s, e) => MColors.Current = MColors.Default;
            light.Clicked += (s, e) => MColors.Current = MColors.Light;
            dark.Clicked += (s, e) => MColors.Current = MColors.Dark;
#endregion


            var button = new MButton(window)
            {
                Text= "Button",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button);
            button.Show();

            var button2 = new MButton(window)
            {
                IsEnabled = false,
                Text = "Disabled",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button2);
            button2.Show();

            var button3 = new MButton(window)
            {
                IsEnabled = true,
                Text = "Custom Color",
                BackgroundColor = Color.FromHex("#03A9F4"),
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button3);
            button3.Show();

        }
    }
}
