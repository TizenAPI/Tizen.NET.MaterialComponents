using ElmSharp;
using System;
using System.Collections.Generic;
using System.IO;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public class AccountData
    {
        public AccountData(string mail, string iconPath = null)
        {
            Label = mail;
            IconPath = Path.Combine(ThemeLoader.AppResourcePath, iconPath);
        }

        public string Label;
        public string IconPath;
    }

    class DialogPage : BaseGalleryPage
    {
        public override string Name => "Dialog Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            //AlertDialog
            var button = new MButton(parent)
            {
                Text= "AlertDialog",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button);
            button.Show();

            var dialog = CreateAlertDialog(parent);

            button.Clicked += (s, e) =>
            {
                dialog.Show();
            };

            //SimpleDialog
            var button2 = new MButton(parent)
            {
                Text = "SimpleDialog",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button2);
            button2.Show();

            var dialog2 = CreateSimpleDialog(parent);

            button2.Clicked += (s, e) =>
            {
                dialog2.Show();
            };

            //ConfirmationDialog
            var button3 = new MButton(parent)
            {
                Text = "Confirmation(multi)",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button3);
            button3.Show();

            var dialog3 = CreateConfirmationDialog(parent);

            button3.Clicked += (s, e) =>
            {
                dialog3.Show();
            };

            //ConfirmationDialog2
            var button5 = new MButton(parent)
            {
                Text = "Confirmation(single)",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button5);
            button5.Show();

            var dialog5 = CreateConfirmationDialog2(parent);

            button5.Clicked += (s, e) =>
            {
                dialog5.Show();
            };

            //FullScreenDialog
            var button4 = new MButton(parent)
            {
                Text = "FullScreenDialog",
                MinimumWidth = 400,
                WeightY = 1,
                AlignmentY = 0.5
            };
            box.PackEnd(button4);
            button4.Show();

            var dialog4 = CreateFullScreenDialog(parent);

            button4.Clicked += (s, e) =>
            {
                dialog4.Show();
            };

            return box;
        }

        EvasObject CreateFullScreenDialog(EvasObject parent)
        {
            var box = new Box(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
                BackgroundColor = Color.White
            };

            var dialog = new MFullScreenDialog(parent)
            {
                Title = "Title",
                Action = "save",
                Content = box
            };

            dialog.OutsideClicked += (s, e) =>
            {
                dialog.Dismiss();
            };

            dialog.ActionClicked += (s, e) =>
            {
                Console.WriteLine($"Action Button Clicked!!!");
            };

            return dialog;
        }

        EvasObject CreateConfirmationDialog(EvasObject parent)
        {
            var dialog = new MConfirmationDialog(parent)
            {
                Title = "title",
                Confirm = "ok",
                Cancel = "cancel",
                IsMultiSelection = true
            };

            dialog.AppendItem("label1");
            dialog.AppendItem("label2");
            dialog.AppendItem("label3");
            dialog.AppendItem("label4");
            dialog.AppendItem("label5");
            dialog.AppendItem("label6");

            dialog.ItemSelected += (s, e) =>
            {
                Console.WriteLine("dialog.ItemSelected!!------");
                foreach (var i in e.Items)
                {
                    Console.WriteLine($"item={i.Label}");
                }
            };

            return dialog;
        }

        EvasObject CreateConfirmationDialog2(EvasObject parent)
        {
            var dialog = new MConfirmationDialog(parent)
            {
                Title = "title",
                Confirm = "ok",
                Cancel = "cancel",
                IsMultiSelection = false
            };

            dialog.AppendItem("label1");
            dialog.AppendItem("label2");
            dialog.AppendItem("label3");
            dialog.AppendItem("label4");
            dialog.AppendItem("label5");
            dialog.AppendItem("label6");

            dialog.ItemSelected += (s, e) =>
            {
                Console.WriteLine("dialog.ItemSelected!!------");
                foreach (var i in e.Items)
                {
                    Console.WriteLine($"item={i.Label}");
                }
            };

            return dialog;
        }

        EvasObject CreateSimpleDialog(EvasObject parent)
        {
            var dialog = new MSimpleDialog(parent)
            {
                Title = "Set backup account",
            };

            List<AccountData> accounts = new List<AccountData>();
            accounts.Add(new AccountData("user01@gmail.com", "image.png"));
            accounts.Add(new AccountData("user02@gmail.com", "image.png"));
            accounts.Add(new AccountData("Add account", "image.png"));

            foreach (var a in accounts)
            {
                var item = dialog.AppendItem(a.Label, a.IconPath);
                item.Selected += (s, e) =>
                {
                    Console.WriteLine($"Selected: {(s as MSimpleDialogItem)?.Label}");
                };
            }

            return dialog;
        }

        EvasObject CreateAlertDialog(EvasObject parent)
        {
            var dialog = new MAlertDialog(parent)
            {
                Message = "Discard draft?",
                Confirm = "diacard",
                Cancel = "cancel"
            };

            dialog.Confirmed += (s, e) =>
            {
                Console.WriteLine("confirmed");
            };

            dialog.Dismissed += (s, e) =>
            {
                Console.WriteLine("dismissed");
            };

            dialog.Deleted += (s, e) =>
            {
                Console.WriteLine("deleted");
            };

            return dialog;
        }
    }
}
