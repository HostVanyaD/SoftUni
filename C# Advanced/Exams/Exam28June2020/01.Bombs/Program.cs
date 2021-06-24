using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsData = ReadAnArrayWithData();
            int[] casingsData = ReadAnArrayWithData();

            Stack<int> casings = new Stack<int>(casingsData);
            Queue<int> effects = new Queue<int>(effectsData);

            Dictionary<string, int> bombValues = new Dictionary<string, int>
            {
                {"Datura Bombs", 40 },
                {"Cherry Bombs", 60 },
                {"Smoke Decoy Bombs", 120 }
            };

            SortedDictionary<string, int> bombsMade = new SortedDictionary<string, int>
            {
                { "Datura Bombs" , 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0}
            
            };  

            int sum = 0;
            bool bombPouchedFulFilled = false;

            while (casings.Count > 0 && effects.Count > 0)
            {
                sum = casings.Peek() + effects.Peek();

                if (bombValues.Any(b => b.Value == sum))
                {
                    var bomb = bombValues.First(b => b.Value == sum);
                    bombsMade[bomb.Key]++;
                    casings.Pop();
                    effects.Dequeue();
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                }

                if (bombsMade.Where(b => b.Value >= 3).ToList().Count == 3)
                {
                    bombPouchedFulFilled = true;
                    break;
                }
            }

            if (bombPouchedFulFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombsMade)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }


        }

        private static int[] ReadAnArrayWithData()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
