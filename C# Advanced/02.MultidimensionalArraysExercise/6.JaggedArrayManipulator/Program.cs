using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray();
            }

            DoCalculations(n, jagged);

            string input = string.Empty;

            while ((input = Console.ReadLine().ToUpper()) != "END")
            {
                string[] commmands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commmands[1]);
                int col = int.Parse(commmands[2]);
                int value = int.Parse(commmands[3]);

                if (row >= 0 && col >= 0 && row < n && col < jagged[row].Length)
                {
                    switch (commmands[0])
                    {
                        case "ADD":
                            jagged[row][col] += value;
                            break;
                        case "SUBTRACT":
                            jagged[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    continue;
                }
            }

            PrintJagged(jagged);
        }

        private static void DoCalculations(int n, double[][] jagged)
        {
            for (int row = 0; row < n - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    MultiplyAllElementsByTwo(jagged, row);
                    MultiplyAllElementsByTwo(jagged, row + 1);
                }
                else
                {
                    DevideAllElementsByTwo(jagged, row);
                    DevideAllElementsByTwo(jagged, row + 1);
                }
            }
        }

        private static void PrintJagged(double[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        private static void DevideAllElementsByTwo(double[][] jagged, int row)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                jagged[row][i] /= 2;
            }
        }

        private static void MultiplyAllElementsByTwo(double[][] jagged, int row)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                jagged[row][i] *= 2;
            }
        }
    }
}
