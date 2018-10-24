using System;
using System.Text;

namespace Dante.Models
{
    public static class DateTimeDisplay
    {
        public static string ToDanteDT(this DateTime datetime)
        {
            string JustTheTime = string.Format(" at {0:t}", datetime);

            // Only show the year if it's not the current year.
            if (datetime.Year != DateTime.Now.Year)
                return datetime.ToString("dd MMMM yyyy") + JustTheTime;
            else
            {
                int diff = (DateTime.Now - datetime).Days;
                // If it is in the past 7 days, just show the day of the week, not the date and month
                if (diff > 7)
                    return datetime.ToString("dd MMMM") + JustTheTime;
                else
                    if (datetime.Date == DateTime.Now.Date)
                        return "Today" + JustTheTime;
                return datetime.DayOfWeek.ToString() + JustTheTime;
            }
        }
    }
}