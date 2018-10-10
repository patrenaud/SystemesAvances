using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Inventory
    {

        public readonly InventorySection<ConsumableItems> consumables
            = new InventorySection<ConsumableItems>();

        public readonly InventorySection<Weapon> weapons
            = new InventorySection<Weapon>();
        
    }
}
