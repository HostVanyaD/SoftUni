using System;
using _03.Telephony.Models;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ");
            string[] sitesToVisit = Console.ReadLine()
                .Split(" ");

            Smartphone smartPhone = new Smartphone();
            StationaryPhone phone = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                if (PhoneNumberIsValid(number) == false)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (number.Length == 10)
                {
                    smartPhone.Call(number);
                }
                else if (number.Length == 7)
                {
                    phone.Call(number);
                }
            }

            foreach (var site in sitesToVisit)
            {
                if (SiteUrlIsValid(site) == false)
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                smartPhone.Browse(site);
            }
        }

        private static bool SiteUrlIsValid(string site)
        {
            foreach (var element in site)
            {
                if (Char.IsDigit(element))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool PhoneNumberIsValid(string number)
        {
            foreach (var element in number)
            {
                if (!Char.IsDigit(element))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
