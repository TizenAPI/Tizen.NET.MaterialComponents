using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TextFieldPage : BaseGalleryPage
    {
        public override string Name => "TextFieldPage";

        public override ProfileType SupportProfile => ProfileType.Mobile | ProfileType.Wearable;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var textfield = new MTextField(parent)
            {
                Label = "Label",
                Text = "Input text",
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                MinimumWidth = 200
            };
            textfield.Show();
            box.PackEnd(textfield);

            return box;
        }
    }

    // Also, Can define custom color code
    public class MyColorScheme : MColors
    {
        public override Color PrimaryColor => Color.FromHex("#555555");
    }
}
