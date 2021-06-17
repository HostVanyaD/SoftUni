using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> orcs = new Stack<int>();

            bool gondorIsDown = false;

            for (int i = 1; i <= orcWaves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    if (orcs.Peek() > plates.First())
                    {
                        int decreasedOrcPower = orcs.Pop() - plates.First();
                        orcs.Push(decreasedOrcPower);
                        plates.RemoveAt(0);
                    }
                    else if (orcs.Peek() < plates.First())
                    {
                        plates[0] -= orcs.Pop();
                    }
                    else
                    {
                        orcs.Pop();
                        plates.RemoveAt(0);
                    }

                    if (plates.Count == 0)
                    {
                        gondorIsDown = true;
                        break;
                    }
                }

                if (gondorIsDown)
                {
                    break;
                }
            }

            if (gondorIsDown)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}