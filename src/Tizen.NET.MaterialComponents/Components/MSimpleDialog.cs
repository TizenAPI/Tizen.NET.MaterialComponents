using System;
using System.Collections.Generic;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSimpleDialog : MDialog
    {
        readonly int MaximumHeight = 500;
        readonly int ItemHeight = 180;
        readonly int IconSize = 100;

        IList<MSimpleDialogItem> _itemList = new List<MSimpleDialogItem>();
        Box _layout;
        GenList _genList;
        GenItemClass _itemClass;

        public MSimpleDialog(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.Simple;

            _layout = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            _layout.Show();

            _genList = new GenList(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentY = -1,
                AlignmentX = -1,
                SelectionMode = GenItemSelectionMode.Always
            };

            _itemClass = new GenItemClass(Styles.GenListItem.Default)
            {
                GetContentHandler = GetContent,
                GetTextHandler = GetText
            };

            _genList.ItemSelected += (s, e) =>
            {
                Dismiss();
                (e.Item.Data as MSimpleDialogItem)?.SendSelected();
            };

            OutsideClicked += (s, e) =>
            {
                Dismiss();
            };

            _genList.Show();
            _layout.PackEnd(_genList);
            SetContent(_layout);
        }

        public string Title
        {
            get
            {
                return GetPartText(Parts.Popup.Title);
            }
            set
            {
                SetPartText(Parts.Popup.Title, value);
            }
        }

        public MSimpleDialogItem AppendItem(string label, string iconPath = "")
        {
            var mItem = new MSimpleDialogItem(label, iconPath);
            var item = _genList.Append(_itemClass, mItem);

            _itemList.Add(mItem);
            _layout.MinimumHeight = Math.Min(MaximumHeight, _layout.MinimumHeight + ItemHeight);

            return mItem;
        }

        EvasObject GetContent(object data, string part)
        {
            if (part == Parts.GenListItem.Icon)
            {
                var path = (data as MSimpleDialogItem)?.IconPath;
                if (string.IsNullOrEmpty(path))
                    return null;

                var img = new Image(_genList)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    MinimumHeight = IconSize,
                    MinimumWidth = IconSize
                };
                img.Load(path);

                return img;
            }
            return null;
        }

        string GetText(object data, string part)
        {
            return (data as MSimpleDialogItem)?.Label;
        }
    }
}
