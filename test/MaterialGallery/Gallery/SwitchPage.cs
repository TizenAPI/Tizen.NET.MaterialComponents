using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SwitchPage : BaseGalleryPage
    {
        public override string Name => "Switch Gallery";

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


            var switch1 = new MSwitch(window)
            {
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch1);
            switch1.Show();

            var switch2 = new MSwitch(window)
            {
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch2);
            switch2.Show();

            var switch3 = new MSwitch(window)
            {
                IsEnabled = false,
                IsChecked = true,
                Text = "Disabled",
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch3);
            switch3.Show();

            var switch4 = new MSwitch(window)
            {
                IsEnabled = true,
                Text = "Custom Color",
                Color = Color.FromHex("#E30425"),
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(switch4);
            switch4.Show();
        }
    }
}
