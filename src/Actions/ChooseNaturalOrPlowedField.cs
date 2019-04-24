using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseNaturalOrPlowedField {
        public static void CollectInput (Farm farm, ISeedAndCompostProducing plant) {
            Console.Clear();
            Console.WriteLine ("1. Natural Field");
            Console.WriteLine ("2. Plowed Field");

            Console.WriteLine ();
            Console.WriteLine ("Where would you like to plant them?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (Int32.Parse(choice))
            {
                case 1:
                    ChooseNaturalField.CollectInput(farm, new Sunflower());
                    break;
                case 2:
                    ChoosePlowedField.CollectInput(farm, new Sunflower());
                    break;
                default:
                    break;
            }
        }
    }
}