using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Ingredient : Item
    {
        public float PreperationTime {  get; private set; }
        public float BurnTime { get; private set; }

        public Ingredient(int id, string name, string namePlural, float preperationTime, float burnTime)
            : base(id, name, namePlural)
        {
            this.PreperationTime = preperationTime;
            this.BurnTime = burnTime;
        }


    }
   
}
