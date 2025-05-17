using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Food : Item
    {
        public List<Cutlery> Cuttlery { get; set; }

        public Food(int id, string name, string namePlural) : base(id, name, namePlural)
        {
            Cuttlery = [];
        }

        public void AddCutlery (Cutlery cutlery)
        {
            Cuttlery.Add(cutlery);
        }

    }
}
