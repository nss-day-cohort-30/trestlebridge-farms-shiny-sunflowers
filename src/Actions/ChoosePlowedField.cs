using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeedProducing plant)
        {
            Console.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.NaturalFields[i].plantCount() == 1)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field has ({farm.PlowedFields[i].plantCount()}) plant");
                }
                else if (farm.NaturalFields[i].plantCount() < farm.NaturalFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Plowed Field has ({farm.PlowedFields[i].plantCount()}) plants");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Plowed Field is full. ({farm.PlowedFields[i].plantCount()}) plants");
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the {plant.Type} where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine()) - 1;

                if (farm.PlowedFields[choice].plantCount() < farm.PlowedFields[choice].Capacity)
                {
                    farm.PlowedFields[choice].AddResource(plant);
                }
                else
                {
                    Console.WriteLine($@"
~ I'm sorry! That facility can only hold ({farm.PlowedFields[0].Capacity}) plants ~

************************************************************************
**************      Please choose another facility.     ****************
********** If there are no other natural fields, build one.  ***********
************************************************************************

-----------------------((press enter to continue))----------------------
");
                    Console.ReadLine();
                    ChoosePlowedField.CollectInput(farm, plant);
                }

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                 */
                // farm.PurchaseResource<IGrazing>(animal, choice);

            }
        }
    }
}