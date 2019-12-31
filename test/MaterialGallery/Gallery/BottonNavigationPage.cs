using ElmSharp;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class BottomNavigationPage : BaseGalleryPage
    {
        public override string Name => "BottomNavigation Gallery";

        public override bool RunningOnNewWindow => true;

        public Color backgroudColor = new Color(200, 200, 100);

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            MBottomNavigation bn = new MBottomNavigation(parent);
            bn.Show();
            box.PackEnd(bn);
            var IconPath = Path.Combine(MaterialComponents.AppResourcePath, "icon.png");

            for (int i = 0; i < 4; i++)
            {
                var item2 = bn.Append(string.Format("{0} Item", i), IconPath);
            }

            return box;
        }
    }
}
