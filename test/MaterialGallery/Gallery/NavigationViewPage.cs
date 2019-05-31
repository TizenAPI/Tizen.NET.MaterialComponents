using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class NavigationViewPage : BaseGalleryPage
    {
        public override string Name => "NavigationView Gallery";

        public override ProfileType ExceptProfile => ProfileType.Wearable;

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

            var btn1 = new MButton(parent)
            {
                Text = "Chage Header",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                MinimumHeight = 300,
            };
            btn1.Show();

            var btn2 = new MButton(parent)
            {
                Text = "Chage Header",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Blue
            };
            btn2.Show();

            var btn3 = new MButton(parent)
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
            };

            btn2.Clicked += (s, e) =>
            {
                nv.Header = btn1;
            };

            var items = new List<MItem>();
            items.Add(new MItem() { Title = "My Files", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Shared with me", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Starred", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Recent", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Offline", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Uploads", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Backup", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Movie", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Music", Icon = "icon.png" });
            items.Add(new MItem() { Title = "Play", Icon = "icon.png" });

            var items1 = new List<MItem>();

            for (int i = 0; i < 20; i++)
            {
                items1.Add(new MItem() { Title = "Change Item", Icon = "icon.png" });
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
