using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Cutlery : Item
    {
        public List<Item> ItemsInDish { get; set; }
        public bool IsDirty { get; set; }
        public bool IsEmpty { get { return ItemsInDish.Count == 0; } }
        public float CleaningTime { get; set; }
        public string DisplayName
        {
            get
            {
                if (IsDirty)
                {
                    return $"Dirty {Name}";
                }
                else if (IsEmpty)
                {
                    return Name;
                }
                else
                {
                    return $"{Name} with {string.Join(",", ItemsInDish.Select(i => i.Name))}";
                }
            }
        }

        public event Action? DisplayNameChanged;
        
        public Cutlery(int id, string name, string namePlural, float cleaningTime) : base(id, name, namePlural)
        {
            ItemsInDish = [];
            CleaningTime = cleaningTime;
            IsDirty = false;

            DisplayNameChanged?.Invoke();

        }
        
        public bool AddItem(Item item)
        {
            if (item is Cutlery || IsDirty || ItemsInDish.Any(i => i.ID == item.ID) ) 
                return false;

            ItemsInDish.Add(item);

            DisplayNameChanged?.Invoke();

            return true;
        }

        public bool Clear()
        {
            if (IsEmpty) return false;

            ItemsInDish.Clear();

            DisplayNameChanged?.Invoke();

            return true;
        }
        public void RemoveItem()
        {
            ItemsInDish.Clear();
            DisplayNameChanged?.Invoke();
        }

        public void Clean()
        {
            IsDirty = false;
            DisplayNameChanged?.Invoke();
        }

        public void Dirty()
        {
            IsDirty = true;
            DisplayNameChanged?.Invoke();
        }
    
    }
}
