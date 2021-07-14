using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Birds
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; protected set; }

        protected Bird(HashSet<string> foodsAllowed, double weightModifier, string name, double weight, double wingSize) 
            : base(foodsAllowed, weightModifier, name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
