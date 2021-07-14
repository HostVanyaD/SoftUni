using System;
using _04.WildFarm.Models.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(HashSet<string> foodsAllowed, double weightModifier, string name, double weight)
        {
            FoodsAllowed = foodsAllowed;
            WeightModifier = weightModifier;
            Name = name;
            Weight = weight;
        }

        private HashSet<string> FoodsAllowed { get; set; }
        private double WeightModifier { get; set; }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string currentFoodType = food.GetType().Name;

            if (FoodsAllowed.Contains(currentFoodType) == false)
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {currentFoodType}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += this.WeightModifier * food.Quantity;
        }
    }
}
