using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine();
            int cows = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            double Premiere = 12;
            double Normal = 7.5;
            double Discount = 5;


            if (typeOfProjection == "Premiere")
            {
                double finalMoney = cows * rows * Premiere;

                Console.WriteLine($"{finalMoney:f2} leva");
            }
            else if (typeOfProjection == "Normal")
            {
                double finalMoney = cows * rows * Normal;

                Console.WriteLine($"{finalMoney:f2} leva");
            }
            else if (typeOfProjection == "Discount")
            {
                double finalMoney = cows * rows * Discount;

                Console.WriteLine($"{finalMoney:f2} leva");
            }
        }
    }
}
