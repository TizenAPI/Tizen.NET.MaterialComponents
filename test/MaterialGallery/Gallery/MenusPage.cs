using ElmSharp;
using System;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MenusPage : BaseGalleryPage
    {
        public override string Name => "Menus Gallery";

        public override ProfileType ExceptProfile => ProfileType.Wearable;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            #region Menus
            MMenus menu1 = new MMenus(parent);
            menu1.Append("Undo");
            menu1.Append("Redo");
            var item = menu1.Append("Cut");
            item.InsertDividerAbove();
            menu1.Append("Copy");
            menu1.Append("Paste");

            var img1 = new Image(parent);
            img1.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "visible.png"));
            var img2 = new Image(parent);
            img2.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "add-user-male.png"));
            var img3 = new Image(parent);
            img3.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "link.png"));
            var img4 = new Image(parent);
            img4.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "copy.png"));
            var img5 = new Image(parent);
            img5.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "download.png"));

            MMenus menu2 = new MMenus(parent);
            menu2.Append("Preview", img1);
            menu2.Append("Share", img2);
            menu2.Append("Get Link", img3);
            var item2 = menu2.Append("Preview", img4);
            item2.InsertDividerAbove();
            menu2.Append("Download", img5);
            #endregion

            #region Buttons

            MButton button1 = new MButton(parent)
            {
                Text = "Text list 222",
                MinimumWidth = 300,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                var g = button1.Geometry;
                menu1.Move(g.X + (g.Width / 2), g.Y);
                menu1.Show();
            };

            MButton button2 = new MButton(parent)
            {
                Text = "Text and icon list",
                MinimumWidth = 300,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                var g = button2.Geometry;
                menu2.Move(g.X + (g.Width / 2), g.Y);
                menu2.Show();
            };

            box.PackEnd(button1);
            box.PackEnd(button2);
            #endregion

            return box;
        }
    }
}
