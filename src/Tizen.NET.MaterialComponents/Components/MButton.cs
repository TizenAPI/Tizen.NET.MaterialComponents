using System.Text.RegularExpressions;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MButton : Button
    {
        string _text;
        MButtonTypes _type = MButtonTypes.Contained;

        public MButtonTypes ButtonStyle
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                var str = value.ToUpper();
                if (str.Contains("<") && str.Contains(">"))
                {
                    var tagPattern = @"\<[^<&^>]+\>";
                    str = Regex.Replace(str, tagPattern, m => m.ToString().ToLower());
                }
                base.Text = str;
            }
        }

        public MButton(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
        }
    }

    public enum MButtonTypes
    {
        Contained,
        Text,
        Outlined,
        Toggle
    }
}
