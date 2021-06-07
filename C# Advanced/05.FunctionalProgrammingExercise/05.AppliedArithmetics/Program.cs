using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            Action<List<int>> add = (n) =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i] += 1;
                }
            };

            Action<List<int>> multiply = (n) =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i] *= 2;
                }
            };

            Action<List<int>> subtract = (n) =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i] -= 1;
                }
            };

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
