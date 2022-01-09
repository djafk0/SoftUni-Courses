using System;

namespace _07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            const double chickenMenuPrice = 10.35;
            const double fishMenuPrice = 12.4;
            const double vegetarianMenuPrice = 8.15;

            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegetarianMenus = int.Parse(Console.ReadLine());

            double result = (chickenMenus * chickenMenuPrice + fishMenus * fishMenuPrice + vegetarianMenus * vegetarianMenuPrice) * 1.2 + 2.5;

            Console.WriteLine(result);

        }
    }
}
