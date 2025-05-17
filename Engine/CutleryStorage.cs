using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CutleryStorage : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Cutlery Holds { get; set; }
        public int MaxCapcity { get; set; }
        private int _CurrentCount;
        public int CurrentCount {
            get { return _CurrentCount; }
            set {

                _CurrentCount = value;
                OnPropertyChanged(nameof(CurrentCount));
            }
        }

        public CutleryStorage(int id, string name, Cutlery holds, int capacity ) 
        {
            ID = id;
            Name = name;
            Holds = holds;
            MaxCapcity = capacity;      
            CurrentCount = capacity;
        }

        public Cutlery? Take()
        {
            if (CurrentCount > 0)
            {
                CurrentCount--;
                return new Cutlery(Holds.ID, Holds.Name, Holds.NamePlural, Holds.CleaningTime);
            }

            return null;
        } 

        public bool PutBack(Item? cutlery)
        {
            /* Check if item is 
                - cutlery
                - not null
                - right cutlery
             */

            if (cutlery is not Cutlery || cutlery == null )
                return false;

            Cutlery c = (Cutlery)cutlery;

            if (!c.IsDirty &&  c.IsEmpty && CurrentCount < MaxCapcity)
            {
                CurrentCount++;
                return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
