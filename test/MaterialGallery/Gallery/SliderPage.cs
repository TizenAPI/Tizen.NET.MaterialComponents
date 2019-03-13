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
            Box box = new ColoredBox(window);
            box.Show();
            conformant.SetContent(box);

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
                slider.Geometry = new Rect((rect.Width / 2) - 250, (rect.Height / 2 - 100), 500, 50);
                disabledSlider.Geometry = new Rect((rect.Width / 2) - 250, (rect.Height / 2), 500, 50);
            });

        }
    }
}
