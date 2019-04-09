using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SnackBarsPage : BaseGalleryPage
    {
        public override string Name => "SnackBars Gallery";

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
                WeightY = 0.1,
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

            #region SnackBars
            MSnackBars snackBars = new MSnackBars(window)
            {
                Text = "It's my favorite"
            };
            snackBars.OutsideClicked += (s, e) => { snackBars.Hide(); };

            MSnackBars snackBars2 = new MSnackBars(window)
            {
                Text = "It's my favorite",
                ActionText = "Action"
            };
            snackBars2.OutsideClicked += (s, e) => { snackBars2.Hide(); };
            snackBars2.ActionClicked += (s, e) => { snackBars2.Hide(); };

            MSnackBars snackBars3 = new MSnackBars(window)
            {
                Text = "I'm very happy because summer is my favorite season."
            };
            snackBars3.OutsideClicked += (s, e) => { snackBars3.Hide(); };

            MSnackBars snackBars4 = new MSnackBars(window)
            {
                Text = "I'm very happy because summer is my favorite season.",
                ActionText = "OK"
            };
            snackBars4.OutsideClicked += (s, e) => { snackBars4.Hide(); };
            snackBars4.ActionClicked += (s, e) => { snackBars4.Hide(); };
            #endregion

            #region Buttons
            Box btbox = new Box(window)
            {
                WeightX = 1,
                WeightY = 0.3,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            btbox.Show();
            box.PackEnd(btbox);

            MButton button1 = new MButton(window)
            {
                Text = "SnackBars",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                snackBars.Show();
            };

            MButton button2 = new MButton(window)
            {
                Text = "SnackBars with Action",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                snackBars2.Show();
            };

            MButton button3 = new MButton(window)
            {
                Text = "SnackBars with long text",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button3.Show();
            button3.Clicked += (s, e) =>
            {
                snackBars3.Show();
            };

            MButton button4 = new MButton(window)
            {
                Text = "SnackBars (long text and action)",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 1,
            };
            button4.Show();
            button4.Clicked += (s, e) =>
            {
                snackBars4.Show();
            };

            btbox.PackEnd(button1);
            btbox.PackEnd(button2);
            btbox.PackEnd(button3);
            btbox.PackEnd(button4);
            #endregion
        }
    }
}
