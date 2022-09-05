namespace CronExpressionParser
{
    public class Cron
    {
        public string Minute { get; set; }

        public string Hour { get; set; }

        public string DayOfMonth { get; set; }

        public string Month { get; set; }

        public string DayOfWeek { get; set; }

        public string Command { get; set; }
        public string AdditionalArgs { get; set; }
    }
}
