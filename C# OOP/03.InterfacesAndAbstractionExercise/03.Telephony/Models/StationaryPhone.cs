using System;
using _03.Telephony.Contracts;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
