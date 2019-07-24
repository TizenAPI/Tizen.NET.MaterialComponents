using ElmSharp;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    internal class AppbarPage : BaseGalleryPage
    {
        public override string Name => "Appbar Gallery";

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
                IsHomogeneous = false
            };

            box.Show();

            var topAppbar = new MTopAppbar(parent);
            topAppbar.Title = "Appbar";

            var topNavigationIcon = new Image(parent);
            topNavigationIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "menu.png"));

            var topNavigationItem = new MButton(parent)
            {
                Icon = topNavigationIcon
            };

            topNavigationItem.Clicked += (s, e) =>
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

            var topOverflowIcon = new Image(parent);
            topOverflowIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "dots.png"));

            var topOverflowItem = new MButton(parent)
            {
                Icon = topOverflowIcon
            };

            var topItemIcon = new Image(parent);
            topItemIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "heart.png"));

            var topItem = new MButton(parent)
            {
                Icon = topItemIcon
            };

            var topItemIcon2 = new Image(parent);
            topItemIcon2.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "magnify.png"));

            var topItem2 = new MButton(parent)
            {
                Icon = topItemIcon2
            };

            var topItems = new List<MButton>();
            topItems.Add(topItem);
            topItems.Add(topItem2);

            topAppbar.NavigationItem = topNavigationItem;
            topAppbar.OverflowItem = topOverflowItem;
            topAppbar.ActionItems = topItems;

            var bottomAppBar = new MBottomAppbar(parent);

            var bottomNavigationIcon = new Image(parent);
            bottomNavigationIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "airplane.png"));

            var bottomNavigationItem = new MButton(parent)
            {
                Icon = bottomNavigationIcon
            };

            var bottomOverflowIcon = new Image(parent);
            bottomOverflowIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "alarm.png"));

            var bottomOverflowItem = new MButton(parent)
            {
                Icon = bottomOverflowIcon
            };

            bottomAppBar.NavigationItem = bottomNavigationItem;
            bottomAppBar.OverflowItem = bottomOverflowItem;

            var bottomItemIcon = new Image(parent);
            bottomItemIcon.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "heart.png"));

            var bottomItem = new MButton(parent)
            {
                Icon = bottomItemIcon
            };

            var bottomItemIcon2 = new Image(parent);
            bottomItemIcon2.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "magnify.png"));

            var bottomItem2 = new MButton(parent)
            {
                Icon = bottomItemIcon2
            };

            var items = new List<MButton>();
            items.Add(bottomItem);
            items.Add(bottomItem2);
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

            var appbar = new MAppbar(parent);
            appbar.Show();
            appbar.TopAppbar = topAppbar;
            appbar.BottomAppbar = bottomAppBar;
            var main = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.White
            };
            main.Show();
            appbar.Main = main;
            box.PackEnd(appbar);

            return box;
        }
    }
}
