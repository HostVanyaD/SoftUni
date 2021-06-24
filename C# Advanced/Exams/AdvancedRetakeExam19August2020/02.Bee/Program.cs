using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];

            int beeRow = -1;
            int beeCol = -1;
            int pollinatedFlowers = 0;
            bool beeGotLost = false;

            ReadTerritoryMatrix(territory, ref beeRow, ref beeCol);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                territory[beeRow, beeCol] = '.';

                BeeMovesInCurrentDirection(ref beeRow, ref beeCol, command);

                if (PositionIsOutside(territory, beeRow, beeCol))
                {
                    beeGotLost = true;
                    break;
                }
                
                if (territory[beeRow, beeCol] == 'O')
                {
                    territory[beeRow, beeCol] = '.';
                    BeeMovesInCurrentDirection(ref beeRow, ref beeCol, command);

                    if (PositionIsOutside(territory, beeRow, beeCol))
                    {
                        beeGotLost = true;
                        break;
                    }
                }
                
                if (territory[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }

                territory[beeRow, beeCol] = 'B';
            }

            if (beeGotLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

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

        private static void BeeMovesInCurrentDirection(ref int beeRow, ref int beeCol, string command)
        {
            switch (command)
            {
                case "up":
                    beeRow--;
                    break;

                case "down":
                    beeRow++;
                    break;

                case "left":
                    beeCol--;
                    break;

                case "right":
                    beeCol++;
                    break;

                default:
                    break;
            }
        }

        private static bool PositionIsOutside(char[,] territory, int beeRow, int beeCol)
        {
            return beeRow < 0 || beeRow >= territory.GetLength(0) || beeCol < 0 || beeCol >= territory.GetLength(1);
        }

        private static void ReadTerritoryMatrix(char[,] territory, ref int beeRow, ref int beeCol)
        {
            for (int i = 0; i < territory.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    territory[i, j] = rowElements[j];

                    if (territory[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }
        }
    }
}
