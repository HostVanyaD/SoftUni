using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = new long[row + 1];
                jagged[row][0] = 1;
                jagged[row][row] = 1;

                for (int col = 1; col < row; col++)
                {       
                    if (jagged[row].Length > 2)
                    {
                        jagged[row][col] = jagged[row - 1][col] + jagged[row - 1][col - 1];
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
