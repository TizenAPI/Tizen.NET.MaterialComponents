using ElmSharp;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    internal class BottomAppbarPage : BaseGalleryPage
    {
        public override string Name => "AppbarBottom Gallery";

        MConformant _conformant;

        public override Conformant CreateComformant(Window window)
        {
            _conformant = new MConformant(window);
            _conformant.Show();
            return _conformant;
        }

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var bottomAppBar = new MBottomAppbar(parent)
            {
                WeightY = 0
            };
            bottomAppBar.Show();

            var navigationIcon = new Image(parent);
            navigationIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "menu.png"));
            var navigationItem = new MButton(parent)
            {
                Icon = navigationIcon
            };

            var overflowIcon = new Image(parent);
            overflowIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "dots.png"));
            var overflowItem = new MButton(parent)
            {
                Icon = overflowIcon
            };

            bottomAppBar.NavigationItem = navigationItem;
            bottomAppBar.OverflowItem = overflowItem;

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
            bottomAppBar.ActionItems = items;

            var floatingAcitonButton = new MFloatingActionButton(_conformant);
            floatingAcitonButton.BackgroundColor = Color.Black;
            Image image = new Image(parent);
            image.Load(Path.Combine(MaterialGallery.ResourceDir, "plus.png"));
            image.Show();
            floatingAcitonButton.Icon = image;
            floatingAcitonButton.Show();
            floatingAcitonButton.Clicked += (s, e) =>
            {
                if (bottomAppBar.FloatingActionButtonPosition == MFloatingActionButtonPosition.Left)
                {
                    bottomAppBar.FloatingActionButtonPosition = MFloatingActionButtonPosition.Center;
                }
                else if (bottomAppBar.FloatingActionButtonPosition == MFloatingActionButtonPosition.Center)
                {
                    bottomAppBar.FloatingActionButtonPosition = MFloatingActionButtonPosition.Right;
                }
                else
                {
                    bottomAppBar.FloatingActionButtonPosition = MFloatingActionButtonPosition.Left;
                }
            };

            bottomAppBar.FloatingActionButton = floatingAcitonButton;

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
            box.PackEnd(bottomAppBar);

            return box;
        }
    }
}
