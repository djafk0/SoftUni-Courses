using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlowers = Console.ReadLine();
            double numberOfFlowers = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double flowerPrice = 0;
            double discount = 0;

            if (typeOfFlowers == "Roses")
            {
                if (numberOfFlowers > 80)
                {
                    discount = 0.9;
                }
                flowerPrice = 5;
            }
            else if (typeOfFlowers == "Dahlias")
            {
                if (numberOfFlowers > 90)
                {
                    discount = 0.85;
                }
                flowerPrice = 3.8;
            }
            else if (typeOfFlowers == "Tulips")
            {
                if (numberOfFlowers > 80)
                {
                    discount = 0.85;
                }
                flowerPrice = 2.8;
            }
            else if (typeOfFlowers == "Narcissus")
            {
                if (numberOfFlowers < 120)
                {
                    discount = 1.15;
                }
                flowerPrice = 3;
            }
            else if (typeOfFlowers == "Gladiolus")
            {
                if (numberOfFlowers < 80)
                {
                    discount = 1.2;
                }
                flowerPrice = 2.5;
            }
            if (discount != 0)
            {
                double finalResult = numberOfFlowers * flowerPrice * discount;
                if (budget >= finalResult)
                {
                    double moneyNeeded = budget - finalResult;
                    Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {moneyNeeded:f2} leva left.");
                }
                else
                {
                    double moneyNeeded = finalResult - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
            }
            else
            {
                double finalResult = numberOfFlowers * flowerPrice;
                if (budget >= finalResult)
                {
                    double moneyNeeded = budget - finalResult;
                    Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {moneyNeeded:f2} leva left.");
                }
                else
                {
                    double moneyNeeded = finalResult - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
            }
        }
    }
}
