using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());

            List<Box<string>> elements = new List<Box<string>>();

            for (int i = 0; i < numOfElements; i++)
            {
                elements.Add(new Box<string>(Console.ReadLine()));
            }

            string valueToCompare = Console.ReadLine();

            Console.WriteLine(GetGreaterCount(elements, valueToCompare));
        }

        static int GetGreaterCount<T>(IEnumerable<Box<T>> elements, T valueToCompare)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (var element in elements)
            {
                if (element.CompareTo(valueToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
