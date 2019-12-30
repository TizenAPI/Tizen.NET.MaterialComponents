using System;
using System.Collections.Generic;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTabs : Widget, IColorSchemeComponent, IOptionalComponent
    {
        Color _defaultBackgroundColor;
        Color _defaultTextColor;
        Color _defaultSelectedTextColor;

        Toolbar _toolbar;
        MTabsType _type;

        List<ToolbarItem> _items = new List<ToolbarItem>();

        public MTabs(EvasObject parent) : base(parent)
        {
            MaterialComponents.VerifyComponentEnabled(this);

            Style = Styles.Material;
            _toolbar.SelectionMode = ToolbarSelectionMode.Always;

            MColors.AddColorSchemeComponent(this);
        }

        public MTabsType Type
        {
            get => _type;
            set
            {
                switch (value)
                {
                    case MTabsType.Fixed:
                        _toolbar.ShrinkMode = ToolbarShrinkMode.Expand;
                        break;
                    case MTabsType.Scrollable:
                        _toolbar.ShrinkMode = ToolbarShrinkMode.Scroll;
                        break;
                }
                _type = value;
            }
        }

        public TargetProfile SupportedProfiles => TargetProfile.Mobile | TargetProfile.TV;

        public ToolbarItem SelectedItem => _toolbar.SelectedItem;

        public ToolbarItem FirstItem => _toolbar.FirstItem;

        public ToolbarItem LastItem => _toolbar.LastItem;

        public event EventHandler<ToolbarItemEventArgs> Selected
        {
            add
            {
                _toolbar.Selected += value;
            }
            remove
            {
                _toolbar.Selected -= value;
            }
        }

        public bool Homogeneous
        {
            get { return _toolbar.Homogeneous; }
            set { _toolbar.Homogeneous = value; }
        }

        public ToolbarIconLookupOrder IconLookupOrder
        {
            get { return _toolbar.IconLookupOrder; }
            set { _toolbar.IconLookupOrder = value; }
        }

        public int ItemsCount => _toolbar.ItemsCount;

        public double ItemAlignment
        {
            get { return _toolbar.ItemAlignment; }
            set { _toolbar.ItemAlignment = value; }
        }

        public bool TransverseExpansion
        {
            get { return _toolbar.TransverseExpansion; }
            set { _toolbar.TransverseExpansion = value; }
        }

        public ToolbarItem FindItemByLabel(string label) => _toolbar.FindItemByLabel(label);

        public ToolbarItem Append(string label, string icon) => OnItemCreated(_toolbar.Append(label, icon));

        public ToolbarItem Append(string label) => OnItemCreated(_toolbar.Append(label));

        public ToolbarItem Prepend(string label) => OnItemCreated(_toolbar.Prepend(label));

        public ToolbarItem Prepend(string label, string icon) => OnItemCreated(_toolbar.Prepend(label, icon));

        public ToolbarItem InsertBefore(ToolbarItem before, string label) => OnItemCreated(_toolbar.InsertBefore(before, label));
        public ToolbarItem InsertBefore(ToolbarItem before, string label, string icon) => OnItemCreated(_toolbar.InsertBefore(before, label, icon));

        public ToolbarItem InsertAfter(ToolbarItem after, string label, string icon) => OnItemCreated(_toolbar.InsertAfter(after, label, icon));

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            bool isDefaultBackgroundColor = fromConstructor || _defaultBackgroundColor == GetPartColor(Parts.Widget.Background);
            var oldDefaultBackgroundColor = _defaultBackgroundColor;

            _defaultBackgroundColor = MColors.Current.PrimaryColor;
            _defaultTextColor = MColors.Current.OnPrimaryColor.WithAlpha(0.32);
            _defaultSelectedTextColor = MColors.Current.OnPrimaryColor;

            if (isDefaultBackgroundColor)
            {
                SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
            }
            foreach (var item in _items)
            {
                UpdateItemColor(item, oldDefaultBackgroundColor, fromConstructor);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            _toolbar = new Toolbar(parent);
            if (_toolbar.RealHandle != _toolbar.Handle)
                RealHandle = _toolbar.RealHandle;
            return _toolbar.Handle;
        }

        protected virtual ToolbarItem OnItemCreated(ToolbarItem item)
        {
            _items.Add(item);
            item.Deleted += OnItemDeleted;
            UpdateItemColor(item, _defaultBackgroundColor, true);
            return item;
        }

        protected virtual void UpdateItemColor(ToolbarItem item, Color oldDefaultBackgroundColor, bool fromConstructor)
        {
            bool isDefaultBackgroundColor = fromConstructor || oldDefaultBackgroundColor == item.GetPartColor(Parts.ToolbarItem.Background);

            if (isDefaultBackgroundColor)
            {
                item.SetPartColor(Parts.ToolbarItem.Background, _defaultBackgroundColor);
                item.SetPartColor(Parts.ToolbarItem.Text, _defaultTextColor);
                item.SetPartColor(Parts.ToolbarItem.TextSelected, _defaultSelectedTextColor);
                item.SetPartColor(Parts.ToolbarItem.Underline, _defaultSelectedTextColor);
            }
        }

        void OnItemDeleted(object sender, EventArgs e)
        {
            _items.Remove(sender as ToolbarItem);
        }
    }

    public enum MTabsType
    {
        Fixed,
        Scrollable
    }
}
