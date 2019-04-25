using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, ICompostProducing plant)
        {
          //Ask the user how many plants they want to plant
            Console.Clear();
            Console.WriteLine($"How many {plant.Type} would you like to plant?");

          // store that number in the variable "number"
          // Use Enumberable.Repeat() to put x("number") amount of plants("plant") in new list named "manyPlants"
            Console.Write("> ");
            int number = Int32.Parse(Console.ReadLine());
            List<ICompostProducing> manyPlants = Enumerable.Repeat(plant, number).ToList();

            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if (farm.NaturalFields[i].plantCount() == 1)
                {
                    Console.WriteLine($"{i + 1}. Natural field has ({farm.NaturalFields[i].plantCount()} row of plants)");
                }
                else if (farm.NaturalFields[i].plantCount() < farm.NaturalFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Natural field has ({farm.NaturalFields[i].plantCount()} rows of plants)");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Natural Field is full. ({farm.NaturalFields[i].plantCount()} rows of plants)");
                }
            }

            Console.WriteLine();

            // How can I output the type of plant chosen here?
            Console.WriteLine($"Place the {plant.Type} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;

            // check to see if current plant count plus new list count is less than or equal to capacity.
            if (farm.NaturalFields[choice].plantCount() + manyPlants.Count() <= farm.NaturalFields[choice].Capacity)
            {
                farm.NaturalFields[choice].AddResource(manyPlants);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($@"
~ I'm sorry! That facility can only hold ({farm.NaturalFields[0].Capacity}) plants ~

************************************************************************
**************      Please choose another facility.     ****************
********** If there are no other natural fields, build one.  ***********
************************************************************************

-----------------------((press enter to continue))----------------------
");
                Console.ReadLine();
                Console.Clear();
                // after user hits enter ask if they want to create a new field
                Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Natural Field? |
|         Press 1 for yes or 2 for no           |
 -----------------------------------------------
");
                Console.Write("> ");
                // collect the user's input and store it in the string "input"
                string input = Console.ReadLine();
                // parse the string and create a switch case
                switch (Int32.Parse(input))
                {
                    // create a new GrazingField and add it to the farm.
                    // go to the ChooseGrazingField menu and pass the animal and farm
                    case 1:
                        farm.AddNaturalField(new NaturalField());
                        ChooseNaturalField.CollectInput(farm, plant);
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}
