using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DefaultWeightModifier = 0.40;
        private static HashSet<string> foodsAllowed = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(foodsAllowed, DefaultWeightModifier, name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
