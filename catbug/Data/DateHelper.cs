using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Data
{
    public static class DateHelper
    {
        public static string ToSimple(this DateTime date)
        {
            TimeSpan difference = DateTime.UtcNow - date;
            int seconds = (int)difference.TotalSeconds;
            int minutes = (int)difference.TotalMinutes;
            int hours = (int)difference.TotalHours;
            int days = (int)difference.TotalDays;
            double months = (int)(difference.TotalDays / 365.2422 * 12);
            double years = (int)(difference.TotalDays / 365.2422);

            if (years > 0)
            {
                return years + " year" + (years != 1 ? "s" : "") + " ago";
            }
            else if (months > 0)
            {
                return months + " month" + (months != 1 ? "s" : "") + " ago";
            }
            else if (days > 0)
            {
                return days + " day" + (days != 1 ? "s" : "") + " ago";
            }
            else if (hours > 0)
            {
                return hours + " hour" + (hours != 1 ? "s" : "") + " ago";
            }
            else if (minutes > 0)
            {
                return minutes + " minute" + (minutes != 1 ? "s" : "") + " ago";
            }
            else if (seconds > 0)
            {
                return seconds + " second" + (seconds != 1 ? "s" : "") + " ago";
            }
            else
            {
                return "just now";
            }
        }
    }
}
