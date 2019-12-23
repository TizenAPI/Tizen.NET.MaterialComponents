using System;
using System.ComponentModel;

namespace Tizen.NET.MaterialComponents
{
    public class MActionItem : IMActionItemController
    {
        public MActionItem(Action action = null)
        {
            Action = action;
        }

        public MActionItem(string text,  Action action = null)
        {
            Text = text;
            Action = action;
        }

        public MActionItem(string text, string iconPath, Action action = null)
        {
            Text = text;
            IconPath = iconPath;
            Action = action;
        }

        public string Text { get; set; }

        public string IconPath { get; set; }

        public Action Action { get; set; }

        public event EventHandler Clicked;

        protected virtual void OnClicked() => Clicked?.Invoke(this, EventArgs.Empty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        void IMActionItemController.Activate()
        {
            Action?.Invoke();
            OnClicked();
        }
    }
}
