using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] lair = new char[sizes[0], sizes[1]];
            int playerRow = 0;
            int playerCol = 0;
            FillMatrix(lair, ref playerRow, ref playerCol);

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                char currentMove = directions[i];
                int oldPRow = playerRow;
                int oldPCol = playerCol;

                switch (currentMove)
                {
                    case 'L':
                        playerCol -= 1;
                        break;
                    case 'R':
                        playerCol += 1;
                        break;
                    case 'U':
                        playerRow -= 1;
                        break;
                    case 'D':
                        playerRow += 1;
                        break;
                }
                lair = SpreadBunnies(lair);

                if (playerCol < 0 || playerCol >= lair.GetLength(1) ||
                    playerRow < 0 || playerRow >= lair.GetLength(0))
                {
                    PrintResult(lair, oldPRow, oldPCol, "won");
                    break;
                }

                if (lair[playerRow, playerCol] == 'B')
                {
                    PrintResult(lair, playerRow, playerCol, "dead");
                    break;
                }
            }
        }

        private static void PrintResult(char[,] lair, int oldPRow, int oldPCol, string result)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write($"{lair[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"{result}: {oldPRow} {oldPCol}");
        }

        private static char[,] SpreadBunnies(char[,] lair)
        {
            char[,] matrix = new char[lair.GetLength(0), lair.GetLength(1)];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    matrix[row, col] = lair[row, col];
                }
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (row - 1 >= 0) //up
                        {
                            matrix[row - 1, col] = 'B';
                        }
                        if (row + 1 < lair.GetLength(0)) //down
                        {
                            matrix[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0) //left
                        {
                            matrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < lair.GetLength(1))
                        {
                            matrix[row, col + 1] = 'B';
                        }
                    }
                }
            }
            return matrix;
        }

        private static void FillMatrix(char[,] lair, ref int playerRow, ref int playerCol)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = input[j];
                    if (lair[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                        lair[playerRow, playerCol] = '.';
                    }
                }
            }
        }
    }
}
