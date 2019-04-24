using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
  public class ChooseNaturalField
  {
    public static void CollectInput(Farm farm, ICompostProducing plant)
    {
      Console.Clear();

      for (int i = 0; i < farm.NaturalFields.Count; i++)
      {


        if (farm.NaturalFields[i].plantCount() < farm.NaturalFields[i].Capacity)
        {
          Console.WriteLine($"{i + 1}. Natural field ({farm.NaturalFields[i].plantCount()}) plants");
        }
        else
        {
          Console.WriteLine($"{i + 1}. Natural Field is full. ({farm.NaturalFields[i].plantCount()}) plants");
        }
      }

      Console.WriteLine();

      // How can I output the type of plant chosen here?
      Console.WriteLine($"Place the {plant.Type} where?");

      Console.Write("> ");
      int choice = Int32.Parse(Console.ReadLine()) - 1;

      farm.NaturalFields[choice].AddResource(plant);

      if (farm.NaturalFields[choice].plantCount() < farm.NaturalFields[choice].Capacity)
      {
        farm.NaturalFields[choice].AddResource(plant);
      }
      else
      {
        Console.WriteLine($@"
             *************** I'm sorry, that facility is at capacity. ***************
**************      Please choose another facility.     ****************
******* If there are no other chicken houses available, build one.  ****");
        Console.ReadLine();
        ChooseNaturalField.CollectInput(farm, plant);

      }

      /*
          Couldn't get this to work. Can you?
          Stretch goal. Only if the app is fully functional.
       */
      // farm.PurchaseResource<IGrazing>(animal, choice);

    }
  }
}
