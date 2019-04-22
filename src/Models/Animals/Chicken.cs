using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Chicken : IResource, IEggFeatherMeatProducing {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 1.7;
        private double _feathersProduced = .5;
        private double _eggsProduced = 7;

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public string Type { get; } = "Chicken";

        // Methods

        public double Butcher () {
            return _meatProduced;
        }

        public double EggGatherer () {
            return _eggsProduced;
        }

        public double FeatherHarvester () {
            return _feathersProduced;
        }

        public override string ToString () {
            return $"Chicken {this._shortId}. BaCaw!";
        }
    }
}