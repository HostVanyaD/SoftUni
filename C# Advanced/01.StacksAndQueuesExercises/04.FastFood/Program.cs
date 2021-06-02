using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodForTheDay = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueWithOrders = new Queue<int>(orders);

            Console.WriteLine(queueWithOrders.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                int currentOrder = orders[i];

                if (currentOrder <= foodForTheDay)
                {
                    foodForTheDay -= queueWithOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queueWithOrders.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queueWithOrders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
