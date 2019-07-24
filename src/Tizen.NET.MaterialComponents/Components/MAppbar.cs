using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MAppbar : Box, IColorSchemeComponent
    {
        MTopAppbar _topAppbar;
        MBottomAppbar _bottomAppbar;
        Box _mainContainer;
        EvasObject _main;
        MAppbarMode _placement;
        bool _isTopAppbarPacked;
        bool _isBottomAppbarPacked;

        public MAppbar(EvasObject parent) : base(parent)
        {
            AlignmentX = -1;
            AlignmentY = -1;
            WeightX = 1;
            WeightY = 1;

            _mainContainer = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            _mainContainer.Show();
            PackEnd(_mainContainer);

            MColors.AddColorSchemeComponent(this);
        }

        public MAppbarMode Placement
        {
            get
            {
                return _placement;
            }
            set
            {
                _placement = value;
                UpdateContent();
            }
        }

        public MTopAppbar TopAppbar
        {
            get
            {
                return _topAppbar;
            }
            set
            {
                if (_topAppbar != null)
                {
                    _topAppbar.Hide();
                    _topAppbar.Geometry = new Rect(0, 0, 0, 0);
                    if (_isTopAppbarPacked)
                    {
                        UnPack(_topAppbar);
                        _isTopAppbarPacked = false;
                    }
                }

                _topAppbar = value;

                if (_topAppbar != null)
                {
                    _topAppbar.AlignmentY = 0;
                    _topAppbar.WeightY = 0;
                    UpdateContent();
                }
            }
        }

        public MBottomAppbar BottomAppbar
        {
            get
            {
                return _bottomAppbar;
            }
            set
            {
                if (_bottomAppbar != null)
                {
                    _bottomAppbar.Hide();
                    _bottomAppbar.Geometry = new Rect(0, 0, 0, 0);
                    if (_isBottomAppbarPacked)
                    {
                        UnPack(_bottomAppbar);
                        _isBottomAppbarPacked = false;
                    }
                }

                _bottomAppbar = value;

                if (_bottomAppbar != null)
                {
                    _bottomAppbar.AlignmentY = 1;
                    _bottomAppbar.WeightY = 0;
                    UpdateContent();
                }
            }
        }

        public EvasObject Main
        {
            get
            {
                return _main;
            }
            set
            {
                if (_main != null)
                {
                    _mainContainer.UnPack(_main);
                    _main.Hide();
                }

                _main = value;

                if (_main != null)
                {
                    if (!_main.IsVisible)
                    {
                        _main.Show();
                    }
                    _mainContainer.PackEnd(_main);
                }
            }
        }

        void UpdateContent()
        {
            switch (_placement)
            {
                case MAppbarMode.Top:
                    if (_topAppbar != null)
                    {
                        if (!_topAppbar.IsVisible)
                        {
                            _topAppbar.Show();
                        }
                        if (!_isTopAppbarPacked)
                        {
                            PackStart(_topAppbar);
                            _isTopAppbarPacked = true;
                        }
                    }
                    if (_bottomAppbar != null)
                    {
                        if (_bottomAppbar.IsVisible)
                        {
                            _bottomAppbar.Hide();
                            _bottomAppbar.Geometry = new Rect(0, 0, 0, 0);
                        }
                        if (_isBottomAppbarPacked)
                        {
                            UnPack(_bottomAppbar);
                            _isBottomAppbarPacked = false;
                        }
                    }
                    break;

                case MAppbarMode.Bottom:
                    if (_topAppbar != null)
                    {
                        if (_topAppbar.IsVisible)
                        {
                            _topAppbar.Hide();
                            _topAppbar.Geometry = new Rect(0, 0, 0, 0);
                        }
                        if (_isTopAppbarPacked)
                        {
                            UnPack(_topAppbar);
                            _isTopAppbarPacked = false;
                        }
                    }
                    if (_bottomAppbar != null)
                    {
                        if (!_bottomAppbar.IsVisible)
                        {
                            _bottomAppbar.Show();
                        }
                        if (!_isBottomAppbarPacked)
                        {
                            PackEnd(_bottomAppbar);
                            _isBottomAppbarPacked = true;
                        }
                    }
                    break;

                default:
                    if (_topAppbar != null)
                    {
                        if (!_topAppbar.IsVisible)
                        {
                            _topAppbar.Show();
                        }
                        if (!_isTopAppbarPacked)
                        {
                            PackStart(_topAppbar);
                            _isTopAppbarPacked = true;
                        }
                    }
                    if (_bottomAppbar != null)
                    {
                        if (_bottomAppbar.IsVisible)
                        {
                            _bottomAppbar.Show();
                        }
                        if (!_isBottomAppbarPacked)
                        {
                            PackEnd(_bottomAppbar);
                            _isBottomAppbarPacked = true;
                        }
                    }
                    break;
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            BackgroundColor = MColors.Current.PrimaryColor;
        }
    }

    public enum MAppbarMode
    {
        Pair,
        Top,
        Bottom
    }
}
