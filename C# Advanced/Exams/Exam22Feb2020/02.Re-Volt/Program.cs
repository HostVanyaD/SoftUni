using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizefTheMatrix = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] field = new char[sizefTheMatrix, sizefTheMatrix];

            int playerRow = -1;
            int playerCol = -1;

            FillTheField(field, ref playerRow, ref playerCol);

            bool gameWon = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                field[playerRow, playerCol] = '-';
                int[] lastPosition = new int[] { playerRow, playerCol };

                PlayerMoves(field, ref playerRow, ref playerCol, command);

                if (field[playerRow, playerCol] == 'B')
                {
                    PlayerMoves(field, ref playerRow, ref playerCol, command);
                }

                if (field[playerRow, playerCol] == 'T')
                {
                    playerRow = lastPosition[0];
                    playerCol = lastPosition[1];
                }

                if (field[playerRow, playerCol] == 'F')
                {
                    gameWon = true;
                    field[playerRow, playerCol] = 'f';
                    break;
                }

                field[playerRow, playerCol] = 'f';
            }

            if (gameWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintField(field);
        }

        private static void PrintField(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool PlayerMovesOutsideTheField(char[,] field, int playerRow, int playerCol)
        {
            return playerRow < 0 || playerRow >= field.GetLength(0) || playerCol < 0 || playerCol >= field.GetLength(1);
        }

        private static void PlayerMoves(char[,] field, ref int playerRow, ref int playerCol, string command)
        {
            switch (command)
            {
                case "up":
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = field.GetLength(0) - 1;
                    }
                    break;

                case "down":
                    playerRow++;
                    if (playerRow >= field.GetLength(0))
                    {
                        playerRow = 0;
                    }
                    break;

                case "left":
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = field.GetLength(1) - 1;
                    }
                    break;

                case "right":
                    playerCol++;
                    if (playerCol >= field.GetLength(1))
                    {
                        playerCol = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void FillTheField(char[,] field, ref int playerRow, ref int playerCol)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = rowElements[j];

                    if (field[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
        }
    }
}
