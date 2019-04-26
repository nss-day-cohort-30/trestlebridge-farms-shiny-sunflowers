using System;
using System.Collections.Generic;
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

      Console.WriteLine($"How many {animal.Type}s would you like to add?");

      // store that number in the variable "number"
      // Use Enumberable.Repeat() to put x("number") amount of plants("plant") in new list named "manyPlants"
      Console.Write("> ");

      int number = Int32.Parse(Console.ReadLine());

      List<IGrazing> manyAnimals = Enumerable.Repeat(animal, number).ToList();


      for (int i = 0; i < farm.GrazingFields.Count; i++)
      {
        if (farm.GrazingFields[i].animalCount() == 1)
        {
          Console.WriteLine($"{i + 1}. Grazing Field ({farm.GrazingFields[i].animalCount()} animal)");
        }
        else if (farm.GrazingFields[i].animalCount() < farm.GrazingFields[i].Capacity)
        {
          Console.WriteLine($"{i + 1}. Grazing Field ({farm.GrazingFields[i].animalCount()} animals)");
        }
        else
        {
          Console.WriteLine($"{i + 1}. Grazing Field is full. ({farm.GrazingFields[i].animalCount()} animals)");
        }
      }

      Console.WriteLine();

      // How can I output the type of animal chosen here?
      Console.WriteLine($"Place the {animal.Type} where?");

      Console.Write("> ");
      int choice = Int32.Parse(Console.ReadLine()) - 1;

      // check if grazingFields is at capacity and if so add an animal


      if (farm.GrazingFields[choice].animalCount()
      + manyAnimals.Count() <= farm.GrazingFields[choice].Capacity)
      {
        farm.GrazingFields[choice].AddResource(manyAnimals);
      }
      else
      // if GrazingFields is at capacity then don't add animal and display this message
      {
        Console.Clear();
        Console.WriteLine($@"
*************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other Grazing Fields available, build one.  ****
-----------------------((press enter to continue))----------------------
              ");
        Console.ReadLine();
        // after user hits enter ask if they want to create a new field
        Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Grazing Field? |
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
            farm.AddGrazingField(new GrazingField());
            ChooseGrazingField.CollectInput(farm, animal);
            break;
          case 2:
            break;
        }

      }
    }
  }
}