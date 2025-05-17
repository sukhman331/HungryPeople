using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class World
    {
        public static readonly List<Item> Items = [];
        public static readonly List<Appliance> Appliances = [];
        public static readonly List<Pantry> Pantry = [];
        public static readonly List<Cutlery> Cutleries = [];
        public static readonly List<CutleryStorage> CutleryStorage = [];
        public static readonly List<SanitationStation> SanitationStations = [];
        public static readonly List<Order> Orders = [];

        public static readonly List<Order> CompletedOrders = [];


        public const int ITEM_ID_RAW_STEAK = 1;
        public const int ITEM_ID_RARE_STEAK = 2;
        public const int ITEM_ID_MEDIUM_STEAK = 3;
        public const int ITEM_ID_WELL_DONE_STEAK = 4;
        public const int ITEM_ID_BURNT_STEAK = 5;

        public const int ITEM_ID_GOOD_STEAK = 10;

        public const int ITEM_ID_COFFEE_BEANS = 6;
        public const int ITEM_ID_COFFEE = 7;

        public const int ITEM_ID_PLATE = 8;
        public const int ITEM_ID_MUG = 9;

        public const int STORAGE_ID_PLATE_RACK = 1;

        public const int APPLIANCE_ID_STOVE = 1;
        public const int APPLIANCE_ID_COFFEE_MACHINE = 2;

        public const int PANTRY_ID_STEAK_FRIDGE = 1;

        public const int SANITATION_STATION_ID_SINK = 1;

        public const int RECIPE_ID_RARE_STAKE = 1;
        public const int RECIPE_ID_MEDIUM_STAKE = 2;
        public const int RECIPE_ID_WELL_DONE_STAKE = 3;
        public const int RECIPE_ID_GOOD_STAKE = 3;

        public const int ORDER_ID_RARE_STEAK = 1;
        public const int ORDER_ID_MEDIUM_STEAK = 2;
        public const int ORDER_ID_WELL_DONE_STEAK = 3;

        public const int CUSTOMER_ID = 1;

        static World()
        {
            Populate();
        }

        private static void Populate()
        {
            Cutlery Mug = new (ITEM_ID_MUG, "Mug", "Mugs", 5f);
            Cutlery Plate = new (ITEM_ID_PLATE, "Plate", "Plates", 8f);

            Cutleries.Add(Plate);
            Cutleries.Add(Mug);

            CutleryStorage PlateRack = new (STORAGE_ID_PLATE_RACK, "Plate Rack", Plate, 3);

            CutleryStorage.Add(PlateRack);

            // Rare Steak
            Ingredient RawSteak = new (ITEM_ID_RAW_STEAK, "Raw Steak", "Raw Steaks", 10, 0);

            Food RareSteak = new (ITEM_ID_RARE_STEAK, "Rare Stake", "Rare Stakes");
            Recipe RareStakeRecipe = new(RECIPE_ID_RARE_STAKE, "Rare Stake Recipe", RawSteak, RareSteak, 5f, 0f, (1, 3));

            // Medium steak
            Food MediumSteak = new (ITEM_ID_MEDIUM_STEAK, "Medium Stake", "Medium Stakes");
            Recipe MediumStakeRecipe = new(RECIPE_ID_MEDIUM_STAKE, "Medium Stake Recipe", RareSteak, MediumSteak, 5f, 0f, (2, 3));

            // Well-done steak
            Food WellDoneSteak = new (ITEM_ID_WELL_DONE_STEAK, "Well-Done Steak", "Well-Done Steaks");
            Recipe WellDoneSteakRecipe = new(RECIPE_ID_WELL_DONE_STAKE, "Well-Done Steak Recipe", MediumSteak ,WellDoneSteak, 5f, 5f, (3, 3));

            // Burnt steak
            TrashItem BurntSteak = new (ITEM_ID_BURNT_STEAK, "Burnt Steak", "Burnt Steaks");
            WellDoneSteakRecipe.AddBurnOutput(BurntSteak);

            Items.Add(RawSteak);
            Items.Add(RareSteak);
            Items.Add(BurntSteak);
            Items.Add(MediumSteak);
            Items.Add(WellDoneSteak);

            // Stove 
            Appliance Stove = new (APPLIANCE_ID_STOVE, "Stove", 1, 1, [typeof(Food), typeof(Ingredient)]);
            
            Stove.AddRecipe(RareStakeRecipe);
            Stove.AddRecipe(MediumStakeRecipe);
            Stove.AddRecipe(WellDoneSteakRecipe);
            
            Appliances.Add(Stove);

            // Steak Fridge
            Pantry SteakFridge = new (PANTRY_ID_STEAK_FRIDGE, "Steak Fridge", RawSteak);
            Pantry.Add(SteakFridge);

            // Sink
            SanitationStation Sink = new (SANITATION_STATION_ID_SINK, "Sink", 1);
            SanitationStations.Add(Sink);

            // Orders 
            Order RareSteakOrder = new Order(ORDER_ID_RARE_STEAK, "Rare Steak Order", [RareSteak], Plate, 5f, 1);
            Order MediumSteakOrder = new Order(ORDER_ID_RARE_STEAK, "Medium Steak Order", [MediumSteak], Plate, 5f,  1);
            Order WellDoneSteakOrder = new Order(ORDER_ID_WELL_DONE_STEAK, "Well-Done Steak Order", [WellDoneSteak], Plate, 5f, 1);

            Orders.Add(RareSteakOrder);
            Orders.Add(MediumSteakOrder);
            Orders.Add(WellDoneSteakOrder);
        
        }
        
        // Get By ID
        public static Item GetItemByID(int id)
        { 
            return Items.FirstOrDefault(item => item.ID == id);
        }
        public static Appliance GetApplianceByID(int id) 
        {
            return Appliances.FirstOrDefault(appliance => appliance.ID == id);
        }
        public static Pantry GetPantryByID(int id)
        {
            return Pantry.FirstOrDefault(pantry => pantry.ID == id);
        }
        public static CutleryStorage GetCutleryStorageByID (int id)
        {
            return CutleryStorage.FirstOrDefault(c => c.ID == id);
        }
        public static Cutlery GetCutleryByID(int id)
        {
            return Cutleries.FirstOrDefault(c => c.ID == id);
        }
        public static SanitationStation GetSanitationStationByID(int id)
        {
            return SanitationStations.FirstOrDefault(s => s.ID == id);
        }
    }
}

