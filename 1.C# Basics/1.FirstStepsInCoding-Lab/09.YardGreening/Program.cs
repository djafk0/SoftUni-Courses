using System;

namespace _09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMetersGreening = double.Parse(Console.ReadLine());

            const double greening = 7.61;
            double totalPriceForGreening = squareMetersGreening * greening;
            double finalPriceForGreening = totalPriceForGreening - totalPriceForGreening * 0.18;
            double discount = totalPriceForGreening - finalPriceForGreening;

            Console.WriteLine($"The final price is: {finalPriceForGreening:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}
