using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Program
    {
        static int ListCount<T>(List<T> maListe)
        {
            return maListe.Count;
        }


        static void Main(string[] args)
        {

            List<int> maListe = new List<int>();
            maListe.Add(42);


            TypedList<int> maListeTypee = new TypedList<int>();

            maListeTypee.x = 2; // x est maintenant un int d'après la TypeList

            int coutn = ListCount<int>(maListe);


            //---------------------------------------------------------


            Inventory inventaire = new Inventory();
            inventaire.weapons.AddItem(new Weapon
            {
                name = "excalibur",
                strenght = 99
            });

            inventaire.weapons.AddItem(new Weapon
            {
                name = "excalifour",
                strenght = 10
            });


            Potions elixir = new Potions();
            elixir.name = "elixir";
            elixir.useCount = 1;

            // inventaire.weapons.AddItem(elixir)  Ceci ne marche pas car les classes sont typés et le AddItem attend un weapon
            inventaire.consumables.AddItem(elixir);

            Sword woodenSword = new Sword();
            woodenSword.name = "stick";
            woodenSword.strenght = 42;
            inventaire.weapons.AddItem(woodenSword);

    


            //---------------------------------------------------------

        }

        int ListCount<T>(T maListe) where T : List<int>
        {
            return maListe.Count();
        }
    }
}
