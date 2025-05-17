using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Customer
    {
        public int ID { get; set; }
        public Order? Order { get; set; }
        public bool IsSeated { get; set; }

        public Cutlery? Mouth { get; set; }
        public bool IsMouthOccupied { get { return Mouth != null; } }

        public Customer(int id)
        {
            ID = id;

            Random random = new Random();
            int order = random.Next(World.Orders.Count);

            Order = World.Orders[order];

            //Order = new Order(o.ID, o.Name, o.Food, o.Cutlery, o.ConsumingTime, o.Reward);
        }

        public Timer ConsumingTimer = new();

        public bool AddToMouth(Item item)
        {
            if (IsMouthOccupied)
                return false;

            if (item is not Cutlery) return false;

            Mouth = (Cutlery)item;
            return true;
        }
        public void RemoveFromMouth()
        {
            if (!IsMouthOccupied) return;

            Mouth = null;
        }

        public bool HasRequiredItems()
        {
            if (!IsSeated) return false;

            Debug.WriteLine(Mouth.DisplayName);

            if (Mouth is Cutlery)
            {
                Debug.WriteLine(Mouth.ID != Order.Cutlery.ID);
                Debug.WriteLine(Mouth.IsDirty);
                Debug.WriteLine(Mouth.IsEmpty);
                
                if (Mouth.ID != Order.Cutlery.ID || Mouth.IsDirty || Mouth.IsEmpty
                    ) 
                {
                    Debug.WriteLine("Returning there");
                    return false;
                }
            } else
            {

                Debug.WriteLine("Returning here");
                return false;
            }

            bool r = Order.Food.OrderBy(f => f.ID).SequenceEqual(Mouth.ItemsInDish.OrderBy(f => f.ID));
            
            Debug.WriteLine(r, "r");

            return r;
        }

        // Will be only called if hasRequired it true

        public void StartConsuming()
        {
            if (!IsMouthOccupied || !HasRequiredItems()) return;

            Debug.WriteLine("Mouth is occupied and has required items");

            ConsumingTimer.OnTimerFinished -= OnConsumingFinished;
            ConsumingTimer.OnTimerFinished += OnConsumingFinished;
            
            Debug.WriteLine("Consuming Started");

            ConsumingTimer.Start(Order.ConsumingTime);


        }

        public void OnConsumingFinished()
        {

            Debug.WriteLine(IsMouthOccupied, "Is Mouth Occupied");
            Debug.WriteLine(Mouth is Cutlery);

            if (IsMouthOccupied && Mouth is Cutlery)
            {
                Debug.WriteLine("Consuming Finished");

                Mouth.RemoveItem();
                Mouth.Dirty();

                Order.Completed();
                World.CompletedOrders.Add(Order);

                Order = null;

                IsSeated = false;

            }

            ConsumingTimer.Stop();
            return;
        }

    }
}
