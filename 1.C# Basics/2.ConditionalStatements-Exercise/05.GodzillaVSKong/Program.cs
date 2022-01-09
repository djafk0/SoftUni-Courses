using System;

namespace _05.GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceForOutfit = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double discount = 0;

            if (statists > 150)
            {
                discount = 0.1 * priceForOutfit;
            }
            double priceWithDiscount = priceForOutfit - discount;

            double decorAndOutfit = decor + priceWithDiscount * statists;
            double moneyNeeded = Math.Abs(decorAndOutfit - budget);
            if (decorAndOutfit > budget)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {moneyNeeded:f2} leva left.");
            }
        }
    }
}
