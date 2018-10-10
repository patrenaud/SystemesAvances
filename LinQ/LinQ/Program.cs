using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinQ
{
    public class Class1
    {
        
        static void Main(string[] args)
        {
            /*
            int[] maListe = new int[] { 3, 5, 1, 24, 8 };

            IEnumerable<int> maListeFiltree = maListe.Where(IsGreathenThan3);


            foreach (int element in maListe)
            {
                Console.WriteLine($"nombres  = {element}");
            }

            foreach (int element in maListeFiltree)
            {
                Console.WriteLine($"nombres filtrees = {element}");
            }
            */

            IEnumerable<Person> people = new[]
            {
                new Person{name = "Bob", age = 17, sex = 'm'},
                new Person{name = "Sophie", age = 10, sex = 'f'},
                new Person{name = "Frank", age = 25, sex = 'm'},
                new Person{name = "Mario", age = 35, sex = 'm'},
                new Person{name = "Vanessa", age = 34, sex = 'f'},
                new Person{name = "Peach", age = 36, sex = 'f'},
                new Person{name = "Link", age = 12, sex = 'm'},
                new Person{name = "Ash", age = 11, sex = 'm'}
            };

            // Fonction lambda pour aller chercher les personnes ayant un age plus grand que 18
            IEnumerable<Person> adults;
            // adults = people.Where( (p) => { return p.age >= 18; });
            // adults = people.Where(p => p.age >= 18).OrderBy(p => p.name); // Simplified

            int peopleCount = people.Count();

            // LinQ
            adults = from person in people
                     where person.age >= 18
                     orderby person.name ascending // or descending
                     select person;

            
            foreach (Person person in adults)
            {
                Console.WriteLine($"age: {person.age} name: {person.name} sex: {person.sex}");
            }


            IEnumerable<string> names = from person in people
                                        where person.age >= 18
                                        orderby person.name descending
                                        select "name: " + person.name;
            /*
                        // PREDICATES
                        Predicate<Person> isAdult;
                        isAdult = p => p.age >= 18;
                        isAdult = IsAdult;
                        */

            /* Func<Person, bool> isAdult = IsAdult;
             adults = people.Where(isAdult);


             bool val = IsAdult(new Person { name = "Mario", age = 36 });



             Func<int, string> convertToString = x => $"mon int sous forme de string est: _{x}_";
             var maString = convertToString(42);
             Console.WriteLine(maString);


             Action monAction = () => { Console.ReadKey(); };
             monAction();

             Action<string> logString;
             logString = Console.WriteLine;
             logString("Hello World");*/

            Log("HelloWorld", str => File.WriteAllText("log.txt", str));

            Console.ReadKey();
        }

        private static void Log(string str, Action<string> logMethod)
        {
            Console.WriteLine(str);
            if(logMethod != null)
            {
                logMethod(str);
            }
        }

        private static bool IsAdult(Person p)
        {
            return p.age >= 18;
        }

        private static bool IsGreathenThan3(int element)
        {
            return element > 3;
        }
    }
}
