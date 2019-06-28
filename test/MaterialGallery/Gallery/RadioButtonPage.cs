using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class RadioButtonPage : BaseGalleryPage
    {
        public override string Name => "Radio Button Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile | ProfileType.Wearable;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var radio = new MRadioButton(parent)
            {
                StateValue = 1,
                WeightY = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5,
            };
            box.PackEnd(radio);
            radio.Show();

            var radio2 = new MRadioButton(parent)
            {
                StateValue = 2,
                IsEnabled = true,
                Color = Color.FromHex("#E30425"),
                WeightY = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5
            };
            box.PackEnd(radio2);
            radio2.SetGroup(radio);
            radio2.Show();

            var radio3 = new MRadioButton(parent)
            {
                StateValue = 3,
                IsEnabled = false,
                WeightY = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5
            };
            box.PackEnd(radio3);
            radio3.SetGroup(radio2);
            radio3.Show();

            radio.GroupValue = 1;

            return box;
        }
    }
}
