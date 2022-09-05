using System;

namespace CronExpressionParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cronExpression = args[0];
            string[] expressions = cronExpression.Split(new char[] { ' ' });

            Cron cron;
            if (expressions.Length == 2)
            {
                cron = new Cron()
                {
                    AdditionalArgs = expressions[0],
                    Command = expressions[1]
                };

                Console.WriteLine(Parser.ParseSpecialString(cron.AdditionalArgs));
            }
            else
            {
                cron = new Cron()
                {
                    Minute = expressions[0],
                    Hour = expressions[1],
                    DayOfMonth = expressions[2],
                    Month = expressions[3],
                    DayOfWeek = expressions[4],
                    Command = expressions[5]
                };

                if (string.IsNullOrEmpty(cron.Hour)
               || string.IsNullOrEmpty(cron.Minute)
               || string.IsNullOrEmpty(cron.DayOfMonth)
               || string.IsNullOrEmpty(cron.Month)
                || string.IsNullOrEmpty(cron.DayOfWeek))
                {
                    Console.WriteLine("Invalid Cron string");
                    Environment.Exit(0);
                }

                Parser.Parse(cron);
            }

            
        }
    }
}
