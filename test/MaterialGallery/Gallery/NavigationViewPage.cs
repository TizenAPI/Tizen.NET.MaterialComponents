using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class NavigationViewPage : BaseGalleryPage
    {
        public override string Name => "NavigationView Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            conformant.SetContent(box);
            box.Show();

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


            MNavigationView nv = new MNavigationView(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            var btn1 = new Button(window)
            {
                Text = "Chage Header",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                MinimumHeight = 300,
            };
            btn1.Show();

            var btn2 = new Button(window)
            {
                Text = "Chage Header",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Blue
            };
            btn2.Show();

            var btn3 = new Button(window)
            {
                Text = "Button",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            btn3.Show();

            var header = new Box(window)
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
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
