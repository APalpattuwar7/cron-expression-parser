using CronExpressionParser;
using Xunit;

namespace CronExpressionParserTests
{
    public class ParserTests
    {
        #region Minute Tests

        [Fact]
        public void ParseMinute_WhenPassAnyAndStepValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*/15"
            };

            var expected = "0 15 30 45 ";
            var result = Parser.ParseMinute(cron.Minute);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseMinute_WhenPassAnyValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*"
            };

            var expected = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 ";
            var result = Parser.ParseMinute(cron.Minute);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseMinute_WhenPassValueListSeparator_ShouldReturnTwoValues()
        {
            var cron = new Cron()
            {
                Minute = "1,5"
            };

            var expected = "1 5";
            var result = Parser.ParseMinute(cron.Minute);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseMinute_WhenPassRangeOfValues_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "1-5"
            };

            var expected = "1 2 3 4 5 ";
            var result = Parser.ParseMinute(cron.Minute);
            Assert.Equal(result, expected);
        }

        #endregion

        #region Hour Tests

        [Fact]
        public void ParseHour_WhenPassAnyAndStepValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*/15",
                Hour = "*/10"
            };

            var expected = "0 10 20 ";
            var result = Parser.ParseHour(cron.Hour);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseHour_WhenPassAnyValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*",
                Hour = "*"
            };

            var expected = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 ";
            var result = Parser.ParseHour(cron.Hour);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseHour_WhenPassValueListSeparator_ShouldReturnTwoValues()
        {
            var cron = new Cron()
            {
                Minute = "1,5",
                Hour = "2,7"
            };

            var expected = "2 7";
            var result = Parser.ParseHour(cron.Hour);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ParseHour_WhenPassRangeOfValues_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "1-5",
                Hour = "5-10"
            };

            var expected = "5 6 7 8 9 10 ";
            var result = Parser.ParseHour(cron.Hour);
            Assert.Equal(result, expected);
        }

        #endregion

        #region DayOfMonth Tests

        [Fact]
        public void DayOfMonth_WhenPassAnyAndStepValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*/15",
                Hour = "*/10",
                DayOfMonth = "*/2"
            };

            var expected = "2 4 6 8 10 12 14 16 18 20 22 24 26 28 30 ";
            var result = Parser.ParseDayOfMonth(cron.DayOfMonth);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfMonth_WhenPassAnyValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*",
                Hour = "*",
                DayOfMonth = "*"
            };

            var expected = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 ";
            var result = Parser.ParseDayOfMonth(cron.DayOfMonth);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfMonth_WhenPassValueListSeparator_ShouldReturnTwoValues()
        {
            var cron = new Cron()
            {
                Minute = "1,5",
                Hour = "2,7",
                DayOfMonth = "1,15"
            };

            var expected = "1 15";
            var result = Parser.ParseDayOfMonth(cron.DayOfMonth);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfMonth_WhenPassRangeOfValues_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "1-5",
                Hour = "5-10",
                DayOfMonth = "25-30"
            };

            var expected = "25 26 27 28 29 30 ";
            var result = Parser.ParseDayOfMonth(cron.DayOfMonth);
            Assert.Equal(result, expected);
        }

        #endregion

        #region Month Tests

        [Fact]
        public void Month_WhenPassAnyAndStepValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*/15",
                Hour = "*/10",
                DayOfMonth = "*/2",
                Month = "*/2"
            };

            var expected = "2 4 6 8 10 12 ";
            var result = Parser.ParseMonth(cron.Month);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Month_WhenPassAnyValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*",
                Hour = "*",
                DayOfMonth = "*",
                Month = "*"
            };

            var expected = "1 2 3 4 5 6 7 8 9 10 11 12 ";
            var result = Parser.ParseMonth(cron.Month);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Month_WhenPassValueListSeparator_ShouldReturnTwoValues()
        {
            var cron = new Cron()
            {
                Minute = "1,5",
                Hour = "2,7",
                DayOfMonth = "1,15",
                Month = "10,12"
            };

            var expected = "10 12";
            var result = Parser.ParseMonth(cron.Month);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Month_WhenPassRangeOfValues_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "1-5",
                Hour = "5-10",
                DayOfMonth = "25-30",
                Month = "2-7"
            };

            var expected = "2 3 4 5 6 7 ";
            var result = Parser.ParseMonth(cron.Month);
            Assert.Equal(result, expected);
        }

        #endregion

        #region DayOfWeek Tests

        [Fact]
        public void DayOfWeek_WhenPassAnyAndStepValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*/15",
                Hour = "*/10",
                DayOfMonth = "*/2",
                Month = "*/2",
                DayOfWeek = "*/1"
            };

            var expected = "0 1 2 3 4 5 6 ";
            var result = Parser.ParseDayOfWeek(cron.DayOfWeek);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfWeek_WhenPassAnyValue_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "*",
                Hour = "*",
                DayOfMonth = "*",
                Month = "*",
                DayOfWeek = "*"
            };

            var expected = "0 1 2 3 4 5 6 ";
            var result = Parser.ParseDayOfWeek(cron.DayOfWeek);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfWeek_WhenPassValueListSeparator_ShouldReturnTwoValues()
        {
            var cron = new Cron()
            {
                Minute = "1,5",
                Hour = "2,7",
                DayOfMonth = "1,15",
                Month = "10,12",
                DayOfWeek = "1,7"
            };

            var expected = "1 7";
            var result = Parser.ParseDayOfWeek(cron.DayOfWeek);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void DayOfWeek_WhenPassRangeOfValues_ShouldReturnRange()
        {
            var cron = new Cron()
            {
                Minute = "1-5",
                Hour = "5-10",
                DayOfMonth = "25-30",
                Month = "2-7",
                DayOfWeek = "1-7"
            };

            var expected = "1 2 3 4 5 6 7 ";
            var result = Parser.ParseDayOfWeek(cron.DayOfWeek);
            Assert.Equal(result, expected);
        }

        #endregion

        [Fact]
        public void AdditionalArg_WhenPassValidValue_ReturnsRange()
        {
            var cron = new Cron
            {
                AdditionalArgs = "@yearly"
            };

            var result = Parser.ParseSpecialString(cron.AdditionalArgs);
            Assert.Equal("", result);

        }
    }
}
