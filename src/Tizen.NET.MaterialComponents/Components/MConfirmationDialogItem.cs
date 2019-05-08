using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MConfirmationDialogItem
    {
        public MConfirmationDialogItem(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public string Label { get; internal set; }

        public bool IsSelected
        {
            get
            {
                if(CheckBox is Radio r)
                {
                    return (r.GroupValue == Id);
                }
                else if(CheckBox is Check c)
                {
                    return c.IsChecked;
                }
                return false;
            }
        }

        internal int Id { get; private set; }

        internal EvasObject CheckBox { get; set; }
    }
}
