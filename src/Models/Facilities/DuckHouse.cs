using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<IEggFeatherProducing>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<IEggFeatherProducing> _ducks = new List<IEggFeatherProducing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public int duckCount ()
        {
            return _ducks.Count;
        }

        public void AddResource (IEggFeatherProducing ducks)
        {
            if (_ducks.Count < _capacity) {
                _ducks.Add(ducks);
            }
        }

        public void AddResource (List<IEggFeatherProducing> ducks)  // TODO: Take out this method for boilerplate
        {
            if (_ducks.Count + ducks.Count <= _capacity) {
                _ducks.AddRange(ducks);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

        if (this._ducks.Count > 1) {
            output.Append($"Duck House {shortId} has {this._ducks.Count} ducks\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));
        } else {
            output.Append($"Duck House {shortId} has {this._ducks.Count} duck\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));
        }

            return output.ToString();
        }
    }
}