namespace CronExpressionParser
{
    internal static class Extensions
    {
        public static bool CheckIfAsterik(this string value)
        {
            if(value.Equals("*"))
            {
                return true;
            }

            return false;
        }
    }
}
