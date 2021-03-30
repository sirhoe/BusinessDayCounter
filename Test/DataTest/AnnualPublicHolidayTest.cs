using System;
using System.Collections.Generic;
using Xunit;
using InterviewQuestion.Data;

namespace InterviewQuestion.Test.DataTest
{
    public class AnnualPublicHolidayTest
    {
        [Theory]
        [InlineData("2013-11-9", false, "2013-11-9")]
        [InlineData("2013-11-9", true, "2013-11-11")]
        public void getHoliday_InputDate_ReturnMovedToNextMondayIfSet(DateTime holiday, bool shouldMove, DateTime expected)
        {
            var rule = new AnnualPublicHoliday(holiday.Month, holiday.Day, shouldMove);
            var actual = rule.getPublicHoliday(holiday.Year);
            Assert.Equal(expected, actual);
        }
    }
}
