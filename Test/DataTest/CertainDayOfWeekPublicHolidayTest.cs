using System;
using System.Collections.Generic;
using Xunit;
using InterviewQuestion.Data;

namespace InterviewQuestion.Test.DataTest
{
    public class CertainDayofWeekPublicHolidayTest
    {
        [Theory]
        [InlineData(2013, 6, DayOfWeek.Monday, 2, "2013-6-10")]
        [InlineData(2013, 6, DayOfWeek.Monday, 3, "2013-6-17")]
        public void getHoliday_InputDate_ReturnDate(int year, int month, DayOfWeek dayOfWeek, int occurence, DateTime expected)
        {
            var rule = new CertainDayOfWeekPublicHoliday(month, dayOfWeek, occurence);
            var actual = rule.getPublicHoliday(year);
            Assert.Equal(expected, actual);
        }
    }
}
