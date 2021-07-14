using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double DefaultWeightModifier = 1.00;
        private static HashSet<string> foodsAllowed = new HashSet<string>()
        {
            nameof(Meat)
        }; 

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(foodsAllowed, DefaultWeightModifier, name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
