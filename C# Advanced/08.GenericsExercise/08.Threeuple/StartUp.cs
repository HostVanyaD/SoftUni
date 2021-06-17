using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = firstInput[3];

            if (firstInput.Length > 4)
            {
                town += $" {firstInput[4]}";
            }

            Threeuple<string, string, string> persnInfo = new Threeuple<string, string, string>(fullName, address, town);

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string personName = secondInput[0];
            int beerAmount = int.Parse(secondInput[1]);
            bool state = DrunkOrNot(secondInput[2]);

            Threeuple<string, int, bool> beerInfo = new Threeuple<string, int, bool>(personName, beerAmount, state);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string accountName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            Threeuple<string, double, string> bankDetails = new Threeuple<string, double, string>(accountName, accountBalance, bankName);

            Console.WriteLine(persnInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(bankDetails);
        }

        private static bool DrunkOrNot(string v)
        {
            if (v == "drunk")
            {
                return true;
            }
            return false;           
        }
    }
}
