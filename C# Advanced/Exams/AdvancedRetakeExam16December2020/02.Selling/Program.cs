using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];

            bool outOfBakery = false;
            int money = 0;
            int pillar1Row = -1;
            int pillar1Col = -1;
            int pillar2Row = -1;
            int pillar2Col = -1;
            int pillarCount = 0;
            int myRow = -1;
            int myCol = -1;

            ReadBakeryField(bakery, ref pillar1Row, ref pillar1Col, ref pillar2Row, ref pillar2Col, ref pillarCount, ref myRow, ref myCol);

            while (money < 50 && outOfBakery == false)
            {
                string command = Console.ReadLine();
                bakery[myRow, myCol] = '-'; //my old position

                if (command == "up")
                {
                    myRow -= 1;
                }
                else if (command == "down")
                {
                    myRow += 1;
                }
                else if (command == "left")
                {
                    myCol -= 1;
                }
                else if (command == "right")
                {
                    myCol += 1;
                }

                if (TheMoveIsWithinTheBakery(bakery, myRow, myCol))
                {
                    if (Char.IsDigit(bakery[myRow, myCol]))
                    {
                        money += int.Parse(bakery[myRow, myCol].ToString());
                    }
                    else if (pillarCount > 0 && bakery[myRow, myCol] == 'O')
                    {
                        bakery[myRow, myCol] = '-';

                        if (myRow == pillar1Row && myCol == pillar1Col)
                        {
                            myRow = pillar2Row;
                            myCol = pillar2Col;
                        }
                        else
                        {
                            myRow = pillar1Row;
                            myCol = pillar1Col;
                        }
                    }
                    bakery[myRow, myCol] = 'S';
                }
                else
                {
                    outOfBakery = true;
                }
            }

            if (outOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");
            PrintBakeryField(bakery);
        }

        private static void PrintBakeryField(char[,] bakery)
        {
            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    Console.Write(bakery[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool TheMoveIsWithinTheBakery(char[,] bakery, int myRow, int myCol)
        {
            return myRow >= 0 && myRow < bakery.GetLength(0) && myCol >= 0 && myCol < bakery.GetLength(1);
        }

        private static void ReadBakeryField(char[,] bakery, ref int pillar1Row, ref int pillar1Col, ref int pillar2Row, ref int pillar2Col, ref int pillarCount, ref int myRow, ref int myCol)
        {
            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                string rowElements = Console.ReadLine();

                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    bakery[i, j] = rowElements[j];

                    if (bakery[i, j] == 'S')
                    {
                        myRow = i;
                        myCol = j;
                    }
                    else if (bakery[i, j] == 'O')
                    {
                        pillarCount++;
                        if (pillarCount == 1)
                        {
                            pillar1Row = i;
                            pillar1Col = j;
                        }
                        else
                        {
                            pillar2Row = i;
                            pillar2Col = j;
                        }
                    }
                }
            }
        }
    }
}
