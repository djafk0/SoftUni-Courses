using System;

namespace years
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            decimal years = centuries * 100;
            decimal averageDays = 365.2422M;
            decimal days = Math.Floor(years * averageDays);
            decimal hours = days * 24;
            decimal minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");

        }
    }
}
