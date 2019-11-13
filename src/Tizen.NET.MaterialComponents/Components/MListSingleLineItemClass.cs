using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MListSingleLineItemClass : GenItemClass
    {
        public GetContentDelegate GetIconHandler { get; set; }
        public GetContentDelegate GetMetaControlHandler { get; set; }
        public new GetContentDelegate GetContentHandler { get; set; }

        public MListSingleLineItemClass() : this(Styles.GenListItem.MaterialSingleLine)
        {
        }

        protected MListSingleLineItemClass(string style) : base(style)
        {
            base.GetContentHandler = GetContentCallback;
        }

        private EvasObject GetContentCallback(object data, string part)
        {
            if (part == Parts.GenListItem.Icon)
            {
                return GetIconHandler?.Invoke(data, part);
            }
            else if (part == Parts.GenListItem.MetaControl)
            {
                return GetMetaControlHandler?.Invoke(data, part);
            }

            return GetContentHandler?.Invoke(data, part);
        }
    }
}
