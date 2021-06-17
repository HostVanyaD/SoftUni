using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheField = int.Parse(Console.ReadLine());
            char[,] field = new char[sizeOfTheField, sizeOfTheField];

            string[] attacksData = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int totalCountOfDestroyedShips = 0;
            bool gameIsWon = false;
            string winner = string.Empty;

            ReadTheField(field, ref firstPlayerShips, ref secondPlayerShips);

            for (int i = 0; i < attacksData.Length; i++)
            {
                int[] currentAttack = attacksData[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = currentAttack[0];
                int currentCol = currentAttack[1];

                if (currentRow < 0 || currentRow >= sizeOfTheField || 
                    currentCol < 0 || currentCol >= sizeOfTheField)
                {
                    continue;
                }

                if (field[currentRow, currentCol] == '<')
                {
                    firstPlayerShips--;
                    field[currentRow, currentCol] = 'X';
                    totalCountOfDestroyedShips++;
                }
                else if (field[currentRow, currentCol] == '>')
                {
                    secondPlayerShips--;
                    field[currentRow, currentCol] = 'X';
                    totalCountOfDestroyedShips++;
                }
                else if (field[currentRow, currentCol] == '#')
                {
                    for (int j = currentRow - 1; j <= currentRow + 1; j++)
                    {
                        for (int k = currentCol - 1; k <= currentCol + 1; k++)
                        {
                            if (CoordinatesAreValid(field, j, k))
                            {
                                if (FirstPlayerShipIsHit(field, j, k))
                                {
                                    firstPlayerShips--;
                                    totalCountOfDestroyedShips++;
                                    field[j, k] = 'X';
                                }
                                else if (SecondPlayerShipIsHit(field, j, k))
                                {
                                    secondPlayerShips--;
                                    totalCountOfDestroyedShips++;
                                    field[j, k] = 'X';
                                }
                            }
                        }
                    }
                }

                if (firstPlayerShips == 0)
                {
                    gameIsWon = true;
                    winner = "Two";
                    break;
                }
                else if (secondPlayerShips == 0)
                {
                    gameIsWon = true;
                    winner = "One";
                    break;
                }
            }

            if (gameIsWon)
            {
                Console.WriteLine($"Player {winner} has won the game! {totalCountOfDestroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }

        private static bool SecondPlayerShipIsHit(char[,] field, int j, int k)
        {
            return field[j, k] == '>';
        }

        private static bool FirstPlayerShipIsHit(char[,] field, int j, int k)
        {
            return field[j,k] == '<';
        }

        private static bool CoordinatesAreValid(char[,] field, int j, int k)
        {
            return j >= 0 && j < field.GetLength(0) && k >= 0 && k < field.GetLength(1);
        }

        private static void ReadTheField(char[,] field, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = currentRow[j];

                    if (field[i, j] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[i, j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }
        }
    }
}
