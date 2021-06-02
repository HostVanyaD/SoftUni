using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Ranking
{
    class Student
    {
        public string Name { get; set; }
        public Dictionary<string, int> Contest { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            List<Student> students = new List<Student>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] parts = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];

                contestPasswords.Add(contest, password);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] parts = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];
                string username = parts[2];
                int points = int.Parse(parts[3]);

                if (!contestPasswords.ContainsKey(contest) || contestPasswords[contest] != password)
                {
                    continue;
                }

                if (!students.Any(n => n.Name == username))
                {
                    Student currentStudent = new Student()
                    {
                        Name = username,
                        Contest = new Dictionary<string, int>()
                    };
                    students.Add(currentStudent);
                    currentStudent.Contest.Add(contest, points);
                }
                else
                {
                    var findTheStudent = students.First(x => x.Name == username);

                    if (!findTheStudent.Contest.Any(x => x.Key == contest))
                    {
                        findTheStudent.Contest.Add(contest, points);
                    }

                    else
                    {
                        if (findTheStudent.Contest[contest] < points)
                        {
                            findTheStudent.Contest[contest] = points;
                        }
                    }
                }
            }

            List<Student> sortedByName = students
                .OrderBy(n => n.Name)
                .ToList();

            PrintBestCandidate(sortedByName);

            Console.WriteLine("Ranking: ");
            foreach (var student in sortedByName)
            {
                Console.WriteLine($"{student.Name}");
                foreach (var contest in student.Contest.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void PrintBestCandidate(List<Student> sortedByName)
        {
            string bestName = string.Empty;
            int bestPoints = 0;


            foreach (var student in sortedByName)
            {
                if (student.Contest.Values.Sum() > bestPoints)
                {
                    bestPoints = student.Contest.Values.Sum();
                    bestName = student.Name;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
        }
    }
}
