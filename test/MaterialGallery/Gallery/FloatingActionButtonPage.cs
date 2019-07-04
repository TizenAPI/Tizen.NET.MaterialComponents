using ElmSharp;
using Tizen.NET.MaterialComponents;
using System.IO;
using Tizen;

namespace MaterialGallery
{
    class FloatingActionButtonPage : BaseGalleryPage
    {
        public override string Name => "FloatingActionButton Gallery";

        MConformant _conformant;

        public override Conformant CreateComformant(Window window)
        {
            _conformant = new MConformant(window);
            _conformant.Show();
            return _conformant;
        }

        public override EvasObject CreateContent(EvasObject parent)
        {
            if (_conformant == null)
                return null;

            Box box = new ColoredBox(parent);
            box.Show();

            var rect = new Rectangle(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };

            box.PackEnd(rect);

            #region FABs
            MFloatingActionButton fab = new MFloatingActionButton(_conformant);
            fab.Show();
            fab.Resize(180, 176);
            fab.Move(540, 1070);

            Image img = new Image(parent);
            //The source of icon resources is https://materialdesignicons.com/
            img.Load(Path.Combine(MaterialGallery.ResourceDir, "alarm.png"));
            img.Show();
            fab.Icon = img;

            MFloatingActionButton fab2 = new MFloatingActionButton(_conformant);
            fab2.Show();
            fab2.Resize(180, 176);
            fab2.Move(540, 940);

            Image img2 = new Image(parent);
            //The source of icon resources is https://materialdesignicons.com/
            img2.Load(Path.Combine(MaterialGallery.ResourceDir, "airplane.png"));
            img2.Show();
            fab2.Icon = img2;

            MFloatingActionButton fab3 = new MFloatingActionButton(_conformant);
            fab3.Show();
            fab3.Resize(180, 176);
            fab3.Move(540, 810);

            Image img3 = new Image(parent);
            //The source of icon resources is https://materialdesignicons.com/
            img3.Load(Path.Combine(MaterialGallery.ResourceDir, "bluetooth.png"));
            img3.Show();
            fab3.Icon = img3;
            #endregion

            if(Elementary.GetProfile() == "wearable")
            {
                fab.Move(90, 20);
                fab2.Move(90, 200);
                fab3.Move(90, 400);

                fab.Clicked += (s, e) =>
                {
                    parent.Unrealize();
                };
            }
            else if (Elementary.GetProfile() == "tv")
            {
                fab.Move(1340, 870);
                fab2.Move(1340, 740);
                fab3.Move(1340, 610);
            }

            return box;
        }
    }
}
