using System;
using InterviewQuestion.Utils;

namespace InterviewQuestion.Data
{           
    public class AnnualPublicHoliday : IHasPublicHoliday
    {
        private int _month;
        private int _day;
        private bool _shouldMoveIfFallOnWeekend;

        public AnnualPublicHoliday(int month, int day, bool shouldMoveIfFallOnWeekend) {
            this._month = month;
            this._day = day;
            this._shouldMoveIfFallOnWeekend = shouldMoveIfFallOnWeekend;
        }

        public DateTime getPublicHoliday(int year) {
            DateTime holiday = new DateTime(year, this._month, this._day);
            return WeekdayChecker.isWeekDay(holiday) ? holiday : (this._shouldMoveIfFallOnWeekend ? getNextMonday(holiday) : holiday) ;
        }

        private DateTime getNextMonday(DateTime date) {
            int daysUntilMonday = ((int) DayOfWeek.Monday - (int) date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilMonday);
        }
    }
}