using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string current = Console.ReadLine();

                Box<string> box = new Box<string>(current);

                Console.WriteLine(box);
            }
        }
    }
}
