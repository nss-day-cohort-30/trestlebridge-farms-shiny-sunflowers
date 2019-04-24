using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, IEggFeatherMeatProducing chicken)
        {
            Console.Clear();

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].chickenCount() == 1)
                {
                    Console.WriteLine("This chicken house has 1 chicken");
                }
                else
                {

                    if (farm.ChickenHouses[i].chickenCount() < farm.ChickenHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Chicken House ({farm.ChickenHouses[i].chickenCount()}) chickens");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} Chicken House is full. {farm.ChickenHouses[i].chickenCount()}");
                    }
                }

            }

            Console.WriteLine();

            Console.WriteLine($"Place the Chicken where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;

            if (farm.ChickenHouses[choice].chickenCount() < farm.ChickenHouses[choice].Capacity)
            {
                farm.ChickenHouses[choice].AddResource(chicken);
            }
            else
            {
                Console.WriteLine($@"
*************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other chicken houses available, build one.  ****
");
                Console.ReadLine();
                ChooseChickenHouse.CollectInput(farm, chicken);
            }



        }
    }
}