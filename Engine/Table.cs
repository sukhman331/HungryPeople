using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Table : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Customer
        public Customer? Customer { get; set; }
        public Customer? Seat { get; set; }
        public bool IsSeatOccupied { get { return Seat != null; } }
        
        // Slot
        private Item? _Slot;
        public string? SlotName => (Slot is Cutlery c) ? c.DisplayName : Slot?.Name ?? "No item";
        public Item? Slot
        {
            get { return _Slot; }
            set
            {
                if (Slot is Cutlery oc)
                {
                    oc.DisplayNameChanged -= HandleDisplayNameChanged;
                }

                _Slot = value;
                OnPropertyChanged(nameof(SlotName));

                if (Slot is Cutlery nc)
                {
                    nc.DisplayNameChanged += HandleDisplayNameChanged;
                }
            }
        }
        public bool IsSlotOccupied { get { return _Slot != null; } }
        //

        // Generate Customer
        public Customer? GenerateCustomer()
        {
            if (!IsSeatOccupied) 
            {
                Customer c = new(World.CUSTOMER_ID)
                {
                    IsSeated = true
                };

                AddToSeat(c);

                return c;
            }

            return null;
        }
        
        public bool AddToSlot(Item? item)
        {
            if (IsSlotOccupied) return false;

            if (IsSeatOccupied && Seat.Order != null)
            {
                Seat.AddToMouth(item);
            } 
            
            Slot = item;
            return true;

        }
        public Item? RemoveFromSlot()
        {
            if (!IsSlotOccupied) return null;

            if (Seat.ConsumingTimer.IsRunning) return null;
            
                Item? i = Slot;
                Slot = null;
                return i;

        }
        public bool AddToSeat(Customer customer)
        {
            if (IsSeatOccupied) return false;

            Seat = customer;
            return true;
        }
        public bool RemoveFromSeat()
        {
            if (!IsSeatOccupied) return false;

            Seat = null;
            return true;
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
