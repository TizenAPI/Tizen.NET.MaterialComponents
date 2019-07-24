using ElmSharp;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    internal class TopAppbarPage : BaseGalleryPage
    {
        public override string Name => "AppbarTop Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHomogeneous = false
            };
            box.Show();

            var topAppbar = new MTopAppbar(parent)
            {
                WeightY = 0
            };
            topAppbar.Show();

            var navigationIcon = new Image(parent);
            navigationIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "menu.png"));
            var navigationItem = new MButton(parent)
            {
                Icon = navigationIcon
            };

            navigationItem.Clicked += (s, e) =>
            {
                if (topAppbar.Prominent)
                {
                    topAppbar.Prominent = false;
                    topAppbar.Title = "Appbar";
                }
                else
                {
                    topAppbar.Prominent = true;
                    topAppbar.Title = "Appbar<br>Prominent Mode";
                }
            };

            var overflowIcon = new Image(parent);
            overflowIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "dots.png"));
            var overflowItem = new MButton(parent)
            {
                Icon = overflowIcon
            };

            topAppbar.NavigationItem = navigationItem;
            topAppbar.OverflowItem = overflowItem;
            topAppbar.Title = "Appbar";

            var itemIcon = new Image(parent);
            itemIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "heart.png"));

            var item = new MButton(parent)
            {
                Icon = itemIcon
            };

            var itemIcon2 = new Image(parent);
            itemIcon2.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "magnify.png"));

            var item2 = new MButton(parent)
            {
                Icon = itemIcon2
            };

            var items = new List<MButton>();
            items.Add(item);
            items.Add(item2);
            topAppbar.ActionItems = items;

            box.PackStart(topAppbar);

            var main = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.White
            };
            main.Show();
            box.PackEnd(main);
            return box;
        }
    }
}
