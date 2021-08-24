using System;

namespace _1._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            int number = int.Parse(Console.ReadLine());

            if (number >= 1 && number <= 7)
            {
                number--;
                Console.WriteLine(days[number]);
            }
            else
            {
                Console.WriteLine($"Invalid day!");
            }
        }
    }
}
