using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        protected Feline(HashSet<string> foodsAllowed, double weightModifier, string name, double weight, string livingRegion, string breed) 
            : base(foodsAllowed, weightModifier, name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
