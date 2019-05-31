using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MItem
    {
        public MListStyle Style { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string SubText { get; set; }

        public string MetaText { get; set; }

        public EvasObject Control { get; set; }

        internal GenItem GenItem { get; set; }
    }
}
