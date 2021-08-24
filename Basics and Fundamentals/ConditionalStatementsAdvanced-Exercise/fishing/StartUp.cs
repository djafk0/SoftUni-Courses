using System;

namespace fishing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double numberOfFishers = double.Parse(Console.ReadLine());

            double rentForBoat = 0;
            double discountOne = 0;
            double discountTwo = 1;

            if (numberOfFishers <= 6)
            {
                discountOne = 0.9;
            }
            else if (7 <= numberOfFishers && numberOfFishers <= 11)
            {
                discountOne = 0.85;
            }
            else if (numberOfFishers > 11)
            {
                discountOne = 0.75;
            }

            if (season == "Spring")
            {
                rentForBoat = 3000;
            }
            else if (season == "Autumn" || season == "Summer")
            {
                rentForBoat = 4200;
            }
            else if (season == "Winter")
            {
                rentForBoat = 2600;
            }

            if (numberOfFishers % 2 == 0 && season != "Autumn")
            {
                discountTwo = 0.95;
            }

            double finalResult = rentForBoat * discountOne * discountTwo;
            double moneyLeft = Math.Abs(budget - finalResult);

            Console.WriteLine(budget < finalResult ? $"Not enough money! You need {moneyLeft:f2} leva." : $"Yes! You have {moneyLeft:f2} leva left.");
        }
    }
}

