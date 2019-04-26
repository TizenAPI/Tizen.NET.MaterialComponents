using ElmSharp;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MenusPage : BaseGalleryPage
    {
        public override string Name => "Menus Gallery";

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

            #region Menus
            MMenus menu1 = new MMenus(window);
            menu1.Append("Undo");
            menu1.Append("Redo");
            var item = menu1.Append("Cut");
            item.InsertDividerAbove();
            menu1.Append("Copy");
            menu1.Append("Paste");

            var img1 = new Image(window);
            img1.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "visible.png"));
            var img2 = new Image(window);
            img2.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "add-user-male.png"));
            var img3 = new Image(window);
            img3.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "link.png"));
            var img4 = new Image(window);
            img4.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "copy.png"));
            var img5 = new Image(window);
            img5.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "download.png"));

            MMenus menu2 = new MMenus(window);
            menu2.Append("Preview", img1);
            menu2.Append("Share", img2);
            menu2.Append("Get Link", img3);
            var item2 = menu2.Append("Preview", img4);
            item2.InsertDividerAbove();
            menu2.Append("Download", img5);
            #endregion

            #region Buttons
            Box btbox = new Box(window)
            {
                WeightX = 1,
                WeightY = 0.3,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            btbox.Show();
            box.PackEnd(btbox);

            MButton button1 = new MButton(window)
            {
                Text = "Text list",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                menu1.Show();
            };

            MButton button2 = new MButton(window)
            {
                Text = "Text and icon list",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                menu2.Show();
            };

            btbox.PackEnd(button1);
            btbox.PackEnd(button2);
            #endregion
        }
    }
}
