using ElmSharp;
using System;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    internal class AppbarPage : BaseGalleryPage
    {
        public override string Name => "Appbar Gallery";

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

            #endregion ThemeButton

            var appBar = new MAppbar(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            appBar.Show();
            appBar.Title = "AppBar";
            appBar.NavigationItem = "menu.png";
            appBar.NavigationItemClicked += (s, e) =>
            {
                Console.WriteLine("NavigationItemClicked");
            };
            appBar.OverflowItem = "dots.png";
            appBar.OverflowItemClicked += (s, e) =>
            {
                Console.WriteLine("OverflowItemClicked");
            };
            appBar.PrimaryItem = "heart.png";
            appBar.PrimaryItemClicked += (s, e) =>
            {
                Console.WriteLine("PrimaryItemClicked");
            };
            appBar.SecondaryItem = "magnify.png";
            appBar.SecondaryItemClicked += (s, e) =>
            {
                Console.WriteLine("SecondaryItemClicked");
            };
            appBar.Main = hbox;
            box.PackEnd(appBar);
        }
    }
}
