using ElmSharp;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MenusPage : BaseGalleryPage
    {
        public override string Name => "Menus Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile;

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
            Box btbox = new Box(parent)
            {
                WeightX = 1,
                WeightY = 0.3,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            btbox.Show();
            box.PackEnd(btbox);

            MButton button1 = new MButton(parent)
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

            MButton button2 = new MButton(parent)
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

            return box;
        }
    }
}
