using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double DefaultWeightModifier = 0.10;
        private static HashSet<string> foodsAllowed = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion) 
            : base(foodsAllowed, DefaultWeightModifier, name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
