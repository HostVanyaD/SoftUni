using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split(" ")[1];
            string[] doughData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string doughType = doughData[1];
            string doughBakingTechnique = doughData[2];
            double doughWeight = double.Parse(doughData[3]);

            Dough currentDough;
            Pizza pizza;

            try
            {
                currentDough = new Dough(doughType, doughBakingTechnique, doughWeight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                pizza = new Pizza(pizzaName, currentDough);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string toppingName = tokens[1];
                int toppingWeight = int.Parse(tokens[2]);

                try
                {
                    var currentTopping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(currentTopping);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.CalculatePizzaCalories():F2} Calories.");
        }
    }
}
