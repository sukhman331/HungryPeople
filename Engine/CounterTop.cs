using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CounterTop : INotifyPropertyChanged
    {
        private Item? _Slot;
        public string? SlotName => (Slot is Cutlery c) ? c.DisplayName : Slot?.Name ?? "No item";
        public Item? Slot {
            get { return _Slot; }
            set 
            {
                if (_Slot is Cutlery oc)
                {
                    oc.DisplayNameChanged -= HandleDisplayNameChanged;
                }

                _Slot = value; 
                OnPropertyChanged(nameof(Slot));
                OnPropertyChanged(nameof(SlotName));

                if (_Slot is Cutlery nc)
                {
                    nc.DisplayNameChanged += HandleDisplayNameChanged;
                }
            }
        }

        public bool IsSlotOccupied { get { return Slot != null; } }

        public bool AddToCounterTop(Item? item)
        {
            if (Slot is Cutlery handCutlery && (item is Food || item is Ingredient)) // cutlery already in hand 
            {
                return handCutlery.AddItem(item);
            }
            else if ((Slot is Food || Slot is Ingredient) && item is Cutlery pickedCutlery) // food already in hand 
            {
                Item? toAdd = RemoveFromCounterTop();
                Slot = pickedCutlery;

                return pickedCutlery.AddItem(toAdd);
            }
            else if (!IsSlotOccupied) // checks if item is already present, if yes then does nothing
            {
                Slot = item;
                return true;
            }

            return false;
        }
        public Item? RemoveFromCounterTop() 
        {

            Item? itemToReturn = Slot;
            Slot = null;
            
            return itemToReturn;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void HandleDisplayNameChanged()
        {
            OnPropertyChanged(nameof(SlotName)); // tell UI to update
        }
    }

}
