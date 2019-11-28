using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTopAppBar : MAppBar, IColorSchemeComponent
    {
        Color _defaultTextColor;
        Color _defaultBackground;
        Color _titleColor = Color.Default;
        
        Label _titleLabel;
        MButton _naviButton;
        MActionItem _naviItem;
        MMenus _moreitemsMenus;
        bool _prominent = false;

        IList<MButton> _actionButtons = new List<MButton>();

        public MTopAppBar(EvasObject parent) : base(parent)
        {
            _titleLabel = new Label(this)
            {
                LineWrapType = WrapType.Mixed,
                TextStyle = $"DEFAULT = 'font_size={DefaultValues.AppBar.FontSize}'"
            };

            _naviButton = new MButton(this);

            MColors.AddColorSchemeComponent(this);
        }

        public string Title {
            get
            {
                return _titleLabel.Text;
            }
            set
            {
                _titleLabel.Text = value;
            }
        }

        public Color TitleColor
        {
            get
            {
                return _titleColor;
            }
            set
            {
                _titleColor = value;
                if(_titleColor.IsDefault)
                {
                    _titleLabel.SetPartColor(Parts.Label.Text, _defaultTextColor);
                }
                else {
                    _titleLabel.SetPartColor(Parts.Label.Text, _titleColor);
                }
            }
        }

        public MActionItem NavigationItem
        {
            get
            {
                return _naviItem;
            }
            set
            {
                _naviItem = value;

                if(_naviItem == null)
                {
                    _naviButton.Hide();
                }
                else
                {
                    if (!string.IsNullOrEmpty(_naviItem.IconPath))
                    {
                        var icon = new Image(this);
                        icon.Load(_naviItem.IconPath);
                        _naviButton.Icon = icon;
                    }

                    _naviButton.Clicked += (s, e) =>
                    {
                        _naviItem.Action?.Invoke();
                    };

                    _naviButton.Show();
                }
            }
        }

        public bool Prominent
        {
            get
            {
                return _prominent;
            }
            set
            {
                if(_prominent != value)
                {
                    _prominent = value;
                    MinimumHeight = _prominent? DefaultValues.AppBar.ProminentHeight : DefaultValues.AppBar.Height;
                    UpdateChildrenGeometry();
                }
            }
        }

        public void OnColorSchemeChanged(bool fromConstructor = false)
        {
            bool isDefaultBackground = fromConstructor || GetPartColor(Parts.Widget.Background) == _defaultBackground;
            bool isDefaultTextColor = fromConstructor || _titleColor.IsDefault;

            // It comes from here
            // https://github.com/material-components/material-components-android/blob/3637c23078afc909e42833fd1c5fd47bb3271b5f/lib/java/com/google/android/material/button/res/color/mtrl_btn_bg_color_selector.xml
            _defaultBackground = MColors.Current.PrimaryColor;
            _defaultTextColor = MColors.Current.OnPrimaryColor;

            if (isDefaultBackground)
            {
                SetPartColor(Parts.Widget.Background, _defaultBackground);
            }

            if (isDefaultTextColor)
            {
                _titleLabel.SetPartColor(Parts.Label.Text, _defaultTextColor);
            }            
        }

        protected override void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateItems();
        }

        protected override void UpdateChildrenGeometry()
        {
            var g = Geometry;
            var padding = DefaultValues.AppBar.Padding;
            var titleSpacing = DefaultValues.AppBar.TitleSpacing;
            var itemWidth = DefaultValues.AppBar.ItemSize;
            var itemHeight = DefaultValues.AppBar.Height - (padding * 2);
            var startX = g.X + padding;
            var startY = g.Y + padding;
            var endX = g.X + g.Width - padding;

            _naviButton.Geometry = new Rect(startX, startY, itemWidth, itemHeight);

            int beforeItemX = endX;
            for (int i = _actionButtons.Count - 1; i >= 0; i--)
            {
                var calculatedWidth = (_actionButtons.Count > 2 && i == 2) ? itemWidth / 2 : itemWidth;
                var itemX = (beforeItemX == endX) ? endX - calculatedWidth : (beforeItemX - itemWidth * 2);

                _actionButtons[i].Geometry = new Rect(itemX, startY, calculatedWidth, itemHeight);
                _actionButtons[i].Show();

                beforeItemX = itemX;
            }

            var actionItemWidth = g.Width - beforeItemX;
            var calculatedtitleWidth = g.Width - padding - itemWidth - titleSpacing - actionItemWidth - padding;
            var titleX = g.X + padding + itemWidth + titleSpacing;

            _titleLabel.Geometry = new Rect(titleX, startY, calculatedtitleWidth, itemHeight);
            _titleLabel.Show();

            if (_prominent)
            {
                var barHeight = DefaultValues.AppBar.ProminentHeight;
                var titleY = g.Y + barHeight - padding - itemHeight;

                Geometry = new Rect(g.X, g.Y, g.Width, barHeight);
                _titleLabel.Geometry = new Rect(titleX, titleY, calculatedtitleWidth, itemHeight);
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

        void UpdateItems()
        {
            ResetItems();

            for (int i = 0; i < ActionItems.Count; i++)
            {
                var button = new MButton(this);
                var item = ActionItems[i];

                if (i < 2) 
                {
                    if (!string.IsNullOrEmpty(item.IconPath))
                    {
                        var icon = new Image(this);
                        icon.Load(item.IconPath);
                        button.Icon = icon;
                    }
                    
                    button.Clicked += (s, e) =>
                    {
                        item.Action?.Invoke();
                    };

                    _actionButtons.Add(button);
                }
                else if( i == 2 )
                {
                    var moreIcon = new Image(this);
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultValues.AppBar.MoreIconPath);
                    moreIcon.Load(stream);
                    button.Icon = moreIcon;

                    if(_moreitemsMenus == null)
                    {
                        _moreitemsMenus = new MMenus(this.Parent);
                    }

                    var popupItem = _moreitemsMenus.Append(item.Text);
                    popupItem.Selected += (sender, args) =>
                    {
                        item.Action?.Invoke();
                        _moreitemsMenus.Hide();
                    };

                    button.Clicked += (s, e) =>
                    {
                        _moreitemsMenus.Show();
                        var moveHegiht = button.Geometry.Y + button.Geometry.Height + _moreitemsMenus.Geometry.Height + 5;
                        _moreitemsMenus.Move(button.Geometry.X, moveHegiht);
                    };

                    _actionButtons.Add(button);
                }
                else 
                {
                    var popupItem = _moreitemsMenus.Append(item.Text);
                    popupItem.Selected += (sender, args) =>
                    {
                        item.Action?.Invoke();
                        _moreitemsMenus.Hide();
                    };
                }
            }

            UpdateChildrenGeometry();
        }
    }
}
