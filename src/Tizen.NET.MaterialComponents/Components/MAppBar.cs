using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public abstract class MAppBar : Background, IColorSchemeComponent, IOptionalComponent
    {
        Color _defaultBackground;
        Color _oldBackground;

        MActionItem _naviItem;
        MMenus _moreitemsMenus;
        MButton _naviButton;
        string _bg;
        protected Box _box;

        ObservableCollection<MActionItem> _items = new ObservableCollection<MActionItem>();
        IList<MButton> _actionButtons = new List<MButton>();

        public MAppBar (EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            AlignmentX = -1;
            WeightX = 1;
            MinimumHeight = DefaultValues.AppBar.Height;

            _box = new Box(this)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            SetContent(_box);

            _naviButton = new MButton(_box);

            _items.CollectionChanged += OnItemsCollectionChanged;
            _box.SetLayoutCallback(() => { UpdateChildrenGeometry(); });

            MColors.AddColorSchemeComponent(this);
        }

        public TargetProfile SupportedProfiles => TargetProfile.Mobile;

        protected bool OverflowPopupToDown { get; set; }

        protected int VisibleItemCount { get; set; }

        public IList<MActionItem> ActionItems => _items;

        public MActionItem NavigationItem
        {
            get
            {
                return _naviItem;
            }
            set
            {
                _naviItem = value;

                if (_naviItem == null)
                {
                    _naviButton.Hide();
                }
                else
                {
                    if (!string.IsNullOrEmpty(_naviItem.IconPath))
                    {
                        var icon = new Image(_box);
                        icon.Load(_naviItem.IconPath);
                        _naviButton.Icon = icon;
                    }

                    _naviButton.Clicked += (s, e) =>
                    {
                        (_naviItem as IMActionItemController)?.Activate();
                    };

                    _naviButton.Show();
                }
            }
        }

        protected MButton NaviButton
        {
            get
            {
                return _naviButton;
            }
        }

        protected IList<MButton> ActionButtons
        {
            get
            {
                return _actionButtons;
            }
        }

        public string BackgroundImageFile
        {
            get
            {
                return _bg;
            }
            set
            {
                _bg = value;
                if(!string.IsNullOrEmpty(_bg))
                {
                    _oldBackground = _box.GetPartColor(Parts.Widget.Background);
                    _box.SetPartColor(Parts.Widget.Background, Color.Transparent);
                    File = _bg;
                }
                else
                {
                    _box.SetPartColor(Parts.Widget.Background, _oldBackground);
                }
            }
        }

        public virtual void OnColorSchemeChanged(bool fromConstructor = false)
        {
            bool isDefaultBackground = fromConstructor || _box.GetPartColor(Parts.Widget.Background) == _defaultBackground;

            _defaultBackground = MColors.Current.PrimaryColor;

            if (isDefaultBackground)
            {
                _box.SetPartColor(Parts.Widget.Background, _defaultBackground);
            }
        }

        protected virtual void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateChildrenGeometry();
        }

        protected virtual void UpdateChildrenGeometry()
        {
            var g = _box.Geometry;
            var padding = DefaultValues.AppBar.Padding;
            var itemWidth = DefaultValues.AppBar.ItemSize;
            var itemHeight = DefaultValues.AppBar.Height - (padding * 2);
            var startX = g.X + padding;
            var startY = g.Y + padding;
            var endX = g.X + g.Width - padding;

            UpdateActionButtons();

            _naviButton.SetPartColor(Parts.Widget.Background, Color.Transparent);
            _naviButton.Geometry = new Rect(startX, startY, itemWidth, itemHeight);

            int beforeItemX = endX;
            for (int i = ActionButtons.Count - 1; i >= 0; i--)
            {
                var calculatedWidth = (ActionButtons.Count > VisibleItemCount && i == VisibleItemCount) ? itemWidth / 2 : itemWidth;
                var itemX = (beforeItemX == endX) ? endX - calculatedWidth : (beforeItemX - itemWidth * 2);

                ActionButtons[i].SetPartColor(Parts.Widget.Background, Color.Transparent);
                ActionButtons[i].Geometry = new Rect(itemX, startY, calculatedWidth, itemHeight);
                ActionButtons[i].Show();

                beforeItemX = itemX;
            }
        }

        protected virtual void UpdateActionButtons()
        {
            ResetItems();

            for (int i = 0; i < ActionItems.Count; i++)
            {
                var button = new MButton(_box);
                var item = ActionItems[i];

                if (i < VisibleItemCount)
                {
                    if (!string.IsNullOrEmpty(item.IconPath))
                    {
                        var icon = new Image(_box);
                        icon.Load(item.IconPath);
                        button.Icon = icon;
                    }

                    button.Clicked += (s, e) =>
                    {
                        (item as IMActionItemController)?.Activate();
                    };

                    _actionButtons.Add(button);
                }
                else if (i == VisibleItemCount)
                {
                    var moreIcon = new Image(_box);
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultValues.AppBar.MoreIconPath);
                    moreIcon.Load(stream);
                    button.Icon = moreIcon;

                    if (_moreitemsMenus == null)
                    {
                        _moreitemsMenus = new MMenus(this.Parent);
                    }

                    var popupItem = _moreitemsMenus.Append(item.Text);
                    popupItem.Selected += (sender, args) =>
                    {
                        (item as IMActionItemController)?.Activate();
                        _moreitemsMenus.Hide();
                    };

                    button.Clicked += (s, e) =>
                    {
                        _moreitemsMenus.Show();
                        var moveY = button.Geometry.Y;
                        if (OverflowPopupToDown)
                        {
                            moveY += (button.Geometry.Height + _moreitemsMenus.Geometry.Height + 5);
                        }
                        else
                        {
                            moveY -= 5;
                        }
                        _moreitemsMenus.Move(button.Geometry.X, moveY);
                    };

                    _actionButtons.Add(button);
                }
                else
                {
                    var popupItem = _moreitemsMenus.Append(item.Text);
                    popupItem.Selected += (sender, args) =>
                    {
                        (item as IMActionItemController)?.Activate();
                        _moreitemsMenus.Hide();
                    };
                }
            }
        }

        void ResetItems()
        {
            foreach (var button in _actionButtons)
            {
                button.Unrealize();
            }
            _actionButtons.Clear();

            if (_moreitemsMenus != null)
            {
                _moreitemsMenus.Clear();
            }
        }
    }
}
