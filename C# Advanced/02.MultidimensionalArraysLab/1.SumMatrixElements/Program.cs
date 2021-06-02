using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromTheConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int sum = 0;

            for (int row = 0; row < sizes[0]; row++)
            {
                int[] colElements = ReadArrayFromTheConsole();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = colElements[col];
                    sum += colElements[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }

        private static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine().
                            Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
