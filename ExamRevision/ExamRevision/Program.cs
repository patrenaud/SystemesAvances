using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExamRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tableau à une dimension -> Lors de la déclaration, la taille n'a pas à être spécifié.
            int[] monTableau;

            // Lorsqu'on instancite le tableau, la taille doit être spécifiée
            monTableau = new int[42];

            // Tableau à 2 dimensions
            int[,] monTableau2D;
            monTableau2D = new int[42, 10];
            monTableau2D[3, 5] = 100;
            
           /* for(int i = 0; i < monTableau2D.GetLength(0); i++)
            {
                for(int j = 0; j < monTableau2D.GetLength(1); j++)
                {
                    Console.WriteLine(monTableau2D[i, j]);
                }
            }*/

            // Déclaration de tableau de string 5 x 10
            string[,] tabString = new string[5, 10];


            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------


            // On peut créer un instance de InventorySection de type Weapon
            // parce que weapon hérite de InventoryItem.
            InventorySection<Weapon> weapons = new InventorySection<Weapon>();
            weapons.Add(new Weapon());

            InventorySection<Potion> mesPotions = new InventorySection<Potion>();
            mesPotions.Add(new Potion());


            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------
            // Serialization

            string fileContent = File.ReadAllText("people.json");
            Person[] people = JsonConvert.DeserializeObject<Person[]>(fileContent);

            foreach (Person person in people)
            {
                Console.WriteLine($"name: {person.first_name}");
                Console.WriteLine($"Last name: {person.last_name}");
                Console.WriteLine($"genre: {person.genre}");
                Console.WriteLine($"age: {person.age}");
            }


            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------
            // LinQ

            // IEnumerable<x> ma Querry = from x in list
            //                          where x.age > 10
            //                          OrderBy x.age
            //                          Select x (pour le retour)

            IEnumerable<Person> myPeople = from person in people
                                           where person.age >= 18
                                           orderby person.age
                                           select person;
            foreach (Person adult in myPeople)
            {
                Console.WriteLine($"name: {adult.first_name} age: {adult.age}");
            }


            IEnumerable<int> ages = from person in people
                                           where person.age >= 18
                                           orderby person.age
                                           select person.age;
            foreach (int age in ages)
            {
                Console.WriteLine($"age: {age}");
            }

            // Dernier type du Func est la valeure de retour
            Func<int, int, int> myFunc = (int a, int b) => { return a + b; };
            Func<int, int, int> myFunc2 = (a, b) => a + b;

            Console.WriteLine("result: " + myFunc(2,5));

            // --------------------------------------------------------------------------------------------------------
            // Attributes
            // --------------------------------------------------------------------------------------------------------
            // Pour aller chercher des infos sur le code au runtime (des attributes) on utilise la Réflexion.
            // 

            Console.WriteLine("42 is even? " + 42.IsEven());



            Console.ReadKey();
        }

        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------
        // Attributes

        // Doit être membre d'une classe.


        [Attributes("Ceci est une méthode")]
        void MaMethode()
        {

        }

        [Attributes]
        void MaMethode2()
        {

        }
    }
}
