using System;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] field = new int[n, n];
            FillMatrix(field);

            string[] bombCells = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCells.Length; i++)
            {
                string[] bombCoordinates = bombCells[i].Split(",", StringSplitOptions.RemoveEmptyEntries);

                int bombRow = int.Parse(bombCoordinates[0]);
                int bombCol = int.Parse(bombCoordinates[1]);

                if (!CoordinatesAreValid(field, bombRow, bombCol))
                {
                    continue;
                }

                int bombDamage = field[bombRow, bombCol];

                if (bombDamage > 0)
                {
                    field = ExplodeBomb(field, bombRow, bombCol, bombDamage);
                }
            }

            int cellsAlive = 0;
            int cellsSum = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] > 0)
                    {
                        cellsAlive++;
                        cellsSum += field[i, j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {cellsAlive}");
            Console.WriteLine($"Sum: {cellsSum}");

            PrintMatrix(field);
        }

        private static void PrintMatrix(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] ExplodeBomb(int[,] field, int row, int col, int damage)
        {
            field[row, col] -= damage;

            if (col - 1 >= 0 && field[row, col - 1] > 0)
            {
                field[row, col - 1] -= damage;
            }
            if (col + 1 < field.GetLength(1) && field[row, col + 1] > 0)
            {
                field[row, col + 1] -= damage;
            }
            if (row - 1 >= 0 && field[row - 1, col] > 0)
            {
                field[row - 1, col] -= damage;
            }
            if (row + 1 < field.GetLength(0) && field[row + 1, col] > 0)
            {
                field[row + 1, col] -= damage;
            }
            if (row - 1 >= 0 && col - 1 >= 0 && field[row - 1, col - 1] > 0)
            {
                field[row - 1, col - 1] -= damage;
            }
            if (row - 1 >= 0 && col + 1 < field.GetLength(1) && field[row - 1, col + 1] > 0)
            {
                field[row - 1, col + 1] -= damage;
            }
            if (row + 1 < field.GetLength(0) && col - 1 >= 0 && field[row + 1, col - 1] > 0)
            {
                field[row + 1, col - 1] -= damage;
            }
            if (row + 1 < field.GetLength(0) && col + 1 < field.GetLength(1) && field[row + 1, col + 1] > 0)
            {
                field[row + 1, col + 1] -= damage;
            }

            return field;
        }

        private static bool CoordinatesAreValid(int[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        private static void FillMatrix(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                int[] colElements = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = colElements[j];
                }
            }
        }
    }
}
