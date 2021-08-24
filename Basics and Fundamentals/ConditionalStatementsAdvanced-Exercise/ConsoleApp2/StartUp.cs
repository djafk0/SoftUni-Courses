using System;

namespace ConsoleApp2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double homeWeekends = double.Parse(Console.ReadLine());

            double weekendInSofia = (48 - homeWeekends) * 3/4.0;
            double holidayPlays = holidays * 2 / 3.0;

            double plays = homeWeekends + weekendInSofia + holidayPlays;

            if (year == "leap")
            {
                plays *= 1.15;
            }
            Console.WriteLine(Math.Floor(plays));
        }
    }
}
