using System.Collections.Generic;

namespace Tizen.NET.MaterialComponents
{
    public class MDialogItemSelectedArgs
    {
        public MDialogItemSelectedArgs(IEnumerable<MConfirmationDialogItem> items)
        {
            Items = items;
        }

        public IEnumerable<MConfirmationDialogItem> Items { get; private set; }
    }
}
