using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, IEggFeatherProducing duck)
        {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].chickenCount() < farm.ChickenHouses[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Duck House ({farm.DuckHouses[i].duckCount()}) ducks");
                }
                else
                {
                    Console.WriteLine($"{i + 1} Duck House is full. ({farm.DuckHouses[i].duckCount()}) ducks");
                }
            }

            Console.WriteLine();


            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the duck where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;


if (farm.DuckHouses[choice].duckCount() < farm.DuckHouses[choice].Capacity)
      {
            farm.DuckHouses[choice].AddResource(duck);
      } else {
          Console.WriteLine($@"
*************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other duck houses available, build one.  ****
");
                Console.ReadLine();
                ChooseDuckHouse.CollectInput(farm, duck);
      }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}