using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRevision
{
    // classe générique dont le type générique 
    // ne peut être qu'une classe qui hérite d'InventoryItem
    class InventorySection<T> where T : InventoryItem
    {
        List<T> items = new List<T>();

        public void Add(T item)
        {
            // items.Add(item);
        }
    }
}
