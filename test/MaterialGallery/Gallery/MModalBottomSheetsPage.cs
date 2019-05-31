using ElmSharp;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MModalBottomSheetsPage : BaseGalleryPage
    {
        public override string Name => "MModalBottomSheets Gallery";

        public override void Run(Window window)
        {
            MConformant conformant = new MConformant(window);
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

            #region ModalSheets
            MModalSheets modalSheets = new MModalSheets(conformant, MModalSheetsDirection.Bottom);
            modalSheets.Show();

            GenList genlist = new GenList(conformant)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            GenItemClass defaultClass = new GenItemClass(Styles.GenListItem.MaterialNavigation)
            {
                GetTextHandler = (obj, part) =>
                {
                    return ((MItem)obj).Title;
                },
                GetContentHandler = (obj, part) =>
                {
                    var icon = ((MItem)obj).Icon;

                    if (icon != null)
                    {
                        var image = new Image(conformant);
                        var result = image.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, icon));
                        return image;
                    }
                    else
                    {
                        return null;
                    }
                }
            };

            genlist.Append(defaultClass, new MItem("Share", "share.png"));
            genlist.Append(defaultClass, new MItem("Get link", "insert-link.png"));
            genlist.Append(defaultClass, new MItem("Edit name", "edit.png"));
            genlist.Append(defaultClass, new MItem("Delete collection", "delete.png"));

            modalSheets.SetContent(genlist);
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
                Text = "Open MModalBottomSheets",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                modalSheets.IsOpen = true;
            };

            btbox.PackEnd(button1);
            #endregion
        }
    }
}
