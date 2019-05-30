using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    internal class ListPage : BaseGalleryPage
    {
        public override string Name => "List Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

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

            #endregion ThemeButton

            var items = new List<MItem>();

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem("Item" + (i + 1), MListStyle.OneLine);
                item.Icon = "visible.png";

                var check = new MCheckBox(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                items.Add(item);
            }

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem("Item" + (i + 31), MListStyle.DoubleLine);
                item.SubText = "Sub Text" + (i + 31);
                item.Icon = "visible.png";

                var check = new MCheckBox(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                items.Add(item);
            }

            for (int i = 0; i < 30; i++)
            {
                var item = new MItem("Item" + (i + 61), MListStyle.TripleLine);
                item.SubText = "Looooooooooooooooooooooooooooooooooooong Text" + (i + 61);
                item.Icon = "visible.png";

                var check = new MCheckBox(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1
                };
                check.Show();

                item.Control = check;

                items.Add(item);
            }

            var list = new MList(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            list.Show();

            list.Items = items;

            box.PackEnd(list);
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
