using System;

namespace Project2
{
    static class DateDifference
    {
        public static int YearsFromSometimesToToday(DateTime someDate)
        {
            DateTime today = DateTime.Now;
            return today.Year - someDate.Year + ((someDate.Month >= today.Month && someDate.Day >= today.Day) ? -1 : 0);
        }
    }
}
