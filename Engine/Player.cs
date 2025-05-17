using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : INotifyPropertyChanged
    {   
        private Item? _HandItem;
        public string? HandItemName => (HandItem is Cutlery c) ? c.DisplayName : HandItem?.Name ?? "No item";
        public Item? HandItem { 
            get { return _HandItem; } 
            set
            {
                if (_HandItem is Cutlery oc)
                {
                    oc.DisplayNameChanged -= HandleDisplayNameChanged;
                }
                
                _HandItem = value;
                OnPropertyChanged(nameof(HandItemName));

                if (_HandItem is Cutlery nc)
                {
                    nc.DisplayNameChanged += HandleDisplayNameChanged;
                }
            } 
        }
        public bool IsHandOccupied { get {  return HandItem != null; } }

        public bool AddToHand(Item? item)
        {

            if (HandItem is Cutlery handItem && (item is Food || item is Ingredient))
            {
                return handItem.AddItem(item);
            } 
            else if ((HandItem is Food || HandItem is Ingredient) && item is Cutlery cutlery)
            {
                Item? toAdd = RemoveFromHand();
                HandItem = cutlery;

                return cutlery.AddItem(toAdd);
            }
            else
            {
                HandItem = item;
                return true;
            }
        }

        public Item? RemoveFromHand()
        {
            Item? itemToReturn = HandItem;
            HandItem = null;

            return itemToReturn;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void HandleDisplayNameChanged()
        {
            OnPropertyChanged(nameof(HandItemName)); // tell UI to update
        }
    }
}
