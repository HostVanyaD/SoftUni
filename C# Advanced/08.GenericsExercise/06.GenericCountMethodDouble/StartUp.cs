using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());

            List<Box<double>> elements = new List<Box<double>>();

            for (int i = 0; i < numOfElements; i++)
            {
                Box<double> current = new Box<double>(double.Parse(Console.ReadLine()));
                elements.Add(current);
            }

            double valueToCompare = double.Parse(Console.ReadLine());

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
