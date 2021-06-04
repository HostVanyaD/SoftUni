using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = word => Char.IsUpper(word[0]);
            
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isUpper(w))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
