using System;
using System.Globalization;

namespace _05.DateModifier
{
    class DateModifier
    {
        public static double GetDaysDifferenceBetweenDates(string dateOne, string dateTwo)
        {
            var firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

            if (firstDate > secondDate)
            {
                return GetDaysDifferenceBetweenDates(dateTwo, dateOne);
            }

            return (secondDate - firstDate).Days;
        }
    }
}
