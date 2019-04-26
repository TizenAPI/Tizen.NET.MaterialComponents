using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MTooltip
    {
        EvasObject _evasObject;

        public MTooltip(EvasObject parent, string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            _evasObject = parent ?? throw new ArgumentNullException(nameof(parent));
            _evasObject.TooltipStyle = "material";
            _evasObject.TooltipOrientation = TooltipOrientation.Bottom;
            _evasObject.SetTooltipText(text);
        }

        public void UpdateText(string text)
        {
            if (text != null)
            {
                _evasObject?.SetTooltipText(text);
            }
            else
            {
                _evasObject?.UnsetTooltip();
            }
        }

        public void UnSet()
        {
            _evasObject?.UnsetTooltip();
        }

        public void Show()
        {
            _evasObject?.ShowTooltip();
        }

        public void Hide()
        {
            _evasObject?.HideTooltip();
        }
    }
}
