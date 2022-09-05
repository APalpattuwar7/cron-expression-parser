using System;
using System.Text;

namespace CronExpressionParser
{
    public class Parser
    {
        public static void Parse(Cron cron)
        {
            var minute = ParseMinute(cron.Minute);
            var hour = ParseHour(cron.Hour);
            var dayOfMonth = ParseDayOfMonth(cron.DayOfMonth);
            var month = ParseMonth(cron.Month);
            var dayOfWeek = ParseDayOfWeek(cron.DayOfWeek);
            var specialStringResult = ParseSpecialString(cron.AdditionalArgs);

            PrintResult(minute, hour, dayOfMonth, month, dayOfWeek, cron.Command);
        }

        public static string ParseMinute(string minute)
        {
            return ProcessAttribute(minute, 60);
        }

        public static string ParseHour(string hour)
        {
            return ProcessAttribute(hour, 24);
        }

        public static string ParseDayOfMonth(string dayOfMonth)
        {
            return ProcessAttribute(dayOfMonth, 32, "DayOfMonth");
        }

        public static string ParseMonth(string month)
        {
            return ProcessAttribute(month, 13, "Month");
        }

        public static string ParseDayOfWeek(string dayOfWeek)
        {
            return ProcessAttribute(dayOfWeek, 7);
        }

        private static void PrintResult(string minute, string hour, string dayOfMonth, string month, string dayOfWeek, string command)
        {
            Console.WriteLine($"minute\t\t {minute}");
            Console.WriteLine($"hour\t\t {hour}");
            Console.WriteLine($"day of month\t {dayOfMonth}");
            Console.WriteLine($"month\t\t {month}");
            Console.WriteLine($"day of week\t {dayOfWeek}");
            Console.WriteLine($"command\t\t {command}");
        }

        private static string ProcessAttribute(string attribute, int endValue, string type = "")
        {
            if (attribute.CheckIfAsterik())
            {
                return GenerateEveryValue(endValue, type);
            }
            else if (attribute.StartsWith("*/"))
            {
                return GenerateStepValues(attribute.Replace("*/", ""), endValue, type);
            }
            else if (attribute.Contains(","))
            {
                return attribute.Split(',')[0] + " " + attribute.Split(',')[1];
            }
            else if (attribute.Contains("-"))
            {
                string startVal = attribute.Split('-')[0];
                var endVal = attribute.Split('-')[1];

                return GenerateRangeOfValues(Convert.ToInt32(startVal), Convert.ToInt32(endVal));
            }

            return attribute;
        }

        private static string GenerateRangeOfValues(int start, int end)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = start; i <= end; i++)
            {
                builder.Append(i);
                builder.Append(' ');
            }
            return builder.ToString();
        }

        private static string GenerateEveryValue(int endValue, string type)
        {
            int i = type == "DayOfMonth" || type == "Month" ? 1 : 0;
            StringBuilder builder = new StringBuilder();
            while (i < endValue)
            {
                builder.Append(i++);
                builder.Append(' ');
            }

            return builder.ToString();
        }

        private static string GenerateStepValues(string attribute, int endValue, string type)
        {
            int multiplier = type == "DayOfMonth" || type == "Month" ? 1 : 0;
            int minute = Convert.ToInt32(attribute);
            StringBuilder builder = new StringBuilder();

            for (; minute*multiplier < endValue; multiplier++)
            {
                builder.Append(minute * multiplier);
                builder.Append(' ');
            }

            return builder.ToString();
        }

        public static object ParseSpecialString(string specialString)
        {
            return "Schedule a job for first minute of every year";
        }
    }
}
