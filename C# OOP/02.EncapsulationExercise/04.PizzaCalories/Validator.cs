using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public static class Validator
    {
        public static void ThrowExceptionIfNumberIsOutOfRange(int minValue, int maxValue, double value, string exceptionMessage)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfValueISNotInSet(HashSet<string> set, string value, string exceptionMessage)
        {
            if (!set.Contains(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
