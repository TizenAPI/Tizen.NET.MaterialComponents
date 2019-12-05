using System;
using System.IO;
using Tizen.NET.MaterialComponents;
using ElmSharp;

namespace MaterialGallery
{
    public class AppBarPage : BaseGalleryPage
    {
        public override string Name => "Appbar(Top) Gallery";

        public override void Run(Window window)
        {
            Conformant comformant = CreateComformant(window);
            var content = CreateContent(window);

            if (Elementary.GetProfile() != "wearable" && content is Box box)
            {
                box.PackEnd(CreateThemeButtons(window));
                box.Recalculate();
            }

            comformant.SetContent(content);
        }

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var naviIconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "menu.png");

            var appbar = new MTopAppBar(parent)
            {
                Title = "Page title",
                NavigationItem = new MActionItem("naviItem", naviIconPath, () =>
                {
                    Console.WriteLine($"Navigation action item clicked");
                })
            };
            appbar.Show();
            box.PackStart(appbar);

            var airplaneIconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "airplane.png");
            var alarmIconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "alarm.png");
            var bluetoothIconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "bluetooth.png");

            appbar.ActionItems.Add(new MActionItem("airplane", airplaneIconPath, () => { Console.WriteLine($"ariplane"); }));
            appbar.ActionItems.Add(new MActionItem("alarm", alarmIconPath, () => { Console.WriteLine($"alarm"); }));
            appbar.ActionItems.Add(new MActionItem("bluetooth", bluetoothIconPath, () => { Console.WriteLine($"bluetooth"); }));


            var bButton = new MButton(parent)
            {
                Text = "set/unset bg",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            var bFlag = true;
            bButton.Clicked += (s, e) =>
            {
                if(bFlag)
                {
                    appbar.BackgroundOption = BackgroundOptions.Center;
                    appbar.BackgroundImageFile = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "photo.jpg");
                }
                else
                {
                    appbar.BackgroundImageFile = "";
                }
                bFlag = !bFlag;


            };            
            bButton.Show();

            var nButton = new MButton(parent)
            {
                Text = "add/remove naviitem",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            var item = new MActionItem("new", naviIconPath, () =>
            {
                Console.WriteLine($"new Navigation action item");
            });

            nButton.Clicked += (s, e) =>
            {
                if (appbar.NavigationItem == null)
                {
                    appbar.NavigationItem = item;
                }
                else
                {
                    appbar.NavigationItem = null;
                }
            };            
            nButton.Show();

            var ltButton = new MButton(parent)
            {
                Text = "change title",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            bool ltFlag = true;
            ltButton.Clicked += (s, e) =>
            {
                if (ltFlag)
                {
                    appbar.Title = "Page title";
                }
                else
                {
                    appbar.Title = "Page title looooooooooooooooooooong";
                }
                ltFlag = !ltFlag;

            };            
            ltButton.Show();
            
            var tButton = new MButton(parent)
            {
                Text = "change title color",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            bool tFlag = true;
            tButton.Clicked += (s, e) =>
            {
                if (tFlag)
                {
                    appbar.TitleColor = Color.Red;
                }
                else
                {
                    appbar.TitleColor = Color.Default;
                }
                tFlag = !tFlag;

            };
            tButton.Show();

            var pButton = new MButton(parent)
            {
                Text = "prominent on/off",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };
            
            pButton.Show();

            pButton.Clicked += (s, e) =>
            {
                appbar.Prominent = !appbar.Prominent;
            };

            var addButton = new MButton(parent)
            {
                Text = "add item",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            addButton.Clicked += (s, e) =>
            {
                var iconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "image.png");
                appbar.ActionItems.Add(new MActionItem("new item", iconPath, () => { Console.WriteLine($"new item"); }));
            };

            
            addButton.Show();


            var removeButton = new MButton(parent)
            {
                Text = "remove item",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            removeButton.Clicked += (s, e) =>
            {
                if (appbar.ActionItems.Count > 0)
                {
                    appbar.ActionItems.RemoveAt(appbar.ActionItems.Count - 1);
                }
            };
            removeButton.Show();

            box.PackEnd(bButton);
            box.PackEnd(pButton);
            box.PackEnd(nButton);
            box.PackEnd(ltButton);
            box.PackEnd(tButton);
            box.PackEnd(addButton);
            box.PackEnd(removeButton);
            
            return box;
        }
    }
}
