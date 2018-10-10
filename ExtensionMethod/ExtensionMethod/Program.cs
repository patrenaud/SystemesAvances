using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOdd = 7.IsOdd();
            Console.WriteLine($"7 is odd ? {isOdd}");
            


            int absolutevalue = (-8).Absolute();
            Console.WriteLine($"absolute of -8 ? {absolutevalue}");

            

            int sum = 7.Add(42);
            Console.WriteLine(sum);



            string concat = 7.Concat(" is a number");
            Console.WriteLine(concat);

            int? maValue = null;

            Console.ReadKey();
        }
    }
}
