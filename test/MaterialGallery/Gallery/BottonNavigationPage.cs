using ElmSharp;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class BottomNavigationPage : BaseGalleryPage
    {
        public override string Name => "BottomNavigation Gallery";

        public Color backgroudColor = new Color(200, 200, 100);

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
                WeightY = 0.2,
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

            MBottomNavigation bn = new MBottomNavigation(window);
            bn.Show();
            box.PackEnd(bn);
            var IconPath = Path.Combine(ThemeLoader.AppResourcePath, "icon.png");

            for (int i = 0; i < 4; i++)
            {
                var item2 = bn.Append(string.Format("{0} Item", i), IconPath);
            }
        }
    }
}
