using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }
        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string randmString = this[index];

            this.RemoveAt(index);
            
            return randmString;
        }
    }
}
