using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadArrayFromTheConsole();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine().ToUpper()) != "END")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row < 0 || row >= n || col < 0 || col > jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (commands[0])
                {
                    case "ADD":
                        jagged[row][col] += value;
                        break;
                    case "SUBTRACT":
                        jagged[row][col] -= value;
                        break;
                    default:
                        break;
                }
            }

            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
