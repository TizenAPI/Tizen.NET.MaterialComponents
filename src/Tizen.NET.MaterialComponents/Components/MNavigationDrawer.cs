using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MNavigationDrawer : Box, IOptionalComponent
    {
        MNavigationView _navigationView;
        Box _mainContainer;
        Box _dimArea;
        EvasObject _main;
        Panel _drawer;

        bool _isLock = false;
        double _navigationViewRatio = 0.85;

        public MNavigationDrawer(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            Initialize(parent);
            SetLayoutCallback(() =>
            {
                UpdateChildGeometry();
            });
        }

        public event EventHandler Toggled;

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.TV;

        public MNavigationView NavigationView
        {
            get
            {
                return _navigationView;
            }
            set
            {
                UpdateNavigationView(value);
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
                UpdateMain(value);
            }
        }

        public bool IsOpen
        {
            get
            {
                return _drawer.IsOpen;
            }
            set
            {
                _drawer.IsOpen = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return _isLock;
            }
            set
            {
                _isLock = value;
                _drawer.SetScrollable(!_isLock);
            }
        }

        void Initialize(EvasObject parent)
        {
            _mainContainer = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            _mainContainer.Show();
            PackEnd(_mainContainer);

            _dimArea = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = MColors.Current.OnSurfaceColor.WithAlpha(0.32)
            };
            PackEnd(_dimArea);

            _drawer = new Panel(parent);
            _drawer.SetScrollable(!_isLock);
            _drawer.SetScrollableArea(_navigationViewRatio);
            _drawer.Direction = PanelDirection.Left;
            _drawer.Toggled += (s, e) =>
            {
                UpdateDimArea();
                Toggled?.Invoke(this, e);
            };

            _drawer.Show();
            PackEnd(_drawer);
        }

        void UpdateNavigationView(MNavigationView navigationView)
        {
            if (_navigationView != null)
            {
                _navigationView.Hide();
            }

            _navigationView = navigationView;

            if (_navigationView != null)
            {
                _navigationView.SetAlignment(-1, -1);
                _navigationView.SetWeight(1, 1);
                if (!_navigationView.IsVisible)
                {
                    _navigationView.Show();
                }
                _drawer.SetContent(_navigationView, true);
                UpdateDimArea();
                UpdateNavigationViewGeomatry();
            }
            else
            {
                _drawer.SetContent(null, true);
            }
        }

        void UpdateMain(EvasObject main)
        {
            if (_main != null)
            {
                _mainContainer.UnPack(_main);
                _main.Hide();
            }

            _main = main;

            if (_main != null)
            {
                if (!_main.IsVisible)
                {
                    _main.Show();
                }
                _mainContainer.PackEnd(_main);
            }
        }

        void UpdateDimArea()
        {
            if (_drawer.IsOpen)
            {
                _dimArea.Show();
            }
            else
            {
                _dimArea.Hide();
            }
        }

        void UpdateChildGeometry()
        {
            if (_main != null)
            {
                _mainContainer.Geometry = Geometry;
            }

            UpdateNavigationViewGeomatry();
        }

        void UpdateNavigationViewGeomatry()
        {
            if (_navigationView != null)
            {
                _drawer.Geometry = Geometry;
                _dimArea.Geometry = Geometry;
            }
        }
    }
}
