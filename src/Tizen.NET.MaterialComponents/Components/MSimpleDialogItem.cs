using System;

namespace Tizen.NET.MaterialComponents
{
    public class MSimpleDialogItem 
    {
        public MSimpleDialogItem(string label, string iconPath)
        {
            Label = label;
            IconPath = iconPath;
        }

        public string Label { get; internal set; }

        public string IconPath { get; internal set; }

        public event EventHandler Selected;

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
