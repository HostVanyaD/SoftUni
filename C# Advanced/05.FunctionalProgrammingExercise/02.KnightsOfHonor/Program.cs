using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printOutput = n => Console.WriteLine($"Sir {n}");

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(n => printOutput(n));
        }
    }
}
