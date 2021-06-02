using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> changes = new Stack<string>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "1")
                {
                    for (int j = 1; j < commands.Length; j++)
                    {
                        text.Append(commands[j]);
                    }
                    changes.Push(text.ToString());
                }
                else if (commands[0] == "2")
                {
                    int count = int.Parse(commands[1]);
                    text = text.Remove(text.Length - count, count);
                    changes.Push(text.ToString());
                }
                else if (commands[0] == "3")
                {
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (commands[0] == "4")
                {
                    changes.Pop();
                    text.Clear();
                    text.Append(changes.Peek());
                }
            }
        }
    }
}
