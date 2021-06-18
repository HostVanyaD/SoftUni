using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsData = ReadAnArrayFromTheConsole();
            int[] ingredientsData = ReadAnArrayFromTheConsole();

            Queue<int> liquids = new Queue<int>(liquidsData);
            Stack<int> ingredients = new Stack<int>(ingredientsData);

            Dictionary<string, int> foodValues = new Dictionary<string, int>
            {
                {"Bread", 25 },
                {"Cake", 50 },
                {"Pastry", 75 },
                {"Fruit Pie", 100 }
            };

            SortedDictionary<string, int> foodsMade = new SortedDictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIgredient = ingredients.Pop();
                int sum = currentLiquid + currentIgredient;

                if (foodValues.Any(x => x.Value == sum))
                {
                    var findFood = foodValues.First(x => x.Value == sum);

                    foodsMade[findFood.Key] += 1;
                }
                else
                {
                    currentIgredient += 3;
                    ingredients.Push(currentIgredient);
                }
            }

            PrintResult(liquids, ingredients, foodsMade);
        }

        private static void PrintResult(Queue<int> liquids, Stack<int> ingredients, SortedDictionary<string, int> foodsMade)
        {
            if (foodsMade.Where(x => x.Value > 0).ToList().Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foodsMade)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }

        private static int[] ReadAnArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
