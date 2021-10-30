using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string type = "";
            string location = "";
            double money = 0;

            if (budget <= 100)
            {
                location = "Bulgaria";
                if (season == "summer")
                {
                    type = "Camp";
                    money = budget * 0.3;
                }
                else
                {
                    type = "Hotel";
                    money = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                location = "Balkans";
                if (season == "summer")
                {
                    type = "Camp";
                    money = budget * 0.4;
                }
                else
                {
                    type = "Hotel";
                    money = budget * 0.8;
                }
            }
            else
            {
                type = "Hotel";
                location = "Europe";
                money = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{type} - {money:f2}");
        }
    }
}
