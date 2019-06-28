using ElmSharp;
using System.IO;
using Tizen;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public static class Extension
    {
        public static int ToPixel(this int i)
        {
            var dpi = 293;
            var pixel = (int)((i * dpi) / 160);

            return pixel;
        }
    }
    class CardsPage : BaseGalleryPage
    {
        public override string Name => "Cards Gallery";

        public override ProfileType SupportProfile => ProfileType.Mobile;

        public override EvasObject CreateContent(EvasObject parent)
        {
            Box box = new ColoredBox(parent);
            box.Show();

            var card1 = CreateCard1(parent);
            var card2 = CreateCard2(parent);

            var label1 = new Label(parent)
            {
                Text = "<span font_size=35>Card 1</span>",
                MinimumWidth = 500,
                MinimumHeight = 30
            };
            label1.Show();

            var label2 = new Label(parent)
            {
                Text = "<span font_size=35>Card 2 Layout</span>",
                MinimumWidth = 500,
                MinimumHeight = 30
            };
            label2.Show();

            box.PackEnd(label1);
            box.PackEnd(card1);
            box.PackEnd(label2);
            box.PackEnd(card2);

            box.SetLayoutCallback(() =>
            {
                var rect = box.Geometry;
                label1.Geometry = new Rect(rect.X + 50, rect.Y + 50, label1.MinimumWidth, label1.MinimumHeight);
                card1.Geometry = new Rect(rect.X + 50, rect.Y + 100, card1.MinimumWidth, card1.MinimumHeight);
                label2.Geometry = new Rect(rect.X + 50, card1.Geometry.Y + card1.Geometry.Height + 50, label2.MinimumWidth, label2.MinimumHeight);
                card2.Geometry = new Rect(rect.X + 50, card1.Geometry.Y + card1.Geometry.Height + 100, card2.MinimumWidth, card2.MinimumHeight);
            });

            return box;
        }

        EvasObject CreateCard1(EvasObject parent)
        {
            //Set Layout
            var card = new MCard(parent)
            {
                MinimumWidth = 344.ToPixel(),
                MinimumHeight = 148.ToPixel(),
            };

            var iconBox = new Box(parent)
            {
                MinimumWidth = 80.ToPixel(),
                MinimumHeight = 80.ToPixel()
            };

            var textBox = new Box(parent)
            {
                MinimumWidth = 216.ToPixel(),
                MinimumHeight = 80.ToPixel()
            };
            textBox.SetPadding(0, 10);


            var actionBox = new Box(parent)
            {
                MinimumHeight = 36.ToPixel(),
                IsHorizontal = true
            };
            actionBox.SetPadding(8, 0);

            card.Show();
            iconBox.Show();
            textBox.Show();
            actionBox.Show();

            card.PackEnd(iconBox);
            card.PackEnd(textBox);
            card.PackEnd(actionBox);

            card.SetLayoutCallback(() =>
            {
                var g = card.Geometry;

                textBox.Geometry = new Rect(
                    g.X + 16.ToPixel(),
                    g.Y + 16.ToPixel(),
                    textBox.MinimumWidth,
                    textBox.MinimumHeight);

                iconBox.Geometry = new Rect(
                    textBox.Geometry.X + textBox.Geometry.Width + 16.ToPixel(),
                    textBox.Geometry.Y,
                    iconBox.MinimumWidth,
                    iconBox.MinimumHeight);

                actionBox.Geometry = new Rect(
                    g.X + 8.ToPixel(),
                    iconBox.Geometry.Y + iconBox.Geometry.Height + 8.ToPixel(),
                    g.Width - 32.ToPixel(),
                    actionBox.MinimumHeight);
            });

            //Fill the contents
            var icon = new Image(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsFixedAspect = false
            };

            icon.Load(Path.Combine(MaterialGallery.ResourceDir, "image.png"));
            icon.Show();
            iconBox.PackEnd(icon);

            var title = new Label(parent)
            {
                Text = $"<span font_size={25.ToPixel()}>Title goes here</span>",
                AlignmentX = 0,
                AlignmentY = 0
            };
            var sub = new Label(parent)
            {
                Text = $"<span font_size={15.ToPixel()} color=#666666>Secondary line text Lorem ipsum dolor sit amet</span>",
                LineWrapType = WrapType.Word,
                LineWrapWidth = textBox.MinimumWidth,
                AlignmentX = 0,
                AlignmentY = 0,
            };

            title.Show();
            sub.Show();
            textBox.PackEnd(title);
            textBox.PackEnd(sub);

            var action1 = new MButton(parent)
            {
                //ButtonStyle = MButtonStyle.TextButton,
                //Text = "Action 1",
                Text = $"<span font_size={18.ToPixel()} color=#6200ee>Action 1</span>",
                BackgroundColor = Color.White,
                AlignmentX = 0,
                MinimumWidth = 100.ToPixel()
            };

            var action2 = new MButton(parent)
            {
                //ButtonStyle = MButtonStyle.TextButton,
                //Text = "Action 2",
                Text = $"<span font_size={18.ToPixel()} color=#6200ee>Action 2</SPAN>",
                BackgroundColor = Color.White,
                AlignmentX = 0,
                MinimumWidth = 100.ToPixel()
            };

            var empty = new Label(parent)
            {
                AlignmentX = 0,
                WeightX = 1,
            };

            action1.Show();
            action2.Show();
            empty.Show();

            actionBox.PackEnd(action1);
            actionBox.PackEnd(action2);
            actionBox.PackEnd(empty);

            return card;
        }

        EvasObject CreateCard2(EvasObject parent)
        {
            var card = new MCard(parent)
            {
                MinimumWidth = 344.ToPixel(),
                MinimumHeight = 382.ToPixel(),
                BorderColor = Color.Red
            };

            card.Show();

            var iconBox = new Box(parent);
            var titleBox = new Box(parent);
            var imgBox = new Box(parent);
            var descBox = new Box(parent);
            var actionBox = new Box(parent)
            {
                MinimumHeight = 36.ToPixel(),
                IsHorizontal = true
            };
            actionBox.SetPadding(8, 0);

            iconBox.BackgroundColor = Color.Gray;
            titleBox.BackgroundColor = Color.Aqua;
            imgBox.BackgroundColor = Color.Yellow;
            descBox.BackgroundColor = Color.Pink;
            actionBox.BackgroundColor = Color.Lime;

            card.PackEnd(iconBox);
            card.PackEnd(titleBox);
            card.PackEnd(imgBox);
            card.PackEnd(descBox);
            card.PackEnd(actionBox);

            card.SetLayoutCallback(() =>
            {
                var g = card.Geometry;

                // TODO : card.Chlidren will be used for layouting
                foreach (var child in card.Children)
                {
                    child.Show();
                }

                iconBox.Geometry = new Rect(
                    g.X + 16.ToPixel(),
                    g.Y + 16.ToPixel(),
                    40.ToPixel(),
                    40.ToPixel());
                titleBox.Geometry = new Rect(
                    iconBox.Geometry.X + iconBox.Geometry.Width + 16.ToPixel(),
                    g.Y + 16.ToPixel(),
                    g.Width - 88.ToPixel(),
                    40.ToPixel());
                imgBox.Geometry = new Rect(
                    g.X,
                    g.Y + 72.ToPixel(),
                    g.Width,
                    194.ToPixel());
                descBox.Geometry = new Rect(
                    g.X + 16.ToPixel(),
                    imgBox.Geometry.Y + imgBox.Geometry.Height + 16.ToPixel(),
                    g.Width - 32.ToPixel(),
                    g.Height - imgBox.Geometry.Height - 72.ToPixel() - 68.ToPixel());
                actionBox.Geometry = new Rect(
                    g.X + 16.ToPixel(),
                    descBox.Geometry.Y + descBox.Geometry.Height + 8.ToPixel(),
                    g.Width / 2,
                    36.ToPixel());
            });

            return card;
        }
    }
}
