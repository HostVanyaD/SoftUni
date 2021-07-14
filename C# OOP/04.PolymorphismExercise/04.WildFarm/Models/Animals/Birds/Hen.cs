using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double DefaultWeightModifier = 0.35;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) 
            : base(allowedFoods, DefaultWeightModifier, name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
