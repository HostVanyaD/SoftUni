using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {      
        protected Mammal(HashSet<string> foodsAllowed, double weightModifier, string name, double weight, string livingRegion) 
            : base(foodsAllowed, weightModifier, name, weight)
        {
            LivingRegion = livingRegion;
        }
        
        public string LivingRegion { get; protected set; }
    }
}
