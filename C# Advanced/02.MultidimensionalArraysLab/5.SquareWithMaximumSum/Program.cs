using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromTheConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < sizes[0]; row++)
            {
                int[] colElements = ReadArrayFromTheConsole();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int maxSum = int.MinValue;
            int topRow = 0;
            int topCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        topCol = col;
                        topRow = row;
                    }
                }
            }

            Console.WriteLine($"{matrix[topRow, topCol]} {matrix[topRow, topCol + 1]}");
            Console.WriteLine($"{matrix[topRow + 1, topCol]} {matrix[topRow + 1, topCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
