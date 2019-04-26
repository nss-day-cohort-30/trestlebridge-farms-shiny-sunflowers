using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;


namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public void AddResource(IGrazing animal)
        {
            if (_animals.Count < _capacity)
            {
                _animals.Add(animal);
            }
        }

        public int animalCount()
        {
            return _animals.Count;
        }

        public void AddResource(List<IGrazing> animals)  // TODO: Take out this method for boilerplate
        {
            if (_animals.Count + animals.Count <= _capacity)
            {
                _animals.AddRange(animals);
            }
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            if (this._animals.Count > 1 || this._animals.Count == 0)
            {
                output.Append($@"
Grazing field {shortId} has {this._animals.Count} animals:  "  );
                var animalTypes = _animals.GroupBy(thisType => thisType.Type);
                foreach (var type in animalTypes)
                {
                    output.Append($@"{type.Count()} {type.Key}s, ");
                }
            }
            else if (this._animals.Count == 1)
            {
                output.Append($@"
Grazing field {shortId} has {this._animals.Count} animals:  ");
                var animalTypes = _animals.GroupBy(thisType => thisType.Type);

                foreach (var type in animalTypes)
                {
                    output.Append($@"{type.Count()} {type.Key} ");
                }
            }
            return output.ToString();
        }
    }
}