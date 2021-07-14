using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double DefaultWeightModifier = 0.25;
        private static HashSet<string> foodsAllowed = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize) 
            : base(foodsAllowed, DefaultWeightModifier, name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
