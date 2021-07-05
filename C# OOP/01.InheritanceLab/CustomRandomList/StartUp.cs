using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var strings = new RandomList { "baloon", "kite", "bike"};

            Console.WriteLine(strings.RandomString());
        }
    }
}
