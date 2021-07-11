using System;
using _03.Telephony.Contracts;

namespace _03.Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
