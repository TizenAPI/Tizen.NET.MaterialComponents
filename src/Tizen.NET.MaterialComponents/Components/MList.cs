using ElmSharp;
using System;
using System.Collections.Generic;

namespace Tizen.NET.MaterialComponents
{
    public class MList : GenList, IColorSchemeComponent
    {
        HashSet<GenItem> _realizedItems = new HashSet<GenItem>();
        Color _none = new Color(0, 0, 0, 0);
        Color _oldDefaultBackgroundColor;
        Color _oldDefaultTextColor;
       
        public MList(EvasObject parent) : base(parent)
        {
            MColors.AddColorSchemeComponent(this);
            ItemRealized += OnItemRealized;
            Deleted += OnListDeleted;
        }

        public void OnColorSchemeChanged(bool fromConstructor)
        {
            foreach (var item in _realizedItems)
            {
                UpdateItemColor(item, fromConstructor);
            }

            _oldDefaultBackgroundColor = MColors.Current.SurfaceColor;
            _oldDefaultTextColor = MColors.Current.OnSurfaceColor;
        }

        protected void OnItemRealized(object sender, GenListItemEventArgs e)
        {
            if (!_realizedItems.Contains(e.Item))
            {
                _realizedItems.Add(e.Item);
                UpdateItemColor(e.Item, true);
            }
        }

        protected void OnListDeleted(object sender, EventArgs e)
        {
            _realizedItems.Clear();
        }

        void UpdateItemColor(GenItem item, bool fromConstructor)
        {
            var defaultBackgroundColor = fromConstructor ? _none : _oldDefaultBackgroundColor;
            var defaultTextColor = fromConstructor ? _none : _oldDefaultTextColor;

            var itemBackgroundColor = item.GetPartColor(Parts.Widget.Background);
            var itemTextColor = item.GetPartColor(Parts.Widget.Text);

            if (itemBackgroundColor == defaultBackgroundColor)
            {
                item.SetPartColor(Parts.Widget.Background, MColors.Current.SurfaceColor);
                item.SetPartColor(Parts.Widget.BackgroundPressed, MColors.Current.PrimaryColor.WithAlpha(0.12));
                item.SetPartColor(Parts.Widget.BackgroundDisabled, MColors.Current.SurfaceColor.WithAlpha(0.32));
            }
            else
            {
                item.SetPartColor(Parts.Widget.BackgroundPressed, itemBackgroundColor.WithAlpha(0.12));
                item.SetPartColor(Parts.Widget.BackgroundDisabled, itemBackgroundColor.WithAlpha(0.32));
            }

            if (itemTextColor == defaultTextColor)
            {
                item.SetPartColor(Parts.Widget.Text, MColors.Current.OnSurfaceColor);
                item.SetPartColor(Parts.Widget.TextPressed, MColors.Current.PrimaryColor);
            }
            else
            {
                item.SetPartColor(Parts.Widget.TextPressed, itemTextColor);
            }

        }
    }   
}
