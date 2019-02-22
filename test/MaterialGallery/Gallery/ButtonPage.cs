using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class ButtonPage : BaseGalleryPage
    {
        public override string Name => "Button Gallery";

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

            var button = new MButton(window)
            {
                Text= "Button",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.9
            };
            box.PackEnd(button);
            button.Show();

            var button2 = new MButton(window)
            {
                IsEnabled = false,
                Text = "Button 2",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.1
            };
            box.PackEnd(button2);
            button2.Show();
        }
    }
}
