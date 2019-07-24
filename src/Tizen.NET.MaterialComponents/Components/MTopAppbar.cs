using ElmSharp;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NET.MaterialComponents
{
    public class MTopAppbar : Box, IColorSchemeComponent
    {
        Label _title;
        Color _titleColor;
        MButton _navigationItem;
        MButton _overflowItem;
        IList<MButton> _actionItems;
        bool _prominent;

        public MTopAppbar(EvasObject parent) : base(parent)
        {
            AlignmentX = -1;
            AlignmentY = 0;
            WeightX = 1;
            WeightY = 1;
            MinimumHeight = Parts.AppBar.DefaultHeight;

            SetLayoutCallback(() =>
            {
                UpdateChildGeometry();
            });

            _title = new Label(parent)
            {
                MinimumHeight = Parts.AppBar.ItemSize
            };
            _title.Show();

            _actionItems = new List<MButton>();

            MColors.AddColorSchemeComponent(this);
        }

        public string Title
        {
            get
            {
                return _title.Text;
            }
            set
            {
                _title.Text = value;
                UpdateChildGeometry();
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
                UpdateTitleStyle();
            }
        }

        public MButton NavigationItem
        {
            get
            {
                return _navigationItem;
            }
            set
            {
                if (_navigationItem != null)
                {
                    _navigationItem.Hide();
                }

                _navigationItem = value;

                if (_navigationItem != null)
                {
                    _navigationItem.Show();
                    UpdateChildGeometry();
                }
            }
        }

        public MButton OverflowItem
        {
            get
            {
                return _overflowItem;
            }
            set
            {
                if (_overflowItem != null)
                {
                    _overflowItem.Hide();
                }

                _overflowItem = value;

                if (_overflowItem != null)
                {
                    _overflowItem.Show();
                    UpdateChildGeometry();
                }
            }
        }

        public IList<MButton> ActionItems
        {
            get
            {
                return _actionItems;
            }
            set
            {
                foreach (var a in _actionItems)
                {
                    a.Hide();
                }

                _actionItems.Clear();
                _actionItems = value;

                foreach (var a in _actionItems)
                {
                    a.Show();
                }
                UpdateChildGeometry();
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
                _prominent = value;
                UpdateProminentGeometry();
            }
        }

        void UpdateTitleStyle()
        {
            var hex = ColorExtensions.ToHex(_titleColor);
            _title.TextStyle = $"DEFAULT = 'color=#{hex} {Parts.AppBar.fontSize}'";
        }

        void UpdateChildGeometry()
        {
            if (Geometry.Width != 0 && Geometry.Height != 0)
            {
                var positionY = Geometry.Y + Parts.AppBar.DefaultPadding;

                if (_navigationItem != null)
                {
                    _navigationItem.MinimumWidth = Parts.AppBar.ItemSize;
                    _navigationItem.MinimumHeight = Parts.AppBar.ItemSize;
                    var positionX = Geometry.X + Parts.AppBar.DefaultPadding;
                    _navigationItem.Geometry = new Rect(positionX, positionY, _navigationItem.MinimumWidth, _navigationItem.MinimumHeight);
                }

                if (_overflowItem != null)
                {
                    _overflowItem.MinimumWidth = Parts.AppBar.ItemSize;
                    _overflowItem.MinimumHeight = Parts.AppBar.ItemSize;
                    var positionX = Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding - _overflowItem.MinimumWidth;
                    _overflowItem.Geometry = new Rect(positionX, positionY, _overflowItem.MinimumWidth, _overflowItem.MinimumHeight);
                }

                MButton pivotItem = null;

                foreach (var a in _actionItems.Reverse())
                {
                    a.MinimumWidth = Parts.AppBar.ItemSize;
                    a.MinimumHeight = Parts.AppBar.ItemSize;
                    var positionX = pivotItem != null ? pivotItem.Geometry.X - Parts.AppBar.ItemPadding - a.MinimumWidth :
                        (_overflowItem != null ? _overflowItem.Geometry.X - Parts.AppBar.ItemPadding - a.MinimumWidth : Geometry.X + Geometry.Width - Parts.AppBar.ItemPadding - a.MinimumWidth);

                    a.Geometry = new Rect(positionX, positionY, a.MinimumWidth, a.MinimumHeight);
                    pivotItem = a;
                }

                if (_title.Text != null)
                {
                    var positionX = _prominent ? Parts.AppBar.DefaultPadding + Parts.AppBar.ProminentPaddingWidht :
                        (_navigationItem != null ? Geometry.X + Parts.AppBar.DefaultPadding + _navigationItem.MinimumWidth + Parts.AppBar.TitlePadding : Geometry.X + Parts.AppBar.TitlePadding);
                    positionY = _prominent ? Geometry.Y + Geometry.Height - Parts.AppBar.ProminentPaddingHeight - _title.MinimumHeight : positionY;
                    var positionWidth = pivotItem != null ? pivotItem.Geometry.X - Parts.AppBar.DefaultPadding :
                        (_overflowItem != null ? _overflowItem.Geometry.X - Parts.AppBar.DefaultPadding : Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding);
                    var titleLenth = _prominent ? _title.MinimumWidth : (positionX + _title.MinimumWidth <= positionWidth ? _title.MinimumWidth : positionWidth - positionX);

                    _title.Geometry = new Rect(positionX, positionY, titleLenth, _title.MinimumHeight);
                }
            }
            else
            {
                if (_navigationItem != null)
                {
                    _navigationItem.Geometry = new Rect(0, 0, 0, 0);
                }
                if (_overflowItem != null)
                {
                    _overflowItem.Geometry = new Rect(0, 0, 0, 0);
                }
                foreach (var a in _actionItems)
                {
                    a.Geometry = new Rect(0, 0, 0, 0);
                }
            }
        }

        void UpdateProminentGeometry()
        {
            var height = _prominent ? Parts.AppBar.ProminentHeight : Parts.AppBar.DefaultHeight;
            MinimumHeight = height;
            Geometry = new Rect(Geometry.X, Geometry.Y, Geometry.Width, height);
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            TitleColor = MColors.Current.OnPrimaryColor;
            BackgroundColor = MColors.Current.PrimaryColor;
        }
    }
}
