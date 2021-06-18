using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] garden = new int[sizes[0], sizes[1]];
            List<int[]> flowerCoordinates = new List<int[]>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (CoordinatesAreValid(garden, row, col))
                {
                    garden[row, col] = 1;
                    flowerCoordinates.Add(new int[] { row, col });
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowerCoordinates)
            {
                int row = flower[0];
                int col = flower[1];

                BloomFlowers(garden, row, col);
            }

            PrintGarden(garden);
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int[,] garden, int row, int col)
        {
            for (int i = row - 1; i >= 0; i--) //up
            {
                garden[i, col]++;
            }

            for (int i = row + 1; i < garden.GetLength(0); i++) //down
            {
                garden[i, col]++;
            }

            for (int i = col - 1; i >= 0; i--) //left
            {
                garden[row, i]++;
            }

            for (int i = col + 1; i < garden.GetLength(1); i++) //right
            {
                garden[row, i]++;
            }
        }

        private static bool CoordinatesAreValid(int[,] garden, int row, int col)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1);
        }
    }
}
