using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRevision
{
    // Pour une méthode d'extension, la classe et son intérieur doit être static.
    static class MonExtension
    {
        public static bool IsEven(this int x)
        {
            return (x % 2) == 0;
        }
    }
}
