using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int NameMinLenght = 1;
        private const int NameMaxLenght = 15;
        private const int ToppingsMaxCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough doughType)
        {
            Name = name;
            dough = doughType;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowExceptionIfNumberIsOutOfRange(NameMinLenght, NameMaxLenght, value.Length, 
                    $"Pizza name should be between {NameMinLenght} and {NameMaxLenght} symbols.");
               
                name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == ToppingsMaxCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{ToppingsMaxCount}].");
            }
            toppings.Add(topping);
        }

        public double CalculatePizzaCalories()
        {
            return dough.CalculateCalories() + toppings.Sum(t => t.CalculateCalories());
        }
    }
}
