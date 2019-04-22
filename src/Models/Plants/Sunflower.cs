using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing
    {
        private int _seedsProduced = 40;
        public string Type { get; } = "sunflower";

        public double Harvest () {
            return _seedsProduced;
        }

        public override string ToString () {
            return $"How many Sunflowers would you like to plant?!";
        }
    }
}