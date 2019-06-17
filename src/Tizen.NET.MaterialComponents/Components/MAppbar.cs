using ElmSharp;
using System;
using System.IO;

namespace Tizen.NET.MaterialComponents
{
    public class MAppbar : Box, IColorSchemeComponent
    {
        EvasObject _parent;
        Naviframe _naviFrame;
        NaviItem _naviItem;
        Box _mainContainer;
        EvasObject _main;

        string _title;
        string _navigationItem;
        string _primaryItem;
        string _secondaryItem;
        string _overflowItem;

        MButton _navigationButton;
        MButton _primaryButton;
        MButton _secondaryButton;
        MButton _overflowButton;

        Image _navigationImage;
        Image _primaryImage;
        Image _secondaryImage;
        Image _overflowImage;

        public MAppbar(EvasObject parent) : base(parent)
        {
            _parent = parent;
            _naviFrame = new Naviframe(parent)
            {
                AlignmentY = -1,
                AlignmentX = -1,
                WeightY = 1,
                WeightX = 1
            };
            _naviFrame.Show();
            _mainContainer = new Box(parent);
            _naviItem = _naviFrame.Push(_mainContainer, _title, Styles.Material);

            PackEnd(_naviFrame);

            MColors.AddColorSchemeComponent(this);
        }

        public EvasObject Main
        {
            get
            {
                return _main;
            }
            set
            {
                _main = value;
                UpdateMain();
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                UpdateTitle();
            }
        }

        public string NavigationItem
        {
            get
            {
                return _navigationItem;
            }
            set
            {
                _navigationItem = value;
                UpdateItem(Parts.NaviItem.NavigationItem, _navigationItem, ref _navigationButton, ref _navigationImage);
            }
        }

        public string PrimaryItem
        {
            get
            {
                return _primaryItem;
            }
            set
            {
                _primaryItem = value;
                UpdateItem(Parts.NaviItem.PrimaryItem, _primaryItem, ref _primaryButton, ref _primaryImage);
            }
        }

        public string SecondaryItem
        {
            get
            {
                return _secondaryItem;
            }
            set
            {
                _secondaryItem = value;
                UpdateItem(Parts.NaviItem.SecondaryItem, _secondaryItem, ref _secondaryButton, ref _secondaryImage);
            }
        }

        public string OverflowItem
        {
            get
            {
                return _overflowItem;
            }
            set
            {
                _overflowItem = value;
                UpdateItem(Parts.NaviItem.OverflowItem, _overflowItem, ref _overflowButton, ref _overflowImage);
            }
        }

        public event EventHandler NavigationItemClicked
        {
            add
            {
                if (_navigationButton != null)
                {
                    _navigationButton.Clicked += value;
                }
            }
            remove
            {
                if (_navigationButton != null)
                {
                    _navigationButton.Clicked -= value;
                }
            }
        }

        public event EventHandler PrimaryItemClicked
        {
            add
            {
                if (_primaryButton != null)
                {
                    _primaryButton.Clicked += value;
                }
            }
            remove
            {
                if (_primaryButton != null)
                {
                    _primaryButton.Clicked -= value;
                }
            }
        }

        public event EventHandler SecondaryItemClicked
        {
            add
            {
                if (_secondaryButton != null)
                {
                    _secondaryButton.Clicked += value;
                }
            }
            remove
            {
                if (_secondaryButton != null)
                {
                    _secondaryButton.Clicked -= value;
                }
            }
        }

        public event EventHandler OverflowItemClicked
        {
            add
            {
                if (_overflowButton != null)
                {
                    _overflowButton.Clicked += value;
                }
            }
            remove
            {
                if (_overflowButton != null)
                {
                    _overflowButton.Clicked -= value;
                }
            }
        }

        void UpdateMain()
        {
            _mainContainer.Clear();
            if (_main != null)
            {
                _mainContainer.PackEnd(_main);
            }
        }

        void UpdateTitle()
        {
            if (_title != null)
            {
                _naviItem.SetPartText(Styles.Default, _title);
            }
            else
            {
                _naviItem.SetPartText(Styles.Default, string.Empty);
            }
        }

        void UpdateItem(string position, string item, ref MButton button, ref Image image)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (button == null)
                {
                    button = new MButton(_parent);
                }

                if (image == null)
                {
                    image = new Image(_parent);
                }
                image.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, item));

                button.SetPartContent(Parts.Widget.Icon, image);
                _naviItem.SetPartContent(position, button);
            }
            else
            {
                _naviItem.SetPartContent(position, null);
                if (button != null)
                {
                    button = null;
                }
                if (image != null)
                {
                    image = null;
                }
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            if (_naviItem != null)
            {
                _naviItem.TitleBarBackgroundColor = MColors.Current.PrimaryColor;
            }
        }
    }
}
