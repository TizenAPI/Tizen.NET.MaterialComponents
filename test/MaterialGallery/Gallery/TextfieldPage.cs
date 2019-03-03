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
            Box box = new Box(window)
            {
                BackgroundColor = Color.White,
            };
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
}
