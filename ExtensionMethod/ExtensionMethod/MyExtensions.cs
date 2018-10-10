using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class MyExtensions
    {
        public static bool IsOdd(this int number)
        {
            return (number % 2) != 0;
        }

        public static int Absolute(this int number)
        {
            return (number >= 0) ? number : -number;
        }

        public static int Add(this int number, int secondNumber)
        {
            return number + secondNumber;
        }

        public static string Concat (this int number, string text)
        {
            return number + text;
        }
    }
}
