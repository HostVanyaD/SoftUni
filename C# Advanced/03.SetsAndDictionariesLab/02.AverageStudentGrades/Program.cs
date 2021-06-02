using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> allGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (allGrades.ContainsKey(studentName))
                {
                    allGrades[studentName].Add(grade);
                }
                else
                {
                    allGrades.Add(studentName, new List<decimal>());
                    allGrades[studentName].Add(grade);
                }
            }

            foreach (var student in allGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in allGrades[student.Key])
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.WriteLine($"(avg: {allGrades[student.Key].Average():F2})");
            }
        }
    }
}
