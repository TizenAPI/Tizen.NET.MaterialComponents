using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SliderPage : BaseGalleryPage
    {
        public override string Name => "Slider Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                BackgroundColor = Color.White,
            };
            conformant.SetContent(box);
            box.Show();

            var slider = new MSlider(window)
            {
                Minimum = 0,
                Maximum = 100
            };
            slider.Value = 50;
            slider.Show();
            box.PackEnd(slider);

            var disabledSlider = new MSlider(window)
            {
                Minimum = 0,
                Maximum = 100,
                IsEnabled = false
            };
            disabledSlider.Value = 50;
            disabledSlider.Show();
            box.PackEnd(disabledSlider);

            box.SetLayoutCallback(() =>
            {
                var rect = box.Geometry;
                slider.Geometry = new Rect((rect.Width / 2) - 250, (rect.Height / 2 - 100), 500, 50);
                disabledSlider.Geometry = new Rect((rect.Width / 2) - 250, (rect.Height / 2), 500, 50);
            });

        }
    }
}
