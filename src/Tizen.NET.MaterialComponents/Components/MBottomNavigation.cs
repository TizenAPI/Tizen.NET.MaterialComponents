using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MBottomNavigation : MTabs
    {
        public MBottomNavigation(EvasObject parent) : base(parent)
        {
            Type = MTabsType.Fixed;
            AlignmentX = -1;
            AlignmentY = 1;
            WeightX = 1;
            WeightY = 1;
        }

        protected override ToolbarItem OnItemCreated(ToolbarItem item)
        {
            var nItem =  base.OnItemCreated(item);
            nItem.SetPartColor(Parts.ToolbarItem.Underline, MColors.Current.PrimaryColor);

            return nItem;
        }

        protected override void UpdateItemColor(ToolbarItem item, Color oldDefaultBackgroundColor, bool fromConstructor)
        {
            bool isDefaultBackgroundColor = fromConstructor || oldDefaultBackgroundColor == item.GetPartColor(Parts.ToolbarItem.Background);

            if (isDefaultBackgroundColor)
            {
                item.SetPartColor(Parts.ToolbarItem.Background, MColors.Current.PrimaryColor);
                item.SetPartColor(Parts.ToolbarItem.Text, MColors.Current.OnPrimaryColor.WithAlpha(0.32));
                item.SetPartColor(Parts.ToolbarItem.TextSelected, MColors.Current.OnPrimaryColor);
                item.SetPartColor(Parts.ToolbarItem.Underline, MColors.Current.PrimaryColor);
            }
        }
    }
}
