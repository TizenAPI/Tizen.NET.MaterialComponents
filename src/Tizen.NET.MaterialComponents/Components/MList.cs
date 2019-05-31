using ElmSharp;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;

namespace Tizen.NET.MaterialComponents
{
    public class MList : GenList, IColorSchemeComponent
    {
        ObservableCollection<MItem> _items;

        Color _backgroundColor = Color.Default;
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;
        Color _defaultTextColor;
        Color _defaultActiveBackgroundColor;
        Color _defaultActiveTextColor;

        public MList(EvasObject parent) : base(parent)
        {
            Homogeneous = true;
            _items = new ObservableCollection<MItem>();
            _items.CollectionChanged += OnItemsCollectionChanged;
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

        public ObservableCollection<MItem> Items
        {
            get
            {
                return _items;
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
                        SetGenItemPartColor(item.GenItem);
                    }
                }
            }
        }

        void AddItem(MItem item, int index)
        {
            var style = item.Style;
            var itemStyle = style == MListStyle.OneLine ? Styles.GenListItem.SingleLine : (style == MListStyle.DoubleLine ? Styles.GenListItem.DoubleLine : Styles.GenListItem.TripleLine);

            var defaultClass = CreateGenItemClass(itemStyle);

            var pivotItem = GetItemByIndex(index);

            if (pivotItem != null)
            {
                item.GenItem = InsertBefore(defaultClass, item, pivotItem);
            }
            else
            {
                item.GenItem = Append(defaultClass, item);
            }
            SetGenItemPartColor(item.GenItem);
        }

        GenItemClass CreateGenItemClass(string itemStyle)
        {
            var defaultClass = new GenItemClass(itemStyle)
            {
                GetTextHandler = (obj, part) =>
                {
                    if (itemStyle != Styles.GenListItem.SingleLine)
                    {
                        if (part == Parts.List.SubText)
                        {
                            return ((MItem)obj).SubText;
                        }
                        else if (part == Parts.List.MetaText)
                        {
                            return ((MItem)obj).MetaText;
                        }
                    }

                    return ((MItem)obj).Title;
                },
                GetContentHandler = (obj, part) =>
                {
                    if (part == Parts.List.Icon)
                    {
                        if (!string.IsNullOrEmpty(((MItem)obj).Icon))
                        {
                            var image = new Image(this)
                            {
                                MinimumWidth = Parts.List.IconSize,
                                MinimumHeight = Parts.List.IconSize
                            };
                            image.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, ((MItem)obj).Icon));
                            return image;
                        }

                        return null;
                    }

                    return ((MItem)obj).Control;
                }
            };

            return defaultClass;
        }

        void SetGenItemPartColor(GenItem item)
        {
            item.SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
            item.SetPartColor(Parts.Widget.BackgroundPressed, _defaultActiveBackgroundColor);
            item.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColorForDisabled);
            item.SetPartColor(Parts.Widget.Text, _defaultTextColor);
            item.SetPartColor(Parts.Widget.TextPressed, _defaultActiveTextColor);
        }

        void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddItem(e.NewItems[0] as MItem, e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Move:
                    var moveItem = e.OldItems[0] as MItem;
                    moveItem.GenItem.Delete();
                    AddItem(moveItem, e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    var removeitem = e.OldItems[0] as MItem;
                    removeitem.GenItem.Delete();
                    break;

                case NotifyCollectionChangedAction.Replace:
                    var oldItem = e.OldItems[0] as MItem;
                    var newItem = e.NewItems[0] as MItem;
                    AddItem(newItem, e.OldStartingIndex);
                    oldItem.GenItem.Delete();
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    break;
            }
        }
    }

    public enum MListStyle
    {
        OneLine,
        DoubleLine,
        TripleLine
    }
}
