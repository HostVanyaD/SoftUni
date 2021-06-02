using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parenthesisStack = new Stack<char>();

            CheckForBalance(input, parenthesisStack);

            Console.WriteLine(parenthesisStack.Count > 0 ? "NO" : "YES");
        }

        private static void CheckForBalance(string input, Stack<char> stack)
        {
            foreach (var symbol in input)
            {
                if (stack.Any())
                {
                    char check = stack.Peek();
                    if (check == '{' && symbol == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(symbol);
            }
        }
    }
}
