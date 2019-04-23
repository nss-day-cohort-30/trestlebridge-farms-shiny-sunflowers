using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput (Farm farm, ICompostProducing plant) {
            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                 Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i].plantCount()}) plants");
            }

            Console.WriteLine ();

            // How can I output the type of plant chosen here?
            Console.WriteLine ($"Place the {plant.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ()) - 1;

            farm.NaturalFields[choice].AddResource(plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}