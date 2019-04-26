using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostProducing>
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> _plants = new List<ICompostProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public void AddResource(ICompostProducing plants)
        {
            if (_plants.Count < _capacity)
            {
                _plants.Add(plants);
            }
        }

        public int plantCount()
        {
            return _plants.Count;
        }

        // changed AddResource to only accept a single object and an integer
        public void AddResource(List<ICompostProducing> plants)  // TODO: Take out this method for boilerplate
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            var groupedPlantList = _plants
    .GroupBy(p => p.Type)
    .Select(grp => grp.ToList())
    .ToList();

    for (var i = 0; i < groupedPlantList.Count; i++) {
    Console.WriteLine($"{groupedPlantList[i].Count} {groupedPlantList[i].Type}");
    }

            if (this._plants.Count > 1 || this._plants.Count == 0)
            {
                output.Append($"Natural field {shortId} has {_plants.Count} rows of plants\n");
                this._plants.ForEach(a => output.Append($"   {a}\n"));
    }
            else
            {
                output.Append($"Natural field {shortId} has {this._plants.Count} row of plants\n");
                this._plants.ForEach(a => output.Append($"   {a}\n"));
            }

            return output.ToString();
        }
    }
}
