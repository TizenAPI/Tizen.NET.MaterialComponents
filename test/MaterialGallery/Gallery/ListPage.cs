using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class ListPage : BaseGalleryPage
    {
        public override string Name => "List Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            box.Show();

            var list = new MList(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            list.Show();
            box.PackEnd(list);

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem();
                item.Title = "Item" + (i + 1);
                item.Icon = "visible.png";

                var check = new MCheckBox(parent)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                list.Items.Add(item);
            }

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem();
                item.Title = "Item" + (i + 31);
                item.SubText = "Sub Text" + (i + 31);
                item.Style = MListStyle.DoubleLine;
                item.Icon = "visible.png";

                var check = new MCheckBox(parent)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                list.Items.Add(item);
            }

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem();
                item.Title = "Item" + (i + 61);
                item.Style = MListStyle.TripleLine;
                item.SubText = "Looooooooooooooooooooooooooooooooooooong Text" + (i + 61);
                item.Icon = "visible.png";

                var check = new MCheckBox(parent)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                list.Items.Add(item);
            }

            return box;
        }
    }
}
