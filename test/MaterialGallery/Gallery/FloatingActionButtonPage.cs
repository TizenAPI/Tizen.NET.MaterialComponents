using ElmSharp;
using Tizen.NET.MaterialComponents;
using System.IO;
using Tizen;

namespace MaterialGallery
{
    class FloatingActionButtonPage : BaseGalleryPage
    {
        public override string Name => "FloatingActionButton Gallery";

        public override void Run(Window window)
        {
            MConformant conformant = new MConformant(window);
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

            #region FABs
            MFloatingActionButton fab = new MFloatingActionButton(conformant);
            fab.Show();
            fab.Resize(180, 176);
            fab.Move(540, 1070);

            Image img = new Image(window);
            //The source of icon resources is https://materialdesignicons.com/
            img.Load(Path.Combine(MaterialGallery.ResourceDir, "alarm.png"));
            img.Show();
            fab.Icon = img;

            MFloatingActionButton fab2 = new MFloatingActionButton(conformant);
            fab2.Show();
            fab2.Resize(180, 176);
            fab2.Move(540, 940);

            Image img2 = new Image(window);
            //The source of icon resources is https://materialdesignicons.com/
            img2.Load(Path.Combine(MaterialGallery.ResourceDir, "airplane.png"));
            img2.Show();
            fab2.Icon = img2;

            MFloatingActionButton fab3 = new MFloatingActionButton(conformant);
            fab3.Show();
            fab3.Resize(180, 176);
            fab3.Move(540, 810);

            Image img3 = new Image(window);
            //The source of icon resources is https://materialdesignicons.com/
            img3.Load(Path.Combine(MaterialGallery.ResourceDir, "bluetooth.png"));
            img3.Show();
            fab3.Icon = img3;
            #endregion
        }
    }
}
