using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class TabsPage : BaseGalleryPage
    {
        public override string Name => "Tabs Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile;

        public Color backgroudColor = new Color(200, 200, 100);

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            MTabs tabs = new MTabs(parent)
            {
                Type = MTabsType.Scrollable,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            tabs.Show();

            Label label1 = new Label(parent)
            {
                Text = " Scrollable Tabs",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            label1.Show();

            MTabs tabs2 = new MTabs(parent)
            {
                Type = MTabsType.Fixed,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
            };
            tabs2.Show();

            Label label2 = new Label(parent)
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

            return box;
        }
    }
}
