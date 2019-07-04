using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    public enum ProfileType
    {
        None = 0,
        Mobile = 1,
        Wearable = 2,
        TV = 4
    }

    public abstract class BaseGalleryPage
    {
        public abstract string Name { get; }

        public virtual ProfileType ExceptProfile => ProfileType.None;

        public virtual void Run(Window window)
        {
            Conformant comformant = CreateComformant(window);
            var content = CreateContent(window);

            if (Elementary.GetProfile() != "wearable" && content is Box box)
            {
                box.PackStart(CreateThemeButtons(window));
                box.Recalculate();
            }

            comformant.SetContent(content);
        }

        public virtual Conformant CreateComformant(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            return conformant;
        }

        public abstract EvasObject CreateContent(EvasObject parent);

        public virtual void TearDown() { }

        public EvasObject CreateThemeButtons(EvasObject parent)
        {
            Box box = new Box(parent)
            {
                IsHorizontal = true,
                WeightX = 1,
                WeightY = 0.1,
                AlignmentX = -1,
                AlignmentY = 0.5,
            };
            box.Show();

            var defaultColor = new MButton(parent)
            {
                Text = "default",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var light = new MButton(parent)
            {
                Text = "light",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var dark = new MButton(parent)
            {
                Text = "Dark",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            defaultColor.Show();
            light.Show();
            dark.Show();
            box.PackEnd(defaultColor);
            box.PackEnd(light);
            box.PackEnd(dark);

            defaultColor.Clicked += (s, e) => MColors.Current = MColors.Default;
            light.Clicked += (s, e) => MColors.Current = MColors.Light;
            dark.Clicked += (s, e) => MColors.Current = MColors.Dark;

            return box;
        }
    }
}
