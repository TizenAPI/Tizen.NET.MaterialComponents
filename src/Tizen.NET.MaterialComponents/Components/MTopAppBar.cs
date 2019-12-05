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
            _titleLabel = new Label(this);

            VisibleItemCount = 2;
            OverflowPopupToDown = true;

            OnColorSchemeChanged(true);
        }

        public string Title
        {
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

            var g = _box.Geometry;
            var padding = DefaultValues.AppBar.Padding;
            var titleSpacing = DefaultValues.AppBar.TitleSpacing;
            var itemWidth = DefaultValues.AppBar.ItemSize;
            var itemHeight = DefaultValues.AppBar.Height - (padding * 2);
            var startY = g.Y + padding;

            var actionButtonsWidth = (ActionButtons.Count > 0) ? (g.Width - ActionButtons[0].Geometry.X) : 0;
            var calculatedtitleWidth = g.Width - padding - itemWidth - titleSpacing - actionButtonsWidth - padding;
            var titleX = g.X + padding + itemWidth + titleSpacing;

            if (_prominent)
            {
                var barHeight = DefaultValues.AppBar.ProminentHeight;
                var textBlockHeight = _titleLabel.EdjeObject[Parts.Label.TextEdje].TextBlockFormattedSize.Height;
                textBlockHeight = (textBlockHeight > (itemHeight * 2)) ? itemHeight * 2 : textBlockHeight;
                var titleY = g.Y + barHeight - padding - textBlockHeight;

                _titleLabel.Geometry = new Rect(titleX, titleY, calculatedtitleWidth, textBlockHeight);
                _titleLabel.TextStyle = DefaultValues.AppBar.DefaultTextStyle.Replace("ellipsis=1.0", "wrap=word");
                _titleLabel.LineWrapType = WrapType.Word;
                _titleLabel.IsEllipsis = false;
            }
            else
            {
                _titleLabel.Geometry = new Rect(titleX, startY, calculatedtitleWidth, itemHeight);
                _titleLabel.TextStyle = DefaultValues.AppBar.DefaultTextStyle;
                _titleLabel.IsEllipsis = true;
                _titleLabel.LineWrapType = WrapType.None;
            }
            _titleLabel.Show();
        }
    }
}
