using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printOutput = (s) => Console.WriteLine(s);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(s => printOutput(s));

            
        }
    }
}
