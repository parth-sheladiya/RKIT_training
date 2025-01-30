using System;


namespace Basic_C_Sharp
{
   public class DateTimeClassDemo
    {
        public static void RunDateTimeClassDemo()
        {
            #region Creating DateTime Objects
            DateTime current = DateTime.Now;
            DateTime today = DateTime.Today;

            Console.WriteLine(current);
            Console.WriteLine(today);

            DateTime specificDate = new DateTime(2024, 12, 25);
            Console.WriteLine(specificDate);

            DateTime specificDateTime = new DateTime(2024, 12, 25, 10, 30, 45);
            Console.WriteLine(specificDateTime);


            #endregion

            #region Manipulating Dates and Times
            Console.WriteLine("Manipulating Dates and Times");
            DateTime thisToday = DateTime.Today;
            DateTime nextWeek = thisToday.AddDays(7);
            DateTime lastMonth = thisToday.AddMonths(-1);
            DateTime nextyear = thisToday.AddYears(5);

            Console.WriteLine("next week : " + nextWeek);
            Console.WriteLine("last month : "+lastMonth);
            Console.WriteLine("five  year after : " + nextyear);

            #endregion


            #region Formatting Dates and Times
            Console.WriteLine("formatting date and time");
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("yyyy-MM-dd"));
            Console.WriteLine(now.ToString("dd/MM/yyyy"));
            Console.WriteLine(now.ToString("dddd, MMMM dd, yyyy"));


            #endregion

            #region Parsing and Converting Strings to DateTime
            Console.WriteLine("Parsing and Converting Strings to DateTime");
            string dateStr = "2024-12-14";
            DateTime parsedDate = DateTime.Parse(dateStr);
            Console.WriteLine(parsedDate);

            #endregion

            #region  Working with TimeZones
            Console.WriteLine("Working with TimeZones");
            DateTime local = DateTime.Now;
            DateTime utc = DateTime.UtcNow;

            Console.WriteLine("local time : " + local); 
            Console.WriteLine("utc time : " + utc);

            Console.WriteLine("Converting TimeZones");
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utc, localZone);

            Console.WriteLine(localTime);
            #endregion

            #region evnet count doen example
            Console.WriteLine("event count down example");
            DateTime eventDate = new DateTime(2024, 12, 30);
            DateTime currentDay = DateTime.Today;

            TimeSpan countdown = eventDate - currentDay;
            Console.WriteLine($"Days until event: {countdown.Days} days");
            #endregion
        }
    }
}
