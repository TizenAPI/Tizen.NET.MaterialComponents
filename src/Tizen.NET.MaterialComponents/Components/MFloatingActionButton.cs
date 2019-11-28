using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MFloatingActionButton : IColorSchemeComponent
    {
        Color _defaultBackground;
        Color _defaultBackgroundForDisable;
        Color _defaultBackgroundForPressed;
        Box _box = null;
        Button _button = null;
        Image _icon = null;

        public MFloatingActionButton(MConformant conformant)
        {
            _button = new Button(conformant.FloatingLayout)
            {
                Style = Styles.Button.FloatingButton,
            };
            _button.Clicked += (s, e) => { Clicked?.Invoke(this, EventArgs.Empty); };

            _box = conformant.FloatingLayout as Box;
            _box.PackEnd(_button);
            _box.RepeatEvents = true;
            _box.SetLayoutCallback(() => { });

            MColors.AddColorSchemeComponent(this);
        }

        public event EventHandler Clicked;

        public Color BackgroundColor
        {
            get
            {
                return _button.BackgroundColor;
            }
            set
            {
                _button.BackgroundColor = value;
            }
        }


        public Image Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                _button.SetPartContent(Parts.Widget.Icon, _icon);
            }
        }

        public void Show()
        {
            _button.Show();
        }

        public void Move(int x, int y)
        {
            _button.Move(x, y);
        }

        public void Resize(int x, int y)
        {
            _button.Resize(x, y);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackground = fromConstructor || _button.GetPartColor(Parts.Widget.Background) == _defaultBackground;

            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultBackgroundForPressed = MColors.Current.PrimaryColor.WithAlpha(0.32);
            _defaultBackgroundForDisable = MColors.Current.OnSurfaceColor.WithAlpha(0.12);

            if (isDefaultBackground)
            {
                _button.SetPartColor(Parts.Widget.Background, _defaultBackground);
                _button.SetPartColor(Parts.Widget.BackgroundPressed, _defaultBackground);
                _button.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundForDisable);
            }
        }
    }
}
