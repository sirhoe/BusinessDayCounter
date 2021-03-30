using System;

namespace InterviewQuestion.Utils
{
    public class WeekdayChecker {
        public static bool isWeekDay(DateTime date) {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) ? false : true;
        }
    }
}