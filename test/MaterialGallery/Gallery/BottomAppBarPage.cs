using System;
using System.IO;
using Tizen.NET.MaterialComponents;
using ElmSharp;

namespace MaterialGallery
{
    public class BottomAppBarPage : BaseGalleryPage
    {
        public override string Name => "Appbar(Bottom) Gallery";

        public override bool RunningOnNewWindow => true;

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

            var naviIconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "menu.png");

            var appbar = new MBottomAppBar(parent)
            {
                NavigationItem = new MActionItem("naviItem", naviIconPath, () =>
                {
                    Console.WriteLine($"Navigation action item clicked");
                })
            };
            appbar.Show();

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
            nButton.Show();

            var addButton = new MButton(parent)
            {
                Text = "add item",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            int itemNum = 1;
            addButton.Clicked += (s, e) =>
            {
                var iconPath = Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, "alarm.png");
                appbar.ActionItems.Add(new MActionItem("new item" + itemNum++, iconPath, () => { Console.WriteLine($"new item{itemNum} clicked!!"); })); ;
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

            var lbutton = new MButton(parent)
            {
                Text = "layout",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5,
            };

            int layout = 0;
            lbutton.Clicked += (s, e) =>
            {
                layout++;

                if(layout % 3 == 2)
                {
                    appbar.LayoutOption = BottomAppBarLayoutOption.NoFAB;
                }
                else if (layout % 3 == 1)
                {
                    appbar.LayoutOption = BottomAppBarLayoutOption.EndFAB;
                }
                else
                {
                    appbar.LayoutOption = BottomAppBarLayoutOption.CenteredFAB;
                }
                lbutton.Text = "layout: " + appbar.LayoutOption.ToString();
                lbutton.MinimumWidth = 400;
            };
            lbutton.Show();

            var entry = new MTextField(parent)
            {
                AlignmentX = -1,
                WeightY = 1,
                Label = "textfield",
                Text = "click here to show virtual keypad"
            };
            entry.Show();

            _conformant.KeyPadOn += (s, e) =>
            {
                box.UnPack(appbar);
            };

            _conformant.KeyPadOff += (s, e) =>
            {
                box.PackEnd(appbar);
            };

            MFloatingActionButton fab = new MFloatingActionButton(_conformant);
            Image img2 = new Image(parent);
            img2.Load(Path.Combine(MaterialGallery.ResourceDir, "airplane.png"));
            fab.Icon = img2;

            appbar.FloatingActionButton = fab;

            box.PackEnd(nButton);
            box.PackEnd(lbutton);
            box.PackEnd(addButton);
            box.PackEnd(removeButton);
            box.PackEnd(entry);

            box.PackEnd(appbar);

            return box;
        }
    }
}
