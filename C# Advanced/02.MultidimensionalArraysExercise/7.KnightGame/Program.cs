using System;
using System.Linq;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] colInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = colInput[col];
                }
            }

            int killerRow = 0;
            int killerCol = 0;
            int knightsRemoved = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int i = 0; i < chessBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < chessBoard.GetLength(1); j++)
                    {
                        //Check if there's a knight on current possition
                        if (chessBoard[i, j] == 'K')
                        {
                            int currentAttacks = CountValidAttacks(chessBoard, i, j);

                            //Save data for the knight with maxAttacks
                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                killerRow = i;
                                killerCol = j;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    //Remove the Killer from the board
                    chessBoard[killerRow, killerCol] = '0';
                    knightsRemoved++;
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    break;
                }
            }
        }

        private static int CountValidAttacks(char[,] chessBoard, int row, int col)
        {
            //All possible moves of a knight kept in two arrays
            int[] possibleRows = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] possibleCols = { 1, 2, 2, 1, -1, -2, -2, -1 };

            int hitCount = 0;

            for (int i = 0; i < possibleRows.Length; i++)
            {
                // Calculate position of knight after move
                int rowCoordinates = row + possibleRows[i];
                int colCoordinates = col + possibleCols[i];

                //Check if there is a valid hit
                if (rowCoordinates >= 0 && colCoordinates >= 0 &&
                    rowCoordinates < chessBoard.GetLength(0) && colCoordinates < chessBoard.GetLength(1) &&
                    chessBoard[rowCoordinates, colCoordinates] == 'K')
                {
                    hitCount++;
                }
            }

            return hitCount;
        }
    }
}
