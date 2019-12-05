using System;
using System.Collections.Generic;
using ElmSharp;
namespace Tizen.NET.MaterialComponents
{
    public class MColors
    {
        static List<IColorSchemeComponent> s_colorSchemeComponents = new List<IColorSchemeComponent>();
        public static readonly MColors Default = new MColors();
        public static readonly MColors Light = new LightMColors();
        public static readonly MColors Dark = new DarkMColors();

        public static MColors _current = Default;
        public static MColors Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;

                foreach (var item in s_colorSchemeComponents)
                {
                    item.OnColorSchemeChanged();
                }
                ColorSchemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static event EventHandler ColorSchemeChanged;

        public virtual Color PrimaryColor { get; } = Color.FromHex("#6200EE");
        public virtual Color PrimaryColorVariant { get; } = Color.FromHex("#3700B3");
        public virtual Color OnPrimaryColor { get; } = Color.FromHex("#FFFFFF");
        public virtual Color SecondaryColor { get; } = Color.FromHex("#03DAC6");
        public virtual Color SecondaryColorVariant { get; } = Color.FromHex("#018786");
        public virtual Color OnSecondaryColor { get; } = Color.FromHex("#000000");


        public virtual Color BackgroundColor { get; } = Color.FromHex("#FFFFFF");
        public virtual Color OnBackgroundColor { get; } = Color.FromHex("#000000");
        public virtual Color SurfaceColor { get; } = Color.FromHex("#FFFFFF");
        public virtual Color OnSurfaceColor { get; } = Color.FromHex("#000000");
        public virtual Color ErrorColor { get; } = Color.FromHex("#B00020");
        public virtual Color OnErrorColor { get; } = Color.FromHex("#FFFFFF");

        public static void AddColorSchemeComponent(IColorSchemeComponent component)
        {
            component.OnColorSchemeChanged(true);
            s_colorSchemeComponents.Add(component);
            if (component is EvasObject evasObject)
            {
                evasObject.Deleted += OnComponentDeleted;
            }
        }

        public static void RemoveColorSchemeComponent(IColorSchemeComponent component)
        {
            s_colorSchemeComponents.Remove(component);
        }

        static void OnComponentDeleted(object sender, EventArgs e)
        {
            if (sender is IColorSchemeComponent component)
            {
                s_colorSchemeComponents.Remove(component);
            }
        }
    }

    class LightMColors : MColors
    {
        public override Color PrimaryColor { get; } = Color.FromHex("#212121");
        public override Color PrimaryColorVariant { get; } = Color.FromHex("#000000");
        public override Color OnPrimaryColor { get; } = Color.FromHex("#FFFFFF");
        public override Color SecondaryColor { get; } = Color.FromHex("#212121");
        public override Color SecondaryColorVariant { get; } = Color.FromHex("#000000");
        public override Color OnSecondaryColor { get; } = Color.FromHex("#FFFFFF");

        public override Color BackgroundColor { get; } = Color.FromHex("#FFFFFF");
        public override Color OnBackgroundColor { get; } = Color.FromHex("#000000");
        public override Color SurfaceColor { get; } = Color.FromHex("#FFFFFF");
        public override Color OnSurfaceColor { get; } = Color.FromHex("#000000");
        public override Color ErrorColor { get; } = Color.FromHex("#B00020");
        public override Color OnErrorColor { get; } = Color.FromHex("#FFFFFF");
    }

    class DarkMColors : MColors
    {
        public override Color PrimaryColor { get; } = Color.FromHex("#212121");
        public override Color PrimaryColorVariant { get; } = Color.FromHex("#000000");
        public override Color OnPrimaryColor { get; } = Color.FromHex("#FFFFFF");
        public override Color SecondaryColor { get; } = Color.FromHex("#212121");
        public override Color SecondaryColorVariant { get; } = Color.FromHex("#000000");
        public override Color OnSecondaryColor { get; } = Color.FromHex("#FFFFFF");


        public override Color BackgroundColor { get; } = Color.FromHex("#141414");
        public override Color OnBackgroundColor { get; } = Color.FromHex("#FFFFFF");
        public override Color SurfaceColor { get; } = Color.FromHex("#484848");
        public override Color OnSurfaceColor { get; } = Color.FromHex("#FFFFFF");
        public override Color ErrorColor { get; } = Color.FromHex("#C26C7A");
        public override Color OnErrorColor { get; } = Color.FromHex("#FFFFFF");
    }
}