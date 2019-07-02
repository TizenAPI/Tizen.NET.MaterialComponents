using ElmSharp;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MModalBottomSheetsPage : BaseGalleryPage
    {
        public override string Name => "MModalBottomSheets Gallery";

        public override ProfileType ExceptProfile => ProfileType.Wearable;

        MConformant _conformant;

        public override Conformant CreateComformant(Window window)
        {
            _conformant = new MConformant(window);
            _conformant.Show();
            return _conformant;
        }

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            #region ModalSheets
            MModalSheets modalSheets = new MModalSheets(_conformant, MModalSheetsDirection.Bottom);
            modalSheets.Show();

            GenList genlist = new GenList(_conformant)
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
                        var image = new Image(_conformant);
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

            return box;
        }
    }
}
