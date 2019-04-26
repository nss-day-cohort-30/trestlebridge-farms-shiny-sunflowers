using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, IEggFeatherMeatProducing chicken)
        {
            Console.Clear();

            Console.WriteLine($"How many {chicken.Type}s would you like to add?");

            // store that number in the variable "number"
            // Use Enumberable.Repeat() to put x("number") amount of animals("animal") in new list named "manyAnimals"
            Console.Write("> ");

            int number = Int32.Parse(Console.ReadLine());

            List<IEggFeatherMeatProducing> manyChickens = Enumerable.Repeat(chicken, number).ToList();
            Console.Clear();

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].chickenCount() == 1)
                {
                    Console.WriteLine($"{i + 1}: This chicken house has 1 chicken");
                }
                else if (farm.ChickenHouses[i].chickenCount() < farm.ChickenHouses[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}: Chicken House has ({farm.ChickenHouses[i].chickenCount()}) chickens");
                }
                // else
                // {
                //     Console.WriteLine($"{i + 1}: Chicken House is full. {farm.ChickenHouses[i].chickenCount()}");
                // }
                // }
            }

            Console.WriteLine();

            Console.WriteLine($"Place the Chicken where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;

            if (farm.ChickenHouses[choice].chickenCount() + manyChickens.Count() <= farm.ChickenHouses[choice].Capacity)
            {
                farm.ChickenHouses[choice].AddResource(manyChickens);
            }
            else
            {
                Console.WriteLine($@"
~ I'm sorry! That facility can only hold ({farm.ChickenHouses[0].Capacity}) chickens ~

************************************************************************
**************      Please choose another facility.     ****************
********** If there are no other natural fields, build one.  ***********
************************************************************************

-----------------------((press enter to continue))----------------------
");
                Console.ReadLine();

                // after user hits enter ask if they want to create a new chicken house
                Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Chicken house? |
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
                        farm.AddChickenHouse(new ChickenHouse());
                        Console.Clear();
                        Console.WriteLine("Success! One Chicken House Added. Press enter to continue.");
                        Console.ReadLine();
                        ChooseChickenHouse.CollectInput(farm, chicken);
                        break;
                    case 2:
                        break;
                }

            }
        }
    }
}