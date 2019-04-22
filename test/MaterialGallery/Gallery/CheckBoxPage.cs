using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class CheckboxPage : BaseGalleryPage
    {
        public override string Name => "Checkbox Gallery";

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


            var check = new MCheckBox(window)
            {
                Text= "CheckBox",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(check);
            check.Show();

            var check2 = new MCheckBox(window)
            {
                IsEnabled = false,
                IsChecked = true,
                Text = "Disabled, Checked",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(check2);
            check2.Show();

            var check3 = new MCheckBox(window)
            {
                IsEnabled = false,
                IsChecked = false,
                Text = "Disabled",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(check3);
            check3.Show();

            var check4 = new MCheckBox(window)
            {
                IsEnabled = true,
                Text = "Custom Color",
                Color = Color.FromHex("#E30425"),
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(check4);
            check4.Show();

            var check5 = new MCheckBox(window)
            {
                IsEnabled = false,
                IsChecked = true,
                Text = "Custom Color",
                Color = Color.FromHex("#E30425"),
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(check5);
            check5.Show();
        }
    }
}
