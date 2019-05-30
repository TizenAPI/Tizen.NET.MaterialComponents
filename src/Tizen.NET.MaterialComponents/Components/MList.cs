using ElmSharp;
using System.Collections.Generic;
using System.IO;

namespace Tizen.NET.MaterialComponents
{
    public class MList : GenList, IColorSchemeComponent
    {
        const int IconSize = 40;

        IList<MItem> _items;
        Color _backgroundColor = Color.Default;
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;
        Color _defaultTextColor;
        Color _defaultActiveBackgroundColor;
        Color _defaultActiveTextColor;

        public MList(EvasObject parent) : base(parent)
        {
            Homogeneous = true;
            MColors.AddColorSchemeComponent(this);
        }

        public override Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Color effectiveColor = _backgroundColor.IsDefault ? _defaultBackgroundColor : _backgroundColor;
                base.BackgroundColor = effectiveColor;
            }
        }

        public IList<MItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                if (_items != null)
                {
                    UpdateItems();
                }
                else
                {
                    Clear();
                }
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
                        item.GenItem.SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
                        item.GenItem.SetPartColor(Parts.Widget.BackgroundPressed, _defaultActiveBackgroundColor);
                        item.GenItem.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColorForDisabled);

                        item.GenItem.SetPartColor(Parts.Widget.Text, _defaultTextColor);
                        item.GenItem.SetPartColor(Parts.Widget.TextPressed, _defaultActiveTextColor);
                    }
                }
            }
        }

        void UpdateItems()
        {
            Clear();

            if (_items.Count > 0)
            {
                foreach (var item in _items)
                {
                    var style = item.Style;
                    var itemStyle = style == MListStyle.OneLine ? Styles.GenListItem.SingleLine : (style == MListStyle.DoubleLine ? Styles.GenListItem.DoubleLine : Styles.GenListItem.TripleLine);

                    var defaultClass = new GenItemClass(itemStyle)
                    {
                        GetTextHandler = (obj, part) =>
                        {
                            if (itemStyle != Styles.GenListItem.SingleLine)
                            {
                                if (part == "elm.text.sub")
                                {
                                    return ((MItem)obj).SubText;
                                }
                                else if (part == "elm.text.meta")
                                {
                                    return ((MItem)obj).MetaText;
                                }
                            }

                            return ((MItem)obj).Title;
                        },
                        GetContentHandler = (obj, part) =>
                        {
                            if (part == "elm.swallow.icon")
                            {
                                if (((MItem)obj).Icon != null)
                                {
                                    var image = new Image(this)
                                    {
                                        MinimumWidth = IconSize,
                                        MinimumHeight = IconSize
                                    };
                                    var result = image.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, ((MItem)obj).Icon));
                                    return image;
                                }

                                return null;
                            }

                            return ((MItem)obj).Control;
                        }
                    };

                    var genItem = Append(defaultClass, item);
                    item.GenItem = genItem;

                    item.GenItem.SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
                    item.GenItem.SetPartColor(Parts.Widget.BackgroundPressed, _defaultActiveBackgroundColor);
                    item.GenItem.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColorForDisabled);

                    item.GenItem.SetPartColor(Parts.Widget.Text, _defaultTextColor);
                    item.GenItem.SetPartColor(Parts.Widget.TextPressed, _defaultActiveTextColor);
                }
            }
        }
    }

    public enum MListStyle
    {
        OneLine,
        DoubleLine,
        TripleLine
    }

    public class MItem
    {
        public MListStyle Style { get; set; }
        public string Icon { get; set; }

        public string Title { get; set; }

        public string SubText { get; set; }

        public string MetaText { get; set; }

        public EvasObject Control { get; set; }

        public MItem(string title, MListStyle style = MListStyle.OneLine)
        {
            Title = title;
            Style = style;
        }

        public MItem(string title, string icon, MListStyle style = MListStyle.OneLine)
        {
            Title = title;
            Icon = icon;
            Style = style;
        }

        internal GenItem GenItem { get; set; }
    }
}
