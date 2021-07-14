using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double DefaultWeightModifier = 0.30;
        private static HashSet<string> foodsAllowed = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(foodsAllowed, DefaultWeightModifier, name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
