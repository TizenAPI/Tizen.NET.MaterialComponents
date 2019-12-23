using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MBottomAppBar : MAppBar
    {
        MFloatingActionButton _floatingActionButton;
        BottomAppBarLayoutOption _layoutOption;

        public MBottomAppBar(EvasObject parent) : base(parent)
        {
            _layoutOption = BottomAppBarLayoutOption.CenteredFAB;

            VisibleItemCount = 1;
            OverflowPopupToDown = false;

            OnColorSchemeChanged(true);
        }

        public BottomAppBarLayoutOption LayoutOption
        {
            get
            {
                return _layoutOption;
            }
            set
            {
                if(_layoutOption != value)
                {
                    _layoutOption = value;
                    UpdateChildrenGeometry();
                }
            }
        }

        public MFloatingActionButton FloatingActionButton
        {
            get
            {
                return _floatingActionButton;
            }
            set
            {
                _floatingActionButton = value;
                if (_floatingActionButton != null)
                {
                    _floatingActionButton.BackgroundColor = Color.Black;
                    _floatingActionButton.Show();
                }

                UpdateChildrenGeometry();
            }
        }

        protected override void UpdateChildrenGeometry()
        {
            var g = Geometry;
            var buttonWidth = DefaultValues.FloatingActionButton.Width;
            var buttonHeight = DefaultValues.FloatingActionButton.Height;
            var padding = DefaultValues.AppBar.Padding;
            var moveX = g.X + (g.Width / 2) - buttonWidth / 2;
            var moveY = g.Y - buttonHeight / 2;

            if (_layoutOption == BottomAppBarLayoutOption.CenteredFAB )
            {
                VisibleItemCount = 1;
                base.UpdateChildrenGeometry();
            }
            else if (_layoutOption == BottomAppBarLayoutOption.EndFAB)
            {
                moveX = g.X + g.Width - padding - buttonWidth;
                VisibleItemCount = 4;
                UpdateItemsGeometry(false);
            }
            else
            {
                VisibleItemCount = DefaultValues.AppBar.MaximumItemCount;
                base.UpdateChildrenGeometry();
            }

            if (_layoutOption != BottomAppBarLayoutOption.NoFAB)
            {
                _floatingActionButton?.Resize(buttonWidth, buttonHeight);
                _floatingActionButton?.Move(moveX, moveY);
                _floatingActionButton?.Show();
            }
            else
            {
                _floatingActionButton?.Hide();
            }

            UpdateNaviActionButton();
        }

        void UpdateNaviActionButton()
        {
            if(_layoutOption == BottomAppBarLayoutOption.EndFAB)
            {
                if (NavigationItem != null)
                {
                    NaviButton.Hide();
                }
            }
            else
            {
                if (NavigationItem != null)
                {
                    NaviButton.Show();
                }
            }
        }

        void UpdateItemsGeometry(bool isRight)
        {
            UpdateActionButtons();

            var g = Geometry;
            var padding = DefaultValues.AppBar.Padding;
            var itemWidth = DefaultValues.AppBar.ItemSize;
            var itemHeight = DefaultValues.AppBar.Height - (padding * 2);
            var startX = g.X + padding;
            var startY = g.Y + padding;
            var endX = g.X + g.Width - padding;

            int beforeItemX = (isRight) ? endX : startX;
            for (int i = 0 ; i < ActionButtons.Count; i++)
            {
                if (i == VisibleItemCount)
                    break;

                ActionButtons[i].Geometry = new Rect(beforeItemX, startY, itemWidth, itemHeight);
                ActionButtons[i].Show();

                beforeItemX  = (isRight) ? beforeItemX - (itemWidth * 2) : beforeItemX + (itemWidth * 2);
            }
        }
    }

    public enum BottomAppBarLayoutOption
    {
        CenteredFAB,
        EndFAB,
        NoFAB
    }
}
