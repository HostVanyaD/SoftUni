using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilliesData = ReadAnArrayFromTheConsole();
            int[] rosesData = ReadAnArrayFromTheConsole();

            Stack<int> lillies = new Stack<int>(lilliesData);
            Queue<int> roses = new Queue<int>(rosesData);

            int storedFlowers = 0;
            int wreathsMade = 0;
            int sum = 0;

            while (lillies.Count > 0 && roses.Count > 0)
            {
                sum = lillies.Peek() + roses.Peek();

                if (sum == 15)
                {
                    wreathsMade++;
                    lillies.Pop();
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lillies.Push(lillies.Pop() - 2);
                }
                else
                {
                    storedFlowers += lillies.Pop() + roses.Dequeue();
                }
            }

            if (storedFlowers > 15)
            {
                wreathsMade += storedFlowers / 15;
            }

            if (wreathsMade >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsMade} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsMade} wreaths more!");
            }
        }

        private static int[] ReadAnArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
