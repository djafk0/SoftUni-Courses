using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string pack = Console.ReadLine();
            double countOfPacks = double.Parse(Console.ReadLine());

            double countInPack = 0;
            double discount = 1;
            double watermelon = 0;
            double mango = 0;
            double pineapple = 0;
            double raspberry = 0;

            double total = 0;
            if (pack == "small")
            {
                countInPack = 2;
                if (fruit == "Watermelon")
                {
                    watermelon = 56;
                    total = countOfPacks * watermelon * countInPack;
                }
                else if (fruit == "Mango")
                {
                    mango = 36.66;
                    total = countOfPacks * mango * countInPack;
                }
                else if (fruit == "Pineapple")
                {
                    pineapple = 42.10;
                    total = countOfPacks * pineapple * countInPack;
                }
                else if (fruit == "Raspberry")
                {
                    raspberry = 20;
                    total = countOfPacks * raspberry * countInPack;
                }
            }
            else if (pack == "big")
            {
                countInPack = 5;
                if (fruit == "Watermelon")
                {
                    watermelon = 28.7;
                    total = countOfPacks * watermelon * countInPack;
                }
                else if (fruit == "Mango")
                {
                    mango = 19.6;
                    total = countOfPacks * mango * countInPack;
                }
                else if (fruit == "Pineapple")
                {
                    pineapple = 24.8;
                    total = countOfPacks * pineapple * countInPack;
                }
                else if (fruit == "Raspberry")
                {
                    raspberry = 15.2;
                    total = countOfPacks * raspberry * countInPack;
                }
            }

            if (total >= 400 && total <= 1000)
            {
                discount = 0.85;
            }
            else if (total > 1000)
            {
                discount = 0.5;
            }

            double sum = total * discount;
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
