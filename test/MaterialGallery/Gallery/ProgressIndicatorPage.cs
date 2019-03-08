using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class ProgressIndicatorPage : BaseGalleryPage
    {
        EcoreTimelineAnimator _animator;

        public override string Name => "ProgressIndicator Gallery";

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
                WeightY = 0.5,
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

            defaultColor.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Default;
            light.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Light;
            dark.Clicked += (s, e) => MatrialColors.Current = MatrialColors.Dark;
            #endregion


            MProgressIndicator determinatePI = new MProgressIndicator(window)
            {
                Value = 0,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            determinatePI.Show();

            MProgressIndicator indeterminatePI = new MProgressIndicator(window)
            {
                Text = "Linear progress indicator (Indeterminate)",
                Type = MProgressIndicatorType.Indeterminate,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            indeterminatePI.Show();

            MProgressIndicator disabledPI = new MProgressIndicator(window)
            {
                Text = "Disabled",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                IsEnabled = false,
            };
            disabledPI.Show();

            Label label1 = new Label(window)
            {
                Text = "Linear progress indicator (Determinate)",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            label1.Show();

            Label label2 = new Label(window)
            {
                Text = "Linear progress indicator (Indeterminate)",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            label2.Show();

            box.PackEnd(label1);
            box.PackEnd(determinatePI);
            box.PackEnd(label2);
            box.PackEnd(indeterminatePI);
            box.PackEnd(disabledPI);

            double max = 1.0;
            double min = 0;
            double unit = 0.1;

            if (_animator==null)
            {
                _animator = new EcoreTimelineAnimator(1.0, ()=> 
                {
                    var val = determinatePI.Value + unit;
                    if (val <= max)
                        determinatePI.Value = val;
                });

                _animator.Finished += (s, e) =>
                {
                    determinatePI.Value = min;
                    _animator.Start();
                };
            }

            _animator.Start();
        }

        public override void TearDown()
        {
            base.TearDown();
            _animator.Stop();
        }
    }
}
