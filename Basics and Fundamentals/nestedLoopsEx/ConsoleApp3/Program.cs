using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            double averageGoldPerDay = 0;
            double numberOfDays = 0;
            double goldDiggedCurrentDay = 0;
            double goldDigged = 0;
            double totalGoldDigged = 0;
            int numberOfLocations = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfLocations; i++)
            {
                averageGoldPerDay = double.Parse(Console.ReadLine());
                numberOfDays = double.Parse(Console.ReadLine());
                for (int j = 1; j <= numberOfDays; j++)
                {
                    goldDiggedCurrentDay = double.Parse(Console.ReadLine());
                    totalGoldDigged += goldDiggedCurrentDay;
                }
                goldDigged = totalGoldDigged / numberOfDays;
                if (goldDigged >= averageGoldPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {goldDigged:f2}.");
                }
                else
                {
                    double notEnough = averageGoldPerDay - goldDigged;
                    Console.WriteLine($"You need {notEnough:f2} gold.");
                }
                totalGoldDigged = 0;
            }
        }
    }
}
