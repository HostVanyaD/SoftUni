using System;

namespace _02.GenericBoxOfInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int current = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(current);

                Console.WriteLine(box);
            }
        }
    }
}
