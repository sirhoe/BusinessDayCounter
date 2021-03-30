using InterviewQuestion.Utils;
using System;
using System.Collections.Generic;
using Xunit;

namespace InterviewQuestion.Test.UtilsTest
{
    public class WeekdayCheckerTest
    {
        [Theory]
        [InlineData("2013-10-7", true)]
        [InlineData("2013-10-8", true)]
        [InlineData("2013-10-9", true)]
        [InlineData("2013-10-10", true)]
        [InlineData("2013-10-11", true)]
        [InlineData("2013-10-12", false)]
        [InlineData("2013-10-13", false)]
        public void isWeekDay_InputDate_ReturnIsMondayToFriday(DateTime date, bool expected)
        {
            var actual = WeekdayChecker.isWeekDay(date);
            Assert.Equal(expected, actual);
        }
    }
}
