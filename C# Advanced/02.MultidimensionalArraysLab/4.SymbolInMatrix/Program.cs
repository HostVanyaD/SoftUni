using System;
using System.Linq;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool foundSymbol = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (foundSymbol)
                {
                    break;
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbol == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        foundSymbol = true;
                        break;
                    }
                }
            }

            if (!foundSymbol)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
