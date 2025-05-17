using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Pantry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Item SourceItem { get; set; }

        public Pantry(int iD, string name, Item sourceItem)
        {
            ID = iD;
            Name = name;
            SourceItem = sourceItem;
        }

        public Item TakeItemFromPantry()
        {
            return SourceItem;
        }

        public bool PutItemInPantry(Item item)
        {
            if (item.ID == ID)
            {
                return true;
            }
            return false;
        }
    }
}
