using ElmSharp;
using System;

namespace Tizen.NET.MaterialComponents
{
    public static class MMenuItem
    {
        public static void InsertDividerAbove(this ContextPopupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            item.SetPartColor(Parts.Menus.Divider, MColors.Current.OnSurfaceColor.WithAlpha(0.12));
        }
    }
}
