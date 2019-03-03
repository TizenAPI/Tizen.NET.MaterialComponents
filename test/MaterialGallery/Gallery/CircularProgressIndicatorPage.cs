using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class CircularProgressIndicatorPage : BaseGalleryPage
    {
        EcoreTimelineAnimator _animator;

        public override string Name => "Circular ProgressIndicator Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                BackgroundColor = Color.White
            };
            conformant.SetContent(box);
            box.Show();

            MActivityIndicator determinateAI = new MActivityIndicator(window)
            {
                Value = 50,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            determinateAI.Show();

            MActivityIndicator indeterminateAI = new MActivityIndicator(window)
            {
                Text = "Linear progress indicator (Indeterminate)",
                Type = MProgressIndicatorType.Indeterminate,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            indeterminateAI.Show();

            Label label1 = new Label(window)
            {
                Text = "Circular progress indicator (Determinate)",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            label1.Show();

            Label label2 = new Label(window)
            {
                Text = "Circular progress indicator (Indeterminate)",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            label2.Show();

            box.PackEnd(label1);
            box.PackEnd(determinateAI);
            box.PackEnd(label2);
            box.PackEnd(indeterminateAI);

            double max = 1.0;
            double min = 0;
            double unit = 0.1;

            if (_animator==null)
            {
                _animator = new EcoreTimelineAnimator(1.0, ()=> 
                {
                    var val = determinateAI.Value + unit;
                    if (val <= max)
                        determinateAI.Value = val;
                });

                _animator.Finished += (s, e) =>
                {
                    determinateAI.Value = min;
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
