using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] territory = new char[size, size];

            int snakeRow = -1;
            int snakeCol = -1;
            int[] firstBurrow = new int[2];
            int[] secondBurrow = new int[2];
            int counter = 0;

            FillTheTerritory(territory, ref snakeRow, ref snakeCol, firstBurrow, secondBurrow, ref counter);

            int foodQuantity = 0;
            bool snakeIsOutside = false;

            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();

                territory[snakeRow, snakeCol] = '.';

                SnakeMovesInCurrentDirection(ref snakeRow, ref snakeCol, command);

                if (SnakeMovesOutsideTheTerrirtory(territory, snakeRow, snakeCol))
                {
                    snakeIsOutside = true;
                    break;
                }

                if (territory[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }

                if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';

                    if (snakeRow == firstBurrow[0])
                    {
                        snakeRow = secondBurrow[0];
                        snakeCol = secondBurrow[1];
                    }
                    else
                    {
                        snakeRow = firstBurrow[0];
                        snakeCol = firstBurrow[1];
                    }
                }
                territory[snakeRow, snakeCol] = 'S';
            }

            if (snakeIsOutside)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            PrintTerritoryMatrix(territory);
        }

        private static void PrintTerritoryMatrix(char[,] territory)
        {
            for (int i = 0; i < territory.GetLength(0); i++)
            {
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    Console.Write(territory[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void SnakeMovesInCurrentDirection(ref int snakeRow, ref int snakeCol, string command)
        {
            switch (command)
            {
                case "up":
                    snakeRow--;
                    break;

                case "down":
                    snakeRow++;
                    break;

                case "left":
                    snakeCol--;
                    break;

                case "right":
                    snakeCol++;
                    break;
                default:
                    break;
            }
        }

        private static bool SnakeMovesOutsideTheTerrirtory(char[,] territory, int snakeRow, int snakeCol)
        {
            return snakeRow < 0 || snakeRow >= territory.GetLength(0) || snakeCol < 0 || snakeCol >= territory.GetLength(1);
        }

        private static void FillTheTerritory(char[,] territory, ref int snakeRow, ref int snakeCol, int[] firstBurrow, int[] secondBurrow, ref int counter)
        {
            for (int i = 0; i < territory.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    territory[i, j] = rowElements[j];

                    if (territory[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }

                    if (territory[i, j] == 'B' && counter == 1)
                    {
                        secondBurrow[0] = i;
                        secondBurrow[1] = j;
                    }
                    else if (territory[i, j] == 'B' && counter == 0)
                    {
                        counter++;
                        firstBurrow[0] = i;
                        firstBurrow[1] = j;
                    }
                }
            }
        }
    }
}
