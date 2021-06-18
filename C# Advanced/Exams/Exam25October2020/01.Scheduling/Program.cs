using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> tasks = new Stack<int>(tasksData);
            Queue<int> threads = new Queue<int>(threadsData);

            int taskToBeKilled = int.Parse(Console.ReadLine());
            bool taskIsKilled = false;

            while (taskIsKilled == false)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
                    taskIsKilled = true;
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
