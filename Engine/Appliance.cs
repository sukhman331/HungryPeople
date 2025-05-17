using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{ 
    public class Appliance : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        
        // Recipe Properties
        public List<Recipe> Recipes { get; private set; }
        public Recipe? ActiveRecipe { get;  set; }
        
        // Mutliplier Properties
        public float PreperationMultiplier { get; private set; }
        public float BurnMultiplier { get; private set; }
        
        // Slot Properties
        private Item? _Slot;
        public string? SlotName => Slot?.Name ?? "No item";
        public Item? Slot
        {
            get { return _Slot; }
            set {
                _Slot = value;
                OnPropertyChanged(nameof(SlotName));
            }
        }
        public List<Type> SlotTypes { get; private set; }
        public bool IsOccupied { get { return Slot != null; } }

        // Timer Properties
        public Timer CookTimer = new();
        public Timer BurnTimer = new();

        public Appliance(int id, string name, float preperationMultiplier, float burnMultiplier, List<Type> slotTypes)
        {
            this.ID = id;
            this.Name = name;
            this.PreperationMultiplier = preperationMultiplier;
            this.BurnMultiplier = burnMultiplier;
            this.Recipes = [];
            this.SlotTypes = slotTypes;
        }
        
        public bool AddToSlot(Item? item) 
        {
            if (IsOccupied)
                return false;

            if (IsItemAllowed(item))
            {
                Slot = item;
                return true;
            }

            return false;
        }
        public Item? RemoveFromSlot()
        {
            Item? itemToReturn = Slot;
            Slot = null;
            
            return itemToReturn;
        }

        public void AddRecipe(Recipe recipe)
        {
            // If recipe already present then dont add it again
            if (Recipes.Any(r => r.ID == recipe.ID)) return;

            Recipes.Add(recipe);
        }
        private bool IsItemAllowed(Item? item)
        {
            return SlotTypes.Any(type => type.IsAssignableFrom(item?.GetType()));
        }

        public void StartCooking()
        {
            if (!IsOccupied) return;

            ActiveRecipe = Recipes.FirstOrDefault(recipe => recipe.Input.ID == Slot.ID); // check if recipe is present
            
            if (ActiveRecipe == null) return;

            float cookingTime = ActiveRecipe.PreperationTime / PreperationMultiplier;

            CookTimer.OnTimerFinished -= OnCookingFinished;
            CookTimer.OnTimerFinished += OnCookingFinished;
            
            CookTimer.Start(cookingTime);
        }

        private void OnCookingFinished()
        {
            if (ActiveRecipe == null || Slot == null || Slot.ID != ActiveRecipe.Input.ID) 
            {
                CookTimer.Stop();
                return;
            }

            Slot = ActiveRecipe.Output;

            if (ActiveRecipe.Stage.CurrentStage == ActiveRecipe.Stage.LastStage)
            {
                if (ActiveRecipe.BurnTime == 0)
                {
                    CookTimer.Stop();
                    return;
                }

                BurnTimer.OnTimerFinished -= OnBurningFinished;
                BurnTimer.OnTimerFinished += OnBurningFinished;

                BurnTimer.Start(ActiveRecipe.BurnTime);

            }
            else
            {
                StartCooking();
                return;
            }
        }
        private void OnBurningFinished()
        {
            if (ActiveRecipe == null || Slot == null || Slot.ID != ActiveRecipe.Input.ID)
            {
                BurnTimer.Stop();
                return;
            }
            
             Slot = ActiveRecipe.BurnOutput;
        }

        // Property Change Binder
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        //public async Task CookAsync()
        //{
        //    if (IsOccupied) return;

        //    bool onLastStage = false;

        //    while (!onLastStage)
        //    {
        //        Recipe? recipe = Recipes.FirstOrDefault(recipe => recipe.IngredientsMatch(Slot)); // check if recipe is present
        //        if (recipe == null) return;

        //        Item? expecped = Slot; // creating a snapshot of Slot

        //        double cookingTime = recipe.PreperationTime / PreperationMultiplier;

        //        if (await WasCookingInterrupted(cookingTime)) return;

        //        Slot = recipe.Output;

        //        if (recipe.Stage.CurrentStage == recipe.Stage.LastStage)
        //        {
        //            onLastStage = true;
        //            return;
        //        }
        //    }
        //}

        //public async Task BurnAsync()
        //{
        //    if (!IsOccupied) return;

        //    Recipe? recipe = Recipes.FirstOrDefault(recipe => recipe.Output == Slot); // getting recipe for food in slot

        //    if (recipe == null || recipe.BurnTime == 0) return;

        //    double cookingTime = recipe.PreperationTime / PreperationMultiplier;

        //    if (await WasCookingInterrupted(cookingTime)) return;

        //    Slot = recipe.BurnOutput;
        //}

        //private async Task<bool> WasCookingInterrupted(double cookingTime)
        //{
        //    int timeElasped = 0;
        //    Item? expecped = Slot;

        //    while (timeElasped < cookingTime * 1000)
        //    {
        //        await Task.Delay(CHECK_INTERVALS);
        //        timeElasped += CHECK_INTERVALS;

        //        if (Slot != expecped) // checking is the ingredients changed during cook
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}


    }
}
