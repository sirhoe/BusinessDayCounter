using System;
using InterviewQuestion.Utils;

namespace InterviewQuestion.Data
{           
    public class CertainDayOfWeekPublicHoliday : IHasPublicHoliday
    {
        private int _month;
        private DayOfWeek _dayOfWeek;
        private int _occurence;

        public CertainDayOfWeekPublicHoliday(int month, DayOfWeek dayOfWeek, int occurence) {
            this._month = month;
            this._dayOfWeek = dayOfWeek;
            this._occurence = occurence;
        }

        public DateTime getPublicHoliday(int year) {
            DateTime result = new DateTime(year, this._month, 1);
            while(result.DayOfWeek != this._dayOfWeek) {
                result = result.AddDays(1);
            }

            // I have decided not to handle th case where the nth-dayOfWeek might fall into the next month 
            return result.AddDays(7 * (this._occurence-1));
        }
    }
}