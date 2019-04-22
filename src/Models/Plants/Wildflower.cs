using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, ICompostProducing
    {
        private double _compostWeight = 30.3;
        public string Type { get; } = "Wildflower";

        public double Compost () {
            return _compostWeight;
        }

        public override string ToString () {
            return $"Wildflowers. Pretty!";
        }
    }
}