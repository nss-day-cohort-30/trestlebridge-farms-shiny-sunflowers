using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class PurchaseSeed {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Sesame");
            Console.WriteLine ("2. Sunflower");
            Console.WriteLine ("3. Wildflower");

            Console.WriteLine ();
            Console.WriteLine ("What are you buying today?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (Int32.Parse(choice))
            {
                case 1:
                    ChoosePlowedField.CollectInput(farm, new Sesame());
                    break;
                case 2:
                    Console.WriteLine ();
                    Console.WriteLine ("Where are you planting it?");

                    Console.Write ("> ");
                    string fieldChoice = Console.ReadLine ();

                    switch (Int32.Parse(fieldChoice)) {
                        case 1:
                        ChooseNaturalField.CollectInput(farm, new Sunflower());
                        break;
                        case 2:
                        ChoosePlowedField.CollectInput(farm, new Sunflower());
                        break;
                    }
                    break;
                case 3:
                    ChooseNaturalField.CollectInput(farm, new Wildflower());
                    break;
                default:
                    break;
            }
        }
    }
}