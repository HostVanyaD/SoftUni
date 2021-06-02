using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (commands[0] == 1)
                {
                    stack.Push(commands[1]);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        switch (commands[0])
                        {
                            case 2:
                                stack.Pop();
                                break;
                            case 3:
                                Console.WriteLine(stack.Max());
                                break;
                            case 4:
                                Console.WriteLine(stack.Min());
                                break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
