using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var spy = new Spy();
            var result = spy.CollectGettersAndSetters("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
