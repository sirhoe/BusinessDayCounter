using System;
using System.Collections.Generic;
using Xunit;
using InterviewQuestion;

namespace InterviewQuestion.Test.BusinessTest
{
    public class BusinessDayCounter_WeekdaysBetweenTwoDates : BusinessDayCounterTest_Setup
    {
        [Theory]
        [InlineData("2013-10-7", "2013-10-5", 0)]
        public void WeekdaysBetweenTwoDates_InputFirstDateLaterThanSecondDate_Return0(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.WeekdaysBetweenTwoDates(firstDate, secondDate);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2013-10-7", "2013-10-9", 1)]
        [InlineData("2013-10-5", "2013-10-14", 5)]
        [InlineData("2013-10-7", "2014-1-1", 61)]
        public void WeekdaysBetweenTwoDates_InputValidFirstAndSecondDate_ReturnDays(DateTime firstDate, DateTime secondDate, int expected)
        {
            var actual = businessDayCounterTest.WeekdaysBetweenTwoDates(firstDate, secondDate);
            Assert.Equal(expected, actual);
        }
    }
}
