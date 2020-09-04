using System.Collections.Generic;
using System.IO;
using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class NavigationViewPage : BaseGalleryPage
    {
        public override string Name => "NavigationView Gallery";

        public override bool RunningOnNewWindow => true;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            MNavigationView nv = new MNavigationView(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            var btn1 = new Button(parent)
            {
                Text = "Chage Header / Background",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                MinimumHeight = 300,
            };
            btn1.Show();

            var btn2 = new Button(parent)
            {
                Text = "Chage Header / Background",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Blue
            };
            btn2.Show();

            var btn3 = new Button(parent)
            {
                Text = "Button",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            btn3.Show();

            var header = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.White
            };

            header.PackEnd(btn2);
            header.PackEnd(btn3);
            header.Show();

            nv.Header = btn1;

            btn1.Clicked += (s, e) =>
            {
                nv.Header = header;
                var imgPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "photo.jpg");
                nv.BackgroundImageFile = imgPath;
                nv.BackgroundOption = BackgroundOptions.Tile;
            };

            btn2.Clicked += (s, e) =>
            {
                nv.Header = btn1;
                nv.BackgroundImageFile = null;
            };

            var items = new List<MItem>();
            items.Add(new MItem("My Files", "icon.png"));
            items.Add(new MItem("Shared with me", "icon.png"));
            items.Add(new MItem("Starred", "icon.png"));
            items.Add(new MItem("Recent", "icon.png"));
            items.Add(new MItem("Offline", "icon.png"));
            items.Add(new MItem("Uploads", "icon.png"));
            items.Add(new MItem("Backup", "icon.png"));
            items.Add(new MItem("Movie", "icon.png"));
            items.Add(new MItem("Music", "icon.png"));
            items.Add(new MItem("Play", "icon.png"));

            var items1 = new List<MItem>();

            for (int i = 0; i < 20; i++)
            {
                items1.Add(new MItem("Change Item", "icon.png"));
            }

            nv.Menu = items;

            var dividers = new List<int>();

            dividers.Add(1);
            dividers.Add(3);
            dividers.Add(5);

            nv.MenuItemSelected += (s, e) =>
            {
                if (nv.Menu == items)
                {
                    nv.Menu = items1;
                }
                else
                {
                    nv.Menu = items;
                }
            };

            nv.Show();

            box.PackEnd(nv);

            return box;
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
