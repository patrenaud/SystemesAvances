using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string json = JsonConvert.SerializeObject(42);
            Console.WriteLine(json);

            //---

            int[] monArray = new[] { 1, 2, 3, 4 };
            json = JsonConvert.SerializeObject(monArray);
            Console.WriteLine(json);

            //---

            File.WriteAllText("saveGame.json", json);
            */

            //------------------------------ SAVE THE DATA
            {
                SaveData save = new SaveData();
                save.X = 100f;
                save.Y = 150f;
                save.characterLevel = 42;
                save.characterName = "Goro";

                // serialize the save game
                string json = JsonConvert.SerializeObject(save);
                // save the json
                File.WriteAllText("saveGame.json", json);
            }

            //------------------------------- LOAD THE DATA

            {
                string json = File.ReadAllText("saveGame.json");

                SaveData load = JsonConvert.DeserializeObject<SaveData>(json);
            }

            //-------------------------------- LOAD DATA EXERCISE
            {
                string json = File.ReadAllText("people.json");

                MaClass[] people = JsonConvert.DeserializeObject<MaClass[]>(json);

                Console.WriteLine(JsonConvert.SerializeObject(people, Formatting.Indented));
            }
            Console.ReadKey(); // un genre de system pause
        }
    }
}
