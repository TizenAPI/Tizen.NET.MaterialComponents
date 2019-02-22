using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TabsPage : BaseGalleryPage
    {
        public override string Name => "Tabs Gallery";

        public Color backgroudColor = new Color(200, 200, 100);

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                BackgroundColor = Color.White
            };
            conformant.SetContent(box);
            box.Show();

            MTabs tabs = new MTabs(window)
            {
                Type = MTabsType.Scrollable,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            tabs.Show();

            Label label1 = new Label(window)
            {
                Text = " Scrollable Tabs",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            label1.Show();

            MTabs tabs2 = new MTabs(window)
            {
                Type = MTabsType.Fixed,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            tabs2.Show();

            Label label2 = new Label(window)
            {
                Text = " Fixed Tabs",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            label2.Show();

            for (int i = 0; i < 4; i++)
            {
                var item = tabs.Append(string.Format("{0}ht Item", i));
            }

            for (int i = 0; i < 4; i++)
            {
                var item2 = tabs2.Append(string.Format("{0}ht Item", i), "home");
                item2.SetPartColor("bg", backgroudColor);
            }

            box.PackEnd(tabs);
            box.PackEnd(label1);
            box.PackEnd(tabs2);
            box.PackEnd(label2);
        }
    }
}
