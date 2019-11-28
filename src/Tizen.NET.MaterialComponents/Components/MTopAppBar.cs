using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTopAppBar : MAppBar
    {
        Color _defaultTextColor;
        Color _titleColor = Color.Default;
        
        Label _titleLabel;
        bool _prominent = false;

        public MTopAppBar(EvasObject parent) : base(parent)
        {
            _titleLabel = new Label(this)
            {
                LineWrapType = WrapType.Mixed,
                TextStyle = $"DEFAULT = 'font_size={DefaultValues.AppBar.FontSize}'"
            };

            VisibleItemCount = 2;
            OverflowPopupToDown = true;

            OnColorSchemeChanged(true);
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

        public override void OnColorSchemeChanged(bool fromConstructor = false)
        {
            bool isDefaultTextColor = fromConstructor || _titleColor.IsDefault;

            _defaultTextColor = MColors.Current.OnPrimaryColor;

            if (isDefaultTextColor)
            {
                _titleLabel?.SetPartColor(Parts.Label.Text, _defaultTextColor);
            }

            base.OnColorSchemeChanged(fromConstructor);
        }

        protected override void UpdateChildrenGeometry()
        {
            base.UpdateChildrenGeometry();

            var g = Geometry;
            var padding = DefaultValues.AppBar.Padding;
            var titleSpacing = DefaultValues.AppBar.TitleSpacing;
            var itemWidth = DefaultValues.AppBar.ItemSize;
            var itemHeight = DefaultValues.AppBar.Height - (padding * 2);
            var startY = g.Y + padding;

            var actionButtonsWidth = (ActionButtons.Count > 0) ? (g.Width - ActionButtons[0].Geometry.X) : 0;
            var calculatedtitleWidth = g.Width - padding - itemWidth - titleSpacing - actionButtonsWidth - padding;
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
    }
}
