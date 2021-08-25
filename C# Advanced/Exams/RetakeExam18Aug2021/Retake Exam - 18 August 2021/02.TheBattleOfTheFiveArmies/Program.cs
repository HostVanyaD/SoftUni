namespace _02.TheBattleOfTheFiveArmies
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int sizeOfMap = int.Parse(Console.ReadLine());

            char[][] map = new char[sizeOfMap][];

            bool throneIsReached = false;
            int armyRow = -1;
            int armyCol = -1;

            ReadTheMap(map, ref armyRow, ref armyCol);

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                map[armyRow][armyCol] = '-';
                map[spawnRow][spawnCol] = 'O';
                armyArmor--;

                ArmyMakesAMoveToTheGivenDirection(map, ref armyRow, ref armyCol, direction);

                if (map[armyRow][armyCol] == 'O')
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        map[armyRow][armyCol] = 'X';
                        break;
                    }
                }
                else if(map[armyRow][armyCol] == 'M')
                {
                    throneIsReached = true;
                    map[armyRow][armyCol] = '-';
                    break;
                }

                if (armyArmor <= 0)
                {
                    map[armyRow][armyCol] = 'X';
                    break;
                }

                map[armyRow][armyCol] = 'A';
            }

            if (throneIsReached)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void ArmyMakesAMoveToTheGivenDirection(char[][] map, ref int armyRow, ref int armyCol, string direction)
        {
            switch (direction) //“up”, “down”, “left”, “right”
            {
                case "up":
                    if (armyRow - 1 >= 0)
                    {
                        armyRow--;
                    }
                    break;
                case "down":
                    if (armyRow + 1 < map.GetLength(0))
                    {
                        armyRow++;
                    }
                    break;
                case "left":
                    if (armyCol - 1 >= 0)
                    {
                        armyCol--;
                    }
                    break;
                case "right":
                    if (armyCol + 1 < map[armyRow].Length)
                    {
                        armyCol++;
                    }
                    break;
            }
        }

        private static void ReadTheMap(char[][] map, ref int armyRow, ref int armyCol)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();
                map[i] = new char[rowElements.Length];

                for (int j = 0; j < rowElements.Length; j++)
                {
                    map[i][j] = rowElements[j];

                    if (map[i][j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }
        }
    }
}
