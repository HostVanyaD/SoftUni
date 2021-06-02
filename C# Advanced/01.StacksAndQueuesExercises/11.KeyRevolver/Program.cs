using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfTheBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int payValue = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int shoots = 0;
            int totalBullets = 0;

            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {
                int currentLock = locksQueue.Peek();
                int currentBullet = bulletsStack.Pop();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                totalBullets++;
                shoots++;

                if (shoots == sizeOfTheBarrel && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shoots = 0;
                }

                if (bulletsStack.Count == 0 && locksQueue.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    break;
                }
            }

            if (locksQueue.Count == 0)
            {
                payValue -= totalBullets * bulletPrice;
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${payValue}");
            }
        }
    }
}
