using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int ToppingMinGrams = 1;
        private const int ToppingMaxGrams = 50;

        private string name;
        private int weight;
        private double modifier = 2;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
            switch (name.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfValueISNotInSet(new HashSet<string> { "meat", "veggies", "cheese", "sauce" },
                    value.ToLower(),
                    $"Cannot place {value} on top of your pizza.");

                name = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowExceptionIfNumberIsOutOfRange(ToppingMinGrams, ToppingMaxGrams, value,
                    $"{name} weight should be in the range [{ToppingMinGrams}..{ToppingMaxGrams}].");

                weight = value;
            }
        }

        public double CalculateCalories()
        {
            return weight * modifier;
        }
    }
}
