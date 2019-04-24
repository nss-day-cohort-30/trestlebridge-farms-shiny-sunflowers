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
                //if single duck - use the singular message
                if (farm.DuckHouses[i].duckCount() == 1)
                {
                    Console.WriteLine("This duck house has 1 duck");
                }
                else
                {
                    if (farm.DuckHouses[i].duckCount() < farm.DuckHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Duck House {farm.DuckHouses[i].duckCount()} ducks");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} Duck House is full {farm.DuckHouses[i].duckCount()}");
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine($"Place the duck where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;
            if (farm.DuckHouses[choice].duckCount() < farm.DuckHouses[choice].Capacity)
            {
                farm.DuckHouses[choice].AddResource(duck);
            }
            else
            {
                Console.WriteLine($@"
*************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other duck houses available, build one.  ****
                        ");
                Console.ReadLine();
                ChooseDuckHouse.CollectInput(farm, duck);
            }
        }
    }
}