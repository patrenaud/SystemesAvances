using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
        // L'item T doit hériter de InventoryItems
    class InventorySection<T> where T : InventoryItems
    {

        private readonly List<T> itemList = new List<T>();


        public void AddItem(T item)
        {
            if(typeof(T) == typeof(Weapon))
            {
                // ajouter qqch
            }


            itemList.Add(item);
        }


        public T[] GetItems()
        {
            return itemList.ToArray();
        }

    }
}
