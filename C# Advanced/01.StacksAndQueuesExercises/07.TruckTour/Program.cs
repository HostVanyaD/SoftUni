using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> stations = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currentStation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                stations.Enqueue(currentStation);
            }

            int stationIndex = 0;

            while (true)
            {
                int petrolAmount = 0;
                bool foundPoint = true;

                for (int i = 0; i < n; i++)
                {
                    int[] currentStation = stations.Dequeue();

                    int currentPetrol = currentStation[0];
                    int distanceToNextStation = currentStation[1];

                    petrolAmount += currentPetrol;

                    if (petrolAmount < distanceToNextStation)
                    {
                        foundPoint = false;
                    }

                    petrolAmount -= distanceToNextStation;

                    stations.Enqueue(currentStation);
                }

                if (foundPoint)
                {
                    break;
                }

                stationIndex++;

                stations.Enqueue(stations.Dequeue());
            }

            Console.WriteLine(stationIndex);
        }
    }
}
