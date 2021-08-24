using System;
using System.Globalization;

namespace fundamentalsIntro
{
    class GETMONTH
    {
        static void Main(string[] args)
        {
            int monthNumber = int.Parse(Console.ReadLine());  
            string monthName = new DateTimeFormatInfo().GetMonthName(monthNumber);
            Console.WriteLine(monthName);
        }
    }
}
