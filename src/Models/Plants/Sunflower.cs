using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, IGrowAndCompost
    {
        private int _seedsProduced = 650;
        private double _compostWeight = 21.6;
        public string Type { get; } = "Sunflower";

        public double Harvest () {
            return _seedsProduced;
        }
        public double Compost () {
            return _compostWeight;
        }

        public override string ToString () {
            return $"Sunflowers. Yay!";
        }
    }
}