using System;
using System.Collections.Generic;
using System.Linq;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MConfirmationDialog : MDialog
    {
        IDictionary<int, MConfirmationDialogItem> _itemList = new Dictionary<int, MConfirmationDialogItem>();
        Button _confirmButton;
        Button _cancelButton;
        Box _layout;
        GenList _genList;
        GenItemClass _itemClass;
        int _itemIndex = 0;
        int _maximumHeight = 500;
        int _itemHeight = 120;

        public MConfirmationDialog(EvasObject parent) : base(parent)
        {
            Style = Styles.Popup.Confirmation;

            _layout = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            _layout.Show();

            _genList = new GenList(parent)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentY = -1,
                AlignmentX = -1,
                SelectionMode = GenItemSelectionMode.Always
            };

            _itemClass = new GenItemClass(Styles.GenListItem.Default)
            {
                GetContentHandler = GetContent,
                GetTextHandler = GetText
            };

            _genList.ItemSelected += (s, e) =>
            {
                var item = e.Item.Data as MConfirmationDialogItem;
                if (item.CheckBox is Radio r)
                {
                    r.GroupValue = item.Id;
                }
                else if (item.CheckBox is Check c)
                {
                    c.IsChecked = !c.IsChecked;
                }

                _confirmButton.IsEnabled = (_itemList.Where(kv => kv.Value.IsSelected).Count() > 0);
            };

            OutsideClicked += (s, e) =>
            {
                Dismiss();
            };

            _genList.Show();
            _layout.PackEnd(_genList);

            _confirmButton = new MPopupButton(this);
            _confirmButton.IsEnabled = false;

            _confirmButton.Clicked += (s, e) =>
            {
                Dismiss();
                var selected = _itemList.Where(kv => kv.Value.IsSelected).Select(kv => kv.Value);
                ItemSelected?.Invoke(this, new MConfirmationDialogItemSelectedArgs(selected));
            };

            _cancelButton = new MPopupButton(this);

            _cancelButton.Clicked += (s, e) =>
            {
                Dismiss();
            };

            SetPartContent(Parts.Popup.Button2, _confirmButton);
            SetPartContent(Parts.Popup.Button1, _cancelButton);

            SetContent(_layout);
        }

        public event EventHandler<MConfirmationDialogItemSelectedArgs> ItemSelected;

        public string Title
        {
            get
            {
                return GetPartText(Parts.Popup.Title);
            }
            set
            {
                SetPartText(Parts.Popup.Title, value);
            }
        }

        public string Cancel
        {
            get
            {
                return _cancelButton.Text;
            }
            set
            {
                _cancelButton.Text = value;
            }
        }

        public string Confirm
        {
            get
            {
                return _confirmButton.Text;
            }
            set
            {
                _confirmButton.Text = value;
            }
        }

        public int MaximumContentHeight {
            get
            {
                return _maximumHeight;
            }
            set
            {
                _maximumHeight = value;
                _layout.MinimumHeight = Math.Min(_maximumHeight, (_layout.MinimumHeight + (_itemList.Count * _itemHeight)));
            }
        }

        public bool IsMultiSelection { get; set; }

        public MConfirmationDialogItem AppendItem(string label)
        {
            var mItem = new MConfirmationDialogItem(GetId(), label);
            var item = _genList.Append(_itemClass, mItem);
            _itemList[mItem.Id] = mItem;

            _layout.MinimumHeight = Math.Min(_maximumHeight, _layout.MinimumHeight + _itemHeight);

            return mItem;
        }

        int GetId()
        {
            return _itemIndex++;
        }

        EvasObject GetContent(object data, string part)
        {
            if (part == Parts.GenListItem.Icon)
            {
                var item = data as MConfirmationDialogItem;

                if(IsMultiSelection)
                {
                    var check = new MCheckBox(_genList)
                    {
                        PropagateEvents = false,
                    };

                    check.StateChanged += (s, e) =>
                    {
                        _confirmButton.IsEnabled = (_itemList.Where(kv => kv.Value.IsSelected).Count() > 0);
                    };

                    item.CheckBox = check;
                    return check;
                }
                else
                {
                    var radio = new MRadioButton(_genList)
                    {
                        StateValue = item.Id,
                        GroupValue = -1,
                        PropagateEvents = false,
                    };
                    item.CheckBox = radio;

                    if ((_itemList.Count > 0) && (item.Id > 0))
                    {
                        var prev = _itemList[item.Id - 1].CheckBox as Radio;
                        if (prev != null)
                        {
                            radio.SetGroup(prev);
                        }
                    }

                    radio.ValueChanged += (s, e) =>
                    {
                        _confirmButton.IsEnabled = (_itemList.Where(kv => kv.Value.IsSelected).Count() > 0);
                    };

                    return radio;
                }
            }
            return null;
        }

        string GetText(object data, string part)
        {
            return (data as MConfirmationDialogItem)?.Label;
        }
    }
}
