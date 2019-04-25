using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;


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
                    Console.WriteLine($"{i + 1}:  This duck house has 1 duck");
                }
                else
                {
                    if (farm.DuckHouses[i].duckCount() < farm.DuckHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1} :  Duck House has {farm.DuckHouses[i].duckCount()} ducks");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} :  Duck House is full {farm.DuckHouses[i].duckCount()}");
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
-----------------------((press enter to continue))----------------------
");
                Console.ReadLine();

                // after user hits enter ask if they want to create a new field
                Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Duck house? |
|         Press 1 for yes or 2 for no           |
 -----------------------------------------------
");
                Console.Write("> ");
                // collect the user's input and store it in the string "input"
                string input = Console.ReadLine();
                // parse the string and create a switch case
                switch (Int32.Parse(input))
                {
                    // create a new chicken house and add it to the farm.
                    // go to the chickenhouse menu and pass the farm and chicken in.
                    case 1:
                        farm.AddDuckHouse(new DuckHouse());
                        ChooseDuckHouse.CollectInput(farm, duck);
                        break;
                    case 2:
                        break;
                }

               ChooseDuckHouse.CollectInput(farm, duck);
            }
            }
        }
    }