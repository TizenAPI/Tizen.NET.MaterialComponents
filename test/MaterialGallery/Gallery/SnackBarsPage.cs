using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SnackBarsPage : BaseGalleryPage
    {
        public override string Name => "SnackBars Gallery";

        public override ProfileType ExceptProfile => ProfileType.Wearable;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            #region SnackBars
            MSnackBars snackBars = new MSnackBars(parent)
            {
                Text = "It's my favorite"
            };
            snackBars.OutsideClicked += (s, e) => { snackBars.Hide(); };

            MSnackBars snackBars2 = new MSnackBars(parent)
            {
                Text = "It's my favorite",
                ActionText = "Action"
            };
            snackBars2.OutsideClicked += (s, e) => { snackBars2.Hide(); };
            snackBars2.ActionClicked += (s, e) => { snackBars2.Hide(); };

            MSnackBars snackBars3 = new MSnackBars(parent)
            {
                Text = "I'm very happy because summer is my favorite season."
            };
            snackBars3.OutsideClicked += (s, e) => { snackBars3.Hide(); };

            MSnackBars snackBars4 = new MSnackBars(parent)
            {
                Text = "I'm very happy because summer is my favorite season.",
                ActionText = "OK"
            };
            snackBars4.OutsideClicked += (s, e) => { snackBars4.Hide(); };
            snackBars4.ActionClicked += (s, e) => { snackBars4.Hide(); };
            #endregion

            #region Buttons
            Box btbox = new Box(parent)
            {
                WeightX = 1,
                WeightY = 0.3,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            btbox.Show();
            box.PackEnd(btbox);

            MButton button1 = new MButton(parent)
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

            MButton button2 = new MButton(parent)
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

            MButton button3 = new MButton(parent)
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

            MButton button4 = new MButton(parent)
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

            return box;
        }
    }
}
