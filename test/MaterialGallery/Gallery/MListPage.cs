using ElmSharp;
using System;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MListPage : BaseGalleryPage
    {
        public override string Name => "MListPage Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var list = new MList(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1
            };
            list.Show();

            var singleItemClass = new MListSingleLineItemClass
            {
                GetTextHandler = (obj, part) =>
                {
                    return obj.ToString();
                },
                GetIconHandler = (obj, part) =>
                {
                    var icon = new Image(parent)
                    {
                        MinimumHeight = 80,
                        MinimumWidth = 80
                    };
                    icon.Load(Path.Combine(MaterialGallery.ResourceDir, "image.png"));
                    return icon;
                },
                GetMetaControlHandler = (obj, part) =>
                {
                    return new MCheckBox(parent);
                },
            };

            var doubleItemClass = new MListDoubleLineItemClass
            {
                GetTextHandler = (obj, part) =>
                {
                    return obj.ToString();
                },
                GetSubTextHandler = (obj, part) =>
                {
                    return "sub text";
                },
                GetIconHandler = (obj, part) =>
                {
                    var icon = new Image(parent)
                    {
                        MinimumHeight = 80,
                        MinimumWidth = 80
                    };
                    icon.Load(Path.Combine(MaterialGallery.ResourceDir, "image.png"));
                    return icon;
                },
                GetMetaControlHandler = (obj, part) =>
                {
                    return new MCheckBox(parent);
                },
            };

            var tripleItemClass = new MListTripleLineItemClass
            {
                GetTextHandler = (obj, part) =>
                {
                    return obj.ToString();
                },
                GetSubTextHandler = (obj, part) =>
                {
                    return "sub text and a too loooooooooooooooooooooooooooong text";
                },
                GetIconHandler = (obj, part) =>
                {
                    var icon = new Image(parent)
                    {
                        MinimumHeight = 80,
                        MinimumWidth = 80
                    };
                    icon.Load(Path.Combine(MaterialGallery.ResourceDir, "image.png"));
                    return icon;
                },
                GetMetaControlHandler = (obj, part) =>
                {
                    return new MCheckBox(parent);
                },
            };


            for (int i = 0; i < 20; i ++)
            {
                if (i % 3 == 0)
                {
                    list.Append(singleItemClass, String.Format("Item_{0}", i));
                }
                else if (i % 3 == 1)
                {
                    list.Append(doubleItemClass, String.Format("Item_{0}", i));
                }
                else if (i % 3 == 2)
                        {
                    list.Append(tripleItemClass, String.Format("Item_{0}", i));
                }               
            }

            box.PackEnd(list);
            return box;
        }

    }
}
