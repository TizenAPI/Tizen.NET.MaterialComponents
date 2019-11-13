namespace Tizen.NET.MaterialComponents
{
    public class MListDoubleLineItemClass : MListSingleLineItemClass
    {
        public new GetTextDelegate GetTextHandler { get; set; }
        public GetTextDelegate GetSubTextHandler { get; set; }

        public MListDoubleLineItemClass() : this(Styles.GenListItem.MaterialDoubleLine)
        {
        }

        protected MListDoubleLineItemClass(string style) : base(style)
        {
            base.GetTextHandler = GetTextCallback;
        }

        private string GetTextCallback(object data, string part)
        {
            if (part == Parts.GenListItem.Text)
            {
                return GetTextHandler?.Invoke(data, part);
            }
            else if (part == Parts.GenListItem.SubText)
            {
                return GetSubTextHandler?.Invoke(data, part);
            }

            return null;
        }
    }
}
