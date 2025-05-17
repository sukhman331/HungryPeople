using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SanitationStation : INotifyPropertyChanged
    {
        public int ID {  get; set; }
        public string? Name { get; set; }
        
        private Cutlery? _Slot;
        public string? SlotName => Slot?.DisplayName ?? "No item";
        public Cutlery? Slot {
            get { return _Slot; }
            set {

                if (_Slot is Cutlery oc)
                {
                    oc.DisplayNameChanged -= HandleDisplayNameChanged;
                }

                _Slot = value; 
                OnPropertyChanged(nameof(SlotName));

                if (_Slot is Cutlery nc)
                {
                    nc.DisplayNameChanged += HandleDisplayNameChanged;
                }
            }
        }
        public bool IsSlotOccupied { get { return Slot != null; }  }
        public float CleaningMultiplier { get; set; }

        public Timer CleaningTimer = new ();

        public SanitationStation(int id, string name, float cleaningMutliplier) 
        {
            ID = id;
            Name = name;
            CleaningMultiplier = cleaningMutliplier;
        }

        public bool AddToSlot(Cutlery? cutlery)
        {
            if (IsSlotOccupied || !cutlery.IsEmpty ) return false; 

            Slot = cutlery;
            return true;
        }

        public Cutlery? RemoveFromSlot()
        {
            if (!IsSlotOccupied) return null;

            Cutlery? itemToReturn = Slot;
            Slot = null;

            return itemToReturn;
        }

        public void StartCleaning()
        {
            if (IsSlotOccupied && Slot.IsEmpty && Slot.IsDirty)
            {
                CleaningTimer.OnTimerFinished -= OnCleaningFinished;
                CleaningTimer.OnTimerFinished += OnCleaningFinished;

                CleaningTimer.Start(Slot.CleaningTime);
            }
        }
        private void OnCleaningFinished()
        {
            if (IsSlotOccupied) 
            {
                Slot.Clean();
            }

            CleaningTimer.Stop();
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
