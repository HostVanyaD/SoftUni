using System;
using System.Linq;

namespace _2.SumMatrixColumns
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

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfCols = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfCols += matrix[row, col];
                }

                Console.WriteLine(sumOfCols);
            }
        }

        private static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
