using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            FillMatrix(field);

            int coalsCount = 0;
            int[] startingPosition = new int[2];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 's')
                    {
                        startingPosition = new int[] { i, j };
                    }
                    if (field[i, j] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
            int rowIndex = startingPosition[0];
            int colIndex = startingPosition[1];

            bool allCoalsCollected = false;
            bool gameOver = false;

            while (commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();

                switch (currentCommand)
                {
                    case "left":
                        if (colIndex - 1 < 0) continue;
                        colIndex -= 1;
                        break;
                    case "right":
                        if (colIndex + 1 >= field.GetLength(1)) continue;
                        colIndex += 1;
                        break;
                    case "up":
                        if (rowIndex - 1 < 0) continue;
                        rowIndex -= 1;
                        break;
                    case "down":
                        if (rowIndex + 1 >= field.GetLength(0)) continue;
                        rowIndex += 1;
                        break;
                    default:
                        break;
                }

                if (field[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    gameOver = true;
                    break;
                }
                else if (field[rowIndex, colIndex] == 'c')
                {
                    coalsCount--;
                    field[rowIndex, colIndex] = '*';
                }

                if (coalsCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    allCoalsCollected = true;
                    break;
                }
            }

            if (!gameOver && !allCoalsCollected)
            {
                Console.WriteLine($"{coalsCount} coals left. ({rowIndex}, {colIndex})");
            }
        }

        private static void FillMatrix(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] colElements = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(char.Parse)
                                .ToArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = colElements[j];
                }
            }
        }
    }
}
