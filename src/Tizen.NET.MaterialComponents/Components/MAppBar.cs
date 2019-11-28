using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public abstract class MAppBar : Box
    {
        ObservableCollection<MActionItem> _items = new ObservableCollection<MActionItem>();

        public MAppBar(EvasObject parent) : base(parent)
        {
            AlignmentX = -1;
            WeightX = 1;
            MinimumHeight = DefaultValues.AppBar.Height;

            _items.CollectionChanged += OnItemsCollectionChanged;
            SetLayoutCallback(() => { UpdateChildrenGeometry(); });
        }

        public IList<MActionItem> ActionItems
        {
            get
            {
                return _items;
            }
        }

        protected abstract void UpdateChildrenGeometry();

        protected virtual void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
