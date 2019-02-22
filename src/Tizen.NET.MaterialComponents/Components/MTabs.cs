using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTabs : Toolbar
    {
        MTabsType _type;

        public MTabs(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            SelectionMode = ToolbarSelectionMode.Always;
        }

        public MTabsType Type
        {
            get => _type;
            set
            {
                switch (value)
                {
                    case MTabsType.Fixed:
                        ShrinkMode = ToolbarShrinkMode.Expand;
                        break;
                    case MTabsType.Scrollable:
                        ShrinkMode = ToolbarShrinkMode.Scroll;
                        break;
                }
                _type = value;
            }
        }
    }

    public enum MTabsType
    {
        Fixed,
        Scrollable
    }
}
