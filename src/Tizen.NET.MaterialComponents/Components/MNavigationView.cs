using System;
using System.Collections.Generic;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MNavigationView : MBox, IColorSchemeComponent
    {
        EvasObject _header;
        GenList _menu;
        Color _backgroundColor = Color.Default;
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;
        Color _defaultTextColor;
        Color _defaultActiveBackgroundColor;
        Color _defaultActiveTextColor;


        List<MItem> _items;
        GenItemClass _defaultClass;

        public MNavigationView(EvasObject parent) : base(parent)
        {
            Initialize(parent);
            LayoutUpdated += (s, e) =>
            {
                UpdateChildGeometry();
            };
            MColors.AddColorSchemeComponent(this);
        }

        public event EventHandler<GenListItemEventArgs> MenuItemSelected;


        public override Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Color effectiveColor = _backgroundColor.IsDefault ? _defaultBackgroundColor : _backgroundColor;
                _menu.BackgroundColor = effectiveColor;
            }
        }

        public EvasObject Header
        {
            get
            {
                return _header;
            }
            set
            {
                if (_header != null)
                {
                    UnPack(_header);
                    _header.Hide();
                }
                _header = value;
                if (!_header.IsVisible)
                {
                    _header.Show();
                }
                PackStart(_header);
                UpdateChildGeometry();
            }
        }

        public List<MItem> Menu
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                UpdateMenus();
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            _defaultBackgroundColor = MColors.Current.SurfaceColor;
            _defaultBackgroundColorForDisabled = MColors.Current.SurfaceColor.WithAlpha(0.32);
            _defaultTextColor = MColors.Current.OnSurfaceColor;
            _defaultActiveBackgroundColor = MColors.Current.PrimaryColor.WithAlpha(0.12);
            _defaultActiveTextColor = MColors.Current.PrimaryColor;

            if (_backgroundColor.IsDefault)
            {
                BackgroundColor = _backgroundColor;
            }

            if (_items != null)
            {
                foreach (var item in _items)
                {
                    if (item.GenItem != null)
                    {
                        item.GenItem.SetPartColor("bg_disabled", _defaultBackgroundColorForDisabled);
                        item.GenItem.SetPartColor("active_bg", _defaultActiveBackgroundColor);

                        item.GenItem.SetPartColor("text", _defaultTextColor);
                        item.GenItem.SetPartColor("icon", _defaultTextColor);
                        item.GenItem.SetPartColor("icon_pressed", _defaultActiveTextColor);
                        item.GenItem.SetPartColor("text_pressed", _defaultActiveTextColor);
                    }
                }
            }
        }

        void Initialize(EvasObject parent)
        {
            _menu = new GenList(parent)
            {
                BackgroundColor = Color.Transparent
            };

            _menu.ItemSelected += (s, e) =>
            {
                MenuItemSelected?.Invoke(this, e);
            };

            _menu.Show();
            PackEnd(_menu);

            _defaultClass = new GenItemClass(Styles.GenListItem.MaterialNavigation)
            {
                GetTextHandler = (obj, part) =>
                {
                    return ((MItem)obj).Title;
                },
                GetContentHandler = (obj, part) =>
                {
                    var icon = ((MItem)obj).Icon;

                    if (icon != null)
                    {
                        var image = new Image(parent);
                        var result = image.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, icon));
                        return image;
                    }
                    else
                    {
                        return null;
                    }
                }
            };
        }

        void UpdateMenus()
        {
            _menu.Clear();

            if (_items != null)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    var item = _menu.Append(_defaultClass, _items[i]);
                    _items[i].GenItem = item;
                    item.SetPartColor(Parts.Widget.Background, Color.Transparent);
                    item.SetPartColor(Parts.Widget.BackgroundPressed, Color.Transparent);
                    item.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColorForDisabled);
                    item.SetPartColor(Parts.GenListItem.BackgroundActivated, _defaultActiveBackgroundColor);

                    item.SetPartColor(Parts.Widget.Text, _defaultTextColor);
                    item.SetPartColor(Parts.Widget.TextPressed, _defaultActiveTextColor);
                    item.SetPartColor(Parts.Widget.Icon, _defaultTextColor);
                    item.SetPartColor(Parts.Widget.IconPressed, _defaultActiveTextColor);
                }
            }
        }

        void UpdateChildGeometry()
        {
            int headerHeight = 0;
            if (_header != null)
            {
                headerHeight = _header.MinimumHeight;
                _header.Geometry = new Rect(Geometry.X, Geometry.Y, Geometry.Width, headerHeight);
            }
            _menu.Geometry = new Rect(Geometry.X, Geometry.Y + headerHeight, Geometry.Width, Geometry.Height - headerHeight);
        }
    }

    public class MItem
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public MItem(string title, string icon = null)
        {
            Title = title;
            Icon = icon;
        }

        internal GenItem GenItem { get; set; }
    }
}
