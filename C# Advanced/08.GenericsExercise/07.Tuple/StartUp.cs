using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];

            Tuple<string, string> persnInfo = new Tuple<string, string>(fullName, address);

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string personName = secondInput[0];
            int beerAmount = int.Parse(secondInput[1]);

            Tuple<string, int> beerInfo = new Tuple<string, int>(personName, beerAmount);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int firstNum = int.Parse(thirdInput[0]);
            double secondNum = double.Parse(thirdInput[1]);

            Tuple<int, double> numbers = new Tuple<int, double>(firstNum, secondNum);

            Console.WriteLine(persnInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(numbers);
        }
    }
}
