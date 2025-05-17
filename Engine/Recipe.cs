using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Recipe
    { 
        public int ID { get; private set; }
        public string Name { get; private set; }
        public Item Input { get; private set; } 
        public Item BurnOutput { get; private set; }
        public Item Output { get; private set; }
        public float PreperationTime { get; private set; }
        public float BurnTime { get; private set; }
        public (int CurrentStage, int LastStage ) Stage { get; private set; }


        public Recipe(int iD, string name, Item input , Item output, float preperationTime, float burnTime, (int currentStage, int lastStage) stage )
        {
            ID = iD;
            Name = name;
            Input = input;
            Output = output;
            PreperationTime = preperationTime;
            BurnTime = burnTime;
            Stage = stage;
        }
        public void AddBurnOutput(Item burnOutput)
        {
            this.BurnOutput = burnOutput;
        }

        public bool IngredientsMatch(Item? ingredient) 
        {
            return ingredient == Input;
        }
    }
}
