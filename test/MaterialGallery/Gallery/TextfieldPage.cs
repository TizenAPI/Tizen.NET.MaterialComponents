using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TextFieldPage : BaseGalleryPage
    {
        public override string Name => "TextFieldPage";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new ColoredBox(window);
            conformant.SetContent(box);
            box.SetPadding(0, 100);
            box.Show();

            var innerbox = new Box(window)
            {
                MinimumWidth = 500,
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false
            };
            innerbox.Show();
            box.PackEnd(innerbox);

            #region ThemeButton
            Box hbox = new Box(window)
            {
                IsHorizontal = true,
                WeightX = 1,
                WeightY = 1,
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
                AlignmentY = 0.9
            };
            var light = new MButton(window)
            {
                Text = "light",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.9
            };
            var dark = new MButton(window)
            {
                Text = "Dark",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.9
            };
            defaultColor.Show();
            light.Show();
            dark.Show();
            hbox.PackEnd(defaultColor);
            hbox.PackEnd(light);
            hbox.PackEnd(dark);

            defaultColor.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Default;
            light.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Light;
            dark.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Dark;
            #endregion


            var textfield = new MTextField(window)
            {
                Label = "Label",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            textfield.Show();
            innerbox.PackEnd(textfield);

            var emptyLabel = new Label(window)
            {
                MinimumWidth = 500,
                MinimumHeight = 100,
                WeightX = 1,
                AlignmentX = -1,
            };
            emptyLabel.Show();
            innerbox.PackEnd(emptyLabel);

            var textfield2 = new MTextField(window)
            {
                Label = "Label",
                Text = "Input text",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            textfield2.Show();
            innerbox.PackEnd(textfield2);
        }
    }

    // Also, Can define custom color code
    public class MyColorScheme : MatrialColors
    {
        public override Color PrimaryColor => Color.FromHex("#555555");
    }
}
