using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());

            Func<string, bool> filter = n => n.Length <= nameLenght;

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(filter)
                .ToList()
                .ForEach(n => Console.WriteLine(n));            
        }
    }
}
