using System;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int DateBetweenTwoDatesInDays(string dateOneStr, string dateTwoStr)
        {
            DateTime firstDate = DateTime.Parse(dateOneStr);
            DateTime secondDate = DateTime.Parse(dateTwoStr);
            TimeSpan result = firstDate - secondDate;
            return result.Days; 
        }
    }
}
