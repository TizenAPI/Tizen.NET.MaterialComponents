using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class CheckboxPage : BaseGalleryPage
    {
        public override string Name => "Checkbox Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            var box = new ColoredBox(parent);
            box.Show();

            var check = new MCheckBox(parent)
            {
                IsChecked = true,
                WeightY = 1,
                WeightX = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5
            };
            box.PackEnd(check);
            check.Show();

            var check2 = new MCheckBox(parent)
            {
                IsEnabled = true,
                Color = Color.FromHex("#E30425"),
                WeightY = 1,
                WeightX = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5
            };
            box.PackEnd(check2);
            check2.Show();

            var check3 = new MCheckBox(parent)
            {
                IsChecked = true,
                IsEnabled = false,
                WeightY = 1,
                WeightX = 1,
                AlignmentY = 0.5,
                AlignmentX = 0.5
            };
            box.PackEnd(check3);
            check3.Show();

            return box;
        }
    }
}
