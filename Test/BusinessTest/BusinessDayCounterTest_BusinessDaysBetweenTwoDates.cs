using System;
using System.Collections.Generic;
using Xunit;
using InterviewQuestion;
using InterviewQuestion.Data;

namespace InterviewQuestion.Test.BusinessTest
{
    public class BusinessDayCounter_BusinessDaysBetweenTwoDates : BusinessDayCounterTest_Setup
    {
        List<DateTime> holidays;
        List<IHasPublicHoliday> complexPublicHolidayRules_moveWeekendHolidayToNextMonday;

        List<IHasPublicHoliday> complexPublicHolidayRules_notMovedToNextMonday;

        public BusinessDayCounter_BusinessDaysBetweenTwoDates() {
            holidays = new List<DateTime> {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };

            complexPublicHolidayRules_moveWeekendHolidayToNextMonday = new List<IHasPublicHoliday> {
                new AnnualPublicHoliday(11, 9, true)    // 9th of Nov
            };

            complexPublicHolidayRules_notMovedToNextMonday = new List<IHasPublicHoliday> {
                new AnnualPublicHoliday(11, 9, false),
                new CertainDayOfWeekPublicHoliday(6, DayOfWeek.Monday, 2) // Queen's bday 2nd Monday of June
            };
        }

        [Theory]
        [InlineData("2013-10-7", "2013-10-5", 0)]
        public void BusinessDaysBetweenTwoDates_InputFirstDateLaterThanSecondDate_Return0(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2013-10-7", "2013-10-9", 1)]
        [InlineData("2013-12-24", "2013-12-27", 0)]
        [InlineData("2013-10-7", "2014-1-1", 59)]
        public void BusinessDaysBetweenTwoDates_InputValidFirstAndSecondDate_ReturnDays(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2013-11-7", "2013-11-12", 1)] //only 8Nov2013 is counted, 9Nov2013 (Saturday) public holiday is moved to 11Nov2013
        public void BusinessDaysBetweenTwoDates_InputAnnualPublicHoliday_ReturnHolidayMovedToNextMonday(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays, complexPublicHolidayRules_moveWeekendHolidayToNextMonday);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2013-11-7", "2013-11-12", 2)] //only 8Nov2013 is counted, 9Nov2013 (Saturday) public holiday will not be moved
        public void BusinessDaysBetweenTwoDates_InputAnnualPublicHoliday_ReturnHolidayNotMovedToNextMonday(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays, complexPublicHolidayRules_notMovedToNextMonday);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2013-6-9", "2013-6-11", 0)] //2nd Monday of June 2013 is 10thJune
        [InlineData("2013-6-16", "2013-6-18", 1)] //Following week not a holiday
        public void BusinessDaysBetweenTwoDates_InputCertainDayOfWeekPublicHoliday_ReturnHoliday(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays, complexPublicHolidayRules_notMovedToNextMonday);
            Assert.Equal(expected, actual);
        }
    }
}
