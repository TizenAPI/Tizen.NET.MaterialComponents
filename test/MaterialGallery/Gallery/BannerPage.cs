using ElmSharp;
using Tizen.NET.MaterialComponents;
using System.IO;
using Tizen;
using System;

namespace MaterialGallery
{
    class BannerPage : BaseGalleryPage
    {
        public override string Name => "BannerPage Gallery";

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var button1 = new MButton(parent)
            {
                Text = "Show Banner: Single",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };

            button1.Clicked += (s, e) =>
            {
                CreateBanner(parent, box);
            };

            box.PackEnd(button1);
            button1.Show();

            var button2 = new MButton(parent)
            {
                Text = "Show Banner: Single Long",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };

            button2.Clicked += (s, e) =>
            {
                CreateBanner2(parent, box);
            };

            box.PackEnd(button2);
            button2.Show();


            var button3 = new MButton(parent)
            {
                Text = "Show Banner: Double",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };

            button3.Clicked += (s, e) =>
            {
                CreateBanner3(parent, box);
            };

            box.PackEnd(button3);
            button3.Show();

            var button4 = new MButton(parent)
            {
                Text = "Show Banner: Double with Icon",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };

            button4.Clicked += (s, e) =>
            {
                CreateBanner4(parent, box);
            };

            box.PackEnd(button4);
            button4.Show();

            return box;
        }

        void CreateBanner(EvasObject parent, Box box)
        {
            var banner = new MBanner(parent)
            {
                Action = "action",
                Text = "One line text string with one action."
            };

            banner.Dismissed += (s, e) =>
            {
                Console.WriteLine($"MBanner is dismissed !!!");
            };

            banner.ActionClicked += (s, e) =>
            {
                banner.Unrealize();
                Console.WriteLine($"MBanner.ActionButton is clicked!!!");
            };
            
            banner.Show();
            box.PackStart(banner);
        }

        void CreateBanner2(EvasObject parent, Box box)
        {
            var banner = new MBanner(parent)
            {
                Action = "action",
                Text = "One looooooooooooooooooong text string with one action."
            };

            banner.Dismissed += (s, e) =>
            {
                Console.WriteLine($"MBanner is dismissed !!!");
            };

            banner.ActionClicked += (s, e) =>
            {
                banner.Unrealize();
                Console.WriteLine($"MBanner.ActionButton is clicked!!!");
            };

            banner.Show();
            box.PackStart(banner);
        }

        void CreateBanner3(EvasObject parent, Box box)
        {
            var banner = new MBanner(parent)
            {
                Action = "action",
                Cancel = "dismiss",
                Text = "Two line text string with two actions. One to two lines is perferable on mobile and tablet."
            };

            banner.Dismissed += (s, e) =>
            {
                Console.WriteLine($"MBanner is dismissed !!!");
            };

            banner.ActionClicked += (s, e) =>
            {
                Console.WriteLine($"MBanner.ActionButton is clicked!!!");
            };

            banner.Show();
            box.PackStart(banner);
        }

        void CreateBanner4(EvasObject parent, Box box)
        {
            var banner = new MBanner(parent)
            {
                Action = "action",
                Cancel = "dismiss",
                Icon = Path.Combine(ThemeLoader.AppResourcePath, "image.png"),
                Text = "Two line text string with two actions. One to two lines is perferable on mobile and tablet."
            };

            banner.Dismissed += (s, e) =>
            {
                Console.WriteLine($"MBanner is dismissed !!!");
            };

            banner.ActionClicked += (s, e) =>
            {
                Console.WriteLine($"MBanner.ActionButton is clicked: [Action] Change Icon");
                banner.Icon = Path.Combine(ThemeLoader.AppResourcePath, "copy.png");
            };

            banner.Show();
            box.PackStart(banner);
        }
    }
}
