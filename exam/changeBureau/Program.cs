using System;

namespace changeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitCoins = int.Parse(Console.ReadLine());
            double chinesseMoney = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double bitCoinInLeva = 1168;
            double chinesseJuanInDollars = 0.15;
            double dollarInLeva = 1.76;
            double euro = 1.95;

            double bitCoinInEuro = bitCoinInLeva / euro * bitCoins;
            double chinesseJuanInLeva = chinesseJuanInDollars * dollarInLeva;
            double chinesseJuanInEuro = chinesseJuanInLeva / euro * chinesseMoney;

            double sum = ((bitCoinInEuro + chinesseJuanInEuro) / 100) * (100-comission);
            Console.WriteLine($"{sum:f2}");


        }
    }
}
