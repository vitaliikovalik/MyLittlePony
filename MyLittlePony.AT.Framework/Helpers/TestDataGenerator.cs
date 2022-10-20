using System;
using System.Linq;
using MyLittlePony.AT.Framework.Logger;

namespace MyLittlePony.AT.Framework.Helpers
{
    public static class TestDataGenerator
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rndString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            WriteLog.Info($"Generate random string: {rndString}");

            return rndString;
        }

        public static string RandomNumberString(int length)
        {
            var rndInt = string.Empty;

            for (int i = 0; i < length; i++)
            {
                rndInt += random.Next(1, 9);
                WriteLog.Info($"Generate random string of numbers: {rndInt}");
            }

            return rndInt;
        }

        public static int RandomInt(int minValue = 1, int maxValue = 1000)
        {
            var rndInt = random.Next(minValue, maxValue);

            WriteLog.Info($"Generate random int: {rndInt}");

            return rndInt;
        }

        /// <summary>
        /// Method calculate the start date depend of how many days left to end of month
        /// </summary>
        /// <param name="daysBeforeMoveStartDate">By default start day is moved +1 month if it is closer then 7 days before end of month</param>
        /// <returns>Nearest possible Start date</returns>
        public static DateTime CalculateNearestStartDate(double daysBeforeMoveStartDate = -7)
        {
            //today date
            var now = DateTime.UtcNow;

            //First of next month
            var nextMonth =
                new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.AddMonths(1).Month, 1);

            // Number of days that left before next month
            var daysAgo = now.Subtract(nextMonth).TotalDays;

            //if Number of days left to next month is greater than daysBeforeMoveStartDate, next month will be the nearest, else month after the next
            var nearestPossibleEnrolledDate =
                new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.AddMonths(daysAgo < daysBeforeMoveStartDate ? 1 : 2).Month, 1);

            WriteLog.Info($"Nearest date for Start date is: {nearestPossibleEnrolledDate:dd MMM yyyy}");

            return nearestPossibleEnrolledDate;
        }
    }
}
