using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class RadioButtonPage : BaseGalleryPage
    {
        public override string Name => "Radio Button Gallery";

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


            var radio = new MRadioButton(window)
            {
                StateValue = 1,
                Text = "group1",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(radio);
            radio.Show();

            var radio2 = new MRadioButton(window)
            {
                StateValue = 2,
                Text = "group1",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(radio2);
            radio2.Show();
            radio2.SetGroup(radio);

            var radio3 = new MRadioButton(window)
            {
                StateValue = 3,
                Text = "Disabled",
                IsEnabled = false,
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(radio3);
            radio3.Show();

            var radio4 = new MRadioButton(window)
            {
                StateValue = 4,
                Text = "Custom Color",
                IsEnabled = true,
                Color = Color.FromHex("#E30425"),
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(radio4);
            radio4.Show();
        }
    }
}
