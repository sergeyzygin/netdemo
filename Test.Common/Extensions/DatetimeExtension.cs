using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Common.Extensions
{
    public static class DatetimeExtension
    {
        /*
         * Calculate years of work
         */
        public static int GetYearLeft(DateTime startDate)
        {
            DateTime now = DateTime.Now;

            int year = now.Year - startDate.Year;
            if (now.Month < startDate.Month || (now.Month == startDate.Month && now.Day < startDate.Day))
                year--;

            return year;
        }
    }
}
