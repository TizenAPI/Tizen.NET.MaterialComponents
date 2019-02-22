using System;
using System.Collections.Generic;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MNavigationView : MBox
    {
        EvasObject _header;
        GenList _menu;
        Color _backgroundColor = Color.White;

        List<MItem> _items;
        GenItemClass _defaultClass;

        public MNavigationView(EvasObject parent) : base(parent)
        {
            Initialize(parent);
            LayoutUpdated += (s, e) =>
            {
                UpdateChildGeometry();
            };
            base.BackgroundColor = _backgroundColor;
        }

        public event EventHandler<GenListItemEventArgs> MenuItemSelected;

        public override Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                if (value == Color.Default)
                {
                    base.BackgroundColor = Color.White;
                    _menu.BackgroundColor = Color.White;
                    _backgroundColor = Color.White;
                }
                else
                {
                    base.BackgroundColor = value;
                    _menu.BackgroundColor = value;
                    _backgroundColor = value;
                }
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

        void Initialize(EvasObject parent)
        {
            _menu = new GenList(parent)
            {
                BackgroundColor = _backgroundColor
            };

            _menu.ItemSelected += (s, e) =>
                {
                    MenuItemSelected?.Invoke(this, e);
                };

            _menu.Show();
            PackEnd(_menu);

            _defaultClass = new GenItemClass(Styles.MaterialNavigation)
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
    }
}
