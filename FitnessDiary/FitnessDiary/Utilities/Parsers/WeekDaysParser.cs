using FitnessDiary.Utilities.Enums;
using FitnessDiary.Utilities.Messages;
using System;
using System.Linq;

namespace FitnessDiary.Utilities.Parsers
{
    public static class WeekDaysParser
    {
        static public  WeekDays Parse(string weekDay)
        {
            switch (weekDay.ToLower())
            {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                case "saturday":
                case "sunday":

                    return (WeekDays)Enum.Parse(typeof(WeekDays), MakeTheFirstLetterToUpper(weekDay.ToLower()));

                default:

                    throw new InvalidOperationException(string.Format(
                        ExceptionMessages.InvalidWeekDay,
                        weekDay));
            }
        }
        private static string MakeTheFirstLetterToUpper(string word)
        {
            return word.First().ToString().ToUpper() + word.Substring(1);
        }
    }
}
