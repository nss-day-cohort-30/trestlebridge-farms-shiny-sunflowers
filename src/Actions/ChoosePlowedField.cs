using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
  public class ChoosePlowedField
  {

    public static void CollectInput(Farm farm, ISeedProducing plant)
    {
      Console.Clear();

      Console.WriteLine($"How many {plant.Type} would you like to plant?");

      // store that number in the variable "number"
      // Use Enumberable.Repeat() to put x("number") amount of plants("plant") in new list named "manyPlants"
      Console.Write("> ");

      int number = Int32.Parse(Console.ReadLine());
      List<ISeedProducing> manyPlants = Enumerable.Repeat(plant, number).ToList();




      for (int i = 0; i < farm.PlowedFields.Count; i++)
      {
        if (farm.PlowedFields[i].plantCount() == 1)
        {
          Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].plantCount()} row of plants)");
        }
        else if (farm.PlowedFields[i].plantCount() < farm.PlowedFields[i].Capacity)
        {
          Console.WriteLine($"{i + 1}. Plowed Field ({farm.PlowedFields[i].plantCount()} rows of plants)");
        }
        else
        {
          Console.WriteLine($"{i + 1}. Plowed Field is full. ({farm.PlowedFields[i].plantCount()} rows of plants)");
        }
      }
      Console.WriteLine();

      // How can I output the type of plant chosen here?
      Console.WriteLine($"Place the {plant.Type} where?");

      Console.Write("> ");
      int choice = Int32.Parse(Console.ReadLine()) - 1;

      if (farm.PlowedFields[choice].plantCount() + manyPlants.Count() <= farm.PlowedFields[choice].Capacity)
      {
        farm.PlowedFields[choice].AddResource(manyPlants);
      }
      else
      {
        Console.Clear();
        Console.WriteLine($@"
~ I'm sorry! That facility can only hold ({farm.PlowedFields[0].Capacity}) plants ~

************************************************************************
**************      Please choose another facility.     ****************
********** If there are no other plowed fields, build one.  ***********
************************************************************************

-----------------------((press enter to continue))----------------------
");
        Console.ReadLine();
        Console.Clear();
        // after user hits enter ask if they want to create a new field
        Console.WriteLine($@"
 _______________________________________________
| Would you like to create a new Plowed Field? |
|         Press 1 for yes or 2 for no           |
 -----------------------------------------------
");
        Console.Write("> ");
        // collect the user's input and store it in the string "input"
        string input = Console.ReadLine();
        // parse the string and create a switch case
        switch (Int32.Parse(input))
        {
          // create a new plowedField and add it to the farm.
          // go to the ChoosePlowedField menu and pass the animal and farm
          case 1:
            farm.AddPlowedField(new PlowedField());
            ChoosePlowedField.CollectInput(farm, plant);
            break;
          case 2:
            break;
        }
      }
    }
  }
}