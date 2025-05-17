using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Order : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float  ConsumingTime { get; set; }

        // Slot
        private Item? _Slot;
        public string? SlotName => (Slot is Cutlery c) ? c.DisplayName : Name ?? "No item";
        public Item? Slot
        {
            get { return _Slot; }
            set
            {
                if (_Slot is Cutlery oc)
                {
                    oc.DisplayNameChanged -= HandleDisplayNameChanged;
                }

                Slot = value;
                OnPropertyChanged(nameof(SlotName));

                if (Slot is Cutlery nc)
                {
                    nc.DisplayNameChanged += HandleDisplayNameChanged;
                }
            }
        }
        public bool IsOccupied => Slot != null;
        //

        // Order Completition Items
        public List<Item>? Food { get; set; }
        public Cutlery? Cutlery { get; set; }
        //

        // Order Completition Rewards
        public bool OrderCompleted { get; set; }
        public int Reward { get; set; }



        // Timer
        
        public Order(int iD, string name, List<Item> food, Cutlery? cutlery, float consumingTime, int reward)
        {
            ID = iD;
            Name = name;
            Food = food;
            Cutlery = cutlery;
            ConsumingTime = consumingTime;
            Reward = reward;
            OrderCompleted = false;
        }

        public void Completed()
        {
            OrderCompleted = true;
        }

        //public Order GenerateOrder()
        //{
        //    return new (ID, Name, Food, Cutlery, Reward);
        //}

        //public bool AddToSlot(Item item)
        //{
        //    if (ConsumingTimer.IsRunning)
        //        return false;

        //    if (!IsOccupied)
        //    {
        //        Slot = item;
        //        return true;
        //    }

        //    return false;
        //}

        //public Item? RemoveFromSlot()
        //{
        //    if (ConsumingTimer.IsRunning)
        //        return null;

        //    if (IsOccupied)
        //    {
        //        Item? i = Slot;
        //        Slot = null;
        //        return i;
        //    }

        //    return null;

        //}

        //public bool HasRequiredItems(Item? item)
        //{
        //    if (item is not Cutlery cutlery || 
        //        cutlery != Cutlery || 
        //        cutlery.IsDirty || 
        //        cutlery.IsEmpty) return false; // check if correct cutlery is present

        //    return Food.OrderBy(f => f).SequenceEqual(cutlery.ItemsInDish.OrderBy(f => f));
        //}

        //// Will be only called if hasRequired it true
        
        //public void StartConsuming()
        //{
        //    if (!IsOccupied && !HasRequiredItems(Slot)) return;

        //    ConsumingTimer.OnTimerFinished -= OnConsumingFinished;
        //    ConsumingTimer.OnTimerFinished += OnConsumingFinished;

        //    ConsumingTimer.Start(ConsumingTime);
        
        //}

        //public void OnConsumingFinished()
        //{
        //    if (IsOccupied && Slot is Cutlery cutlery)
        //    {
        //        cutlery.RemoveItem();
        //        cutlery.Dirty();
        //    }

        //    ConsumingTimer.Stop();
        //    return;
        //}

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
