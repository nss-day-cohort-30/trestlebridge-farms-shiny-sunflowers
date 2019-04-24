using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : IFacility<IEggFeatherMeatProducing>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();



        private List<IEggFeatherMeatProducing> _chickens = new List<IEggFeatherMeatProducing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public int chickenCount()
        {
            return _chickens.Count;
        }


        public void AddResource(IEggFeatherMeatProducing chickens)
        {
            if (_chickens.Count < _capacity)
            {
                _chickens.Add(chickens);
            }

        }

        public void AddResource(List<IEggFeatherMeatProducing> chickens)  // TODO: Take out this method for boilerplate
        {
            if (_chickens.Count + chickens.Count <= _capacity)
            {
                _chickens.AddRange(chickens);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            if (this._chickens.Count > 1 || this._chickens.Count == 0) {
                output.Append($"Chicken House {shortId} has {this._chickens.Count} chickens\n");
                this._chickens.ForEach(a => output.Append($"   {a}\n"));
            } else {
                output.Append($"Chicken House {shortId} has {this._chickens.Count} chicken\n");
                this._chickens.ForEach(a => output.Append($"   {a}\n"));
            }

            return output.ToString();
        }
    }
}