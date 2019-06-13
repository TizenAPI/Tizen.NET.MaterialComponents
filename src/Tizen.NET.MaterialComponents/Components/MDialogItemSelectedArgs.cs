using System.Collections.Generic;

namespace Tizen.NET.MaterialComponents
{
    public class MConfirmationDialogItemSelectedArgs
    {
        public MConfirmationDialogItemSelectedArgs(IEnumerable<MConfirmationDialogItem> items)
        {
            Items = items;
        }

        public IEnumerable<MConfirmationDialogItem> Items { get; private set; }
    }
}
