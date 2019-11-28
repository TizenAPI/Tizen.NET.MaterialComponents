using System;
using System.IO;
using Tizen.NET.MaterialComponents;
using ElmSharp;

namespace MaterialGallery
{
    public class AppBarPage : BaseGalleryPage
    {
        public override string Name => "Appbar(Top) Gallery";

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
            box.PackEnd(nButton);
            nButton.Show();

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
            box.PackEnd(tButton);
            tButton.Show();

            var pButton = new MButton(parent)
            {
                Text = "prominent on/off",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };
            box.PackEnd(pButton);
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

            box.PackEnd(addButton);
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

            box.PackEnd(removeButton);
            removeButton.Show();

            return box;
        }
    }
}
