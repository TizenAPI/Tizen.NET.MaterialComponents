using ElmSharp;
using System;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SliderPage : BaseGalleryPage
    {
        public override string Name => "Slider Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile | ProfileType.Wearable;

        public override EvasObject CreateContent(EvasObject window)
        {
            Box box = new ColoredBox(window);
            box.Show();

            Box inner = new Box(window)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };

            box.PackEnd(inner);
            inner.Show();

            var slider = new MSlider(window)
            {
                Minimum = 0,
                Maximum = 100
            };
            slider.Value = 50;
            slider.Show();
            inner.PackEnd(slider);

            var disabledSlider = new MSlider(window)
            {
                Minimum = 0,
                Maximum = 100,
                IsEnabled = false
            };
            disabledSlider.Value = 50;
            disabledSlider.Show();
            inner.PackEnd(disabledSlider);

            inner.SetLayoutCallback(() =>
            {
                var rect = inner.Geometry;
                slider.Geometry = new Rect((rect.Width / 2 - 100) + rect.X , (rect.Height / 2 - 50), 200, 50);
                disabledSlider.Geometry = new Rect((rect.Width / 2 - 100) + rect.X, (rect.Height / 2 + 20), 200, 50);
            });

            return box;
        }
    }
}
