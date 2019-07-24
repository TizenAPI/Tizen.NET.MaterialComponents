using ElmSharp;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NET.MaterialComponents
{
    public class MBottomAppbar : Box, IColorSchemeComponent
    {
        MButton _navigationItem;
        MButton _overflowItem;
        IList<MButton> _actionItems;
        MFloatingActionButton _floatingActionButton;
        MFloatingActionButtonPosition _floatingActionButtonPosition;

        public MBottomAppbar(EvasObject parent) : base(parent)
        {
            AlignmentX = -1;
            AlignmentY = 1;
            WeightX = 1;
            WeightY = 1;
            MinimumHeight = Parts.AppBar.DefaultHeight;
            _floatingActionButtonPosition = MFloatingActionButtonPosition.Center;

            SetLayoutCallback(() =>
            {
                UpdateChildGeometry();
            });

            _actionItems = new List<MButton>();

            MColors.AddColorSchemeComponent(this);
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

        public MFloatingActionButton FloatingActionButton
        {
            get
            {
                return _floatingActionButton;
            }
            set
            {
                if (_floatingActionButton != null)
                {
                    _floatingActionButton.Hide();
                }
                _floatingActionButton = value;

                if (_floatingActionButton != null)
                {
                    _floatingActionButton.Show();
                    UpdateChildGeometry();
                }
            }
        }

        public MFloatingActionButtonPosition FloatingActionButtonPosition
        {
            get
            {
                return _floatingActionButtonPosition;
            }
            set
            {
                _floatingActionButtonPosition = value;
                UpdateChildGeometry();
            }
        }

        void UpdateChildGeometry()
        {
            if (Geometry.Width != 0 && Geometry.Height != 0)
            {
                var positionY = Geometry.Y - Parts.AppBar.DefaultHeight / 2;
                if (_floatingActionButton != null)
                {
                    _floatingActionButton.Resize(Parts.AppBar.DefaultHeight, Parts.AppBar.DefaultHeight);
                    var positionX = (Geometry.Width / 2) - (Parts.AppBar.DefaultHeight / 2);
                    switch (_floatingActionButtonPosition)
                    {
                        case MFloatingActionButtonPosition.Left:
                            positionX = Parts.AppBar.DefaultPadding;
                            _floatingActionButton.Move(positionX, positionY);
                            break;

                        case MFloatingActionButtonPosition.Right:
                            positionX = Geometry.Width - Parts.AppBar.DefaultHeight - Parts.AppBar.DefaultPadding;
                            _floatingActionButton.Move(positionX, positionY);
                            break;

                        default:
                            _floatingActionButton.Move(positionX, positionY);
                            break;
                    }
                }

                positionY = Geometry.Y + Parts.AppBar.DefaultPadding;
                if (_floatingActionButton == null || _floatingActionButtonPosition == MFloatingActionButtonPosition.Center)
                {
                    var positionX = Geometry.X + Parts.AppBar.DefaultPadding;
                    if (_navigationItem != null)
                    {
                        _navigationItem.MinimumWidth = Parts.AppBar.ItemSize;
                        _navigationItem.MinimumHeight = Parts.AppBar.ItemSize;
                        _navigationItem.Geometry = new Rect(positionX, positionY, _navigationItem.MinimumWidth, _navigationItem.MinimumHeight);
                    }

                    if (_overflowItem != null)
                    {
                        _overflowItem.MinimumWidth = Parts.AppBar.ItemSize;
                        _overflowItem.MinimumHeight = Parts.AppBar.ItemSize;
                        positionX = Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding - _overflowItem.MinimumWidth;
                        _overflowItem.Geometry = new Rect(positionX, positionY, _overflowItem.MinimumWidth, _overflowItem.MinimumHeight);
                    }

                    MButton pivotItem = null;

                    foreach (var a in _actionItems.Reverse())
                    {
                        a.MinimumWidth = Parts.AppBar.ItemSize;
                        a.MinimumHeight = Parts.AppBar.ItemSize;
                        positionX = pivotItem != null ? pivotItem.Geometry.X - Parts.AppBar.ItemPadding - a.MinimumWidth :
                            (_overflowItem != null ? _overflowItem.Geometry.X - Parts.AppBar.ItemPadding - a.MinimumWidth : Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding - a.MinimumWidth);

                        a.Geometry = new Rect(positionX, positionY, a.MinimumWidth, a.MinimumHeight);
                        pivotItem = a;
                    }
                }
                else
                {
                    if (_floatingActionButtonPosition == MFloatingActionButtonPosition.Left)
                    {
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
                                (_overflowItem != null ? _overflowItem.Geometry.X - Parts.AppBar.ItemPadding - a.MinimumWidth : Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding - a.MinimumWidth);

                            a.Geometry = new Rect(positionX, positionY, a.MinimumWidth, a.MinimumHeight);
                            pivotItem = a;
                        }

                        if (_navigationItem != null)
                        {
                            _navigationItem.MinimumWidth = Parts.AppBar.ItemSize;
                            _navigationItem.MinimumHeight = Parts.AppBar.ItemSize;
                            var positionX = pivotItem != null ? pivotItem.Geometry.X - Parts.AppBar.ItemPadding - _navigationItem.MinimumWidth :
                                (_overflowItem != null ? _overflowItem.Geometry.X - Parts.AppBar.ItemPadding - _navigationItem.MinimumWidth : Geometry.X + Geometry.Width - Parts.AppBar.DefaultPadding - _navigationItem.MinimumWidth);
                            _navigationItem.Geometry = new Rect(positionX, positionY, _navigationItem.MinimumWidth, _navigationItem.MinimumHeight);
                        }
                    }
                    else
                    {
                        var positionX = Geometry.X + Parts.AppBar.DefaultPadding;
                        if (_navigationItem != null)
                        {
                            _navigationItem.MinimumWidth = Parts.AppBar.ItemSize;
                            _navigationItem.MinimumHeight = Parts.AppBar.ItemSize;
                            _navigationItem.Geometry = new Rect(positionX, positionY, _navigationItem.MinimumWidth, _navigationItem.MinimumHeight);
                        }

                        MButton pivotItem = null;

                        foreach (var a in _actionItems)
                        {
                            a.MinimumWidth = Parts.AppBar.ItemSize;
                            a.MinimumHeight = Parts.AppBar.ItemSize;
                            positionX = pivotItem != null ? pivotItem.Geometry.X + Parts.AppBar.ItemPadding + a.MinimumWidth :
                                (_navigationItem != null ? _navigationItem.Geometry.X + Parts.AppBar.ItemPadding + a.MinimumWidth : positionX);

                            a.Geometry = new Rect(positionX, positionY, a.MinimumWidth, a.MinimumHeight);
                            pivotItem = a;
                        }

                        if (_overflowItem != null)
                        {
                            _overflowItem.MinimumWidth = Parts.AppBar.ItemSize;
                            _overflowItem.MinimumHeight = Parts.AppBar.ItemSize;
                            positionX = pivotItem != null ? pivotItem.Geometry.X + Parts.AppBar.ItemPadding + _overflowItem.MinimumHeight :
                                (_navigationItem != null ? _navigationItem.Geometry.X + Parts.AppBar.ItemPadding + _overflowItem.MinimumWidth : positionX);
                            _overflowItem.Geometry = new Rect(positionX, positionY, _overflowItem.MinimumWidth, _overflowItem.MinimumHeight);
                        }
                    }
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
                if (_floatingActionButton != null)
                {
                    _floatingActionButton.Resize(0, 0);
                }
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            BackgroundColor = MColors.Current.PrimaryColor;
        }
    }

    public enum MFloatingActionButtonPosition
    {
        Left,
        Center,
        Right
    }
}
