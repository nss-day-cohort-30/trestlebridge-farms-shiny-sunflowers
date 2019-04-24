using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if (farm.GrazingFields[i].animalCount() == 1)
                {
                    Console.WriteLine($"{i + 1}. Grazing Field has ({farm.GrazingFields[i].animalCount()}) animal");
                }
                else if (farm.GrazingFields[i].animalCount() < farm.GrazingFields[i].Capacity)
                {
                    Console.WriteLine($"{i + 1}. Grazing Field has ({farm.GrazingFields[i].animalCount()}) animals");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Grazing Field is full. ({farm.GrazingFields[i].animalCount()}) animals");
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the {animal.Type} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine()) - 1;

            if (farm.GrazingFields[choice].animalCount() < farm.GrazingFields[choice].Capacity)
            {
                farm.GrazingFields[choice].AddResource(animal);
            }
            else
            {
                Console.WriteLine($@"
*************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other Grazing Fields available, build one.  ****
              ");
                Console.ReadLine();
                Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Grazing Field? |
|         Press 1 for yes or 2 for no           |
 -----------------------------------------------
");
                 Console.Write ("> ");

            string input = Console.ReadLine ();
            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    ChooseGrazingField.CollectInput(farm, animal);
                    break;
                case 2:
                    break;
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