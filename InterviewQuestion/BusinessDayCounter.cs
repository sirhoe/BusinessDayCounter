using System;
using System.Collections;
using System.Collections.Generic;
using InterviewQuestion.Utils;
using InterviewQuestion.Data;

namespace InterviewQuestion
{
    public class BusinessDayCounter 
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)  { 
            return BusinessDaysBetweenTwoDates(firstDate, secondDate, new List<DateTime>());
        } 

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays) 
        { 
            if (isStartDateAfterEndDate(firstDate, secondDate)) {
                return 0;
            }

            int businessDaysBetweenTwoDates = 0;
            for(var day = firstDate.Date.AddDays(1); day < secondDate; day = day.AddDays(1)) {
                if(WeekdayChecker.isWeekDay(day) && isNotHoliday(day, publicHolidays)) {
                    businessDaysBetweenTwoDates++;
                }
            }

            return businessDaysBetweenTwoDates;
        }

        // Supports additional fixed date holiday and complex rules.
        // as required in Task 3
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays, IList<IHasPublicHoliday> complexPublicHolidayRule) 
        {   
            // the complex rules will be flatten to a specific DateTime by the year
            foreach(var rule in complexPublicHolidayRule) {
                publicHolidays.Add(rule.getPublicHoliday(firstDate.Year));

                if(firstDate.Year != secondDate.Year) {
                    publicHolidays.Add(rule.getPublicHoliday(secondDate.Year));
                }
            }

            return BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);
        }

        private bool isStartDateAfterEndDate(DateTime firstDate, DateTime secondDate) {
            return firstDate >= secondDate ? true : false;
        }

        private bool isNotHoliday(DateTime date, IList<DateTime> holidays) {
            return !holidays.Contains(date);          
        }
    } 
}
