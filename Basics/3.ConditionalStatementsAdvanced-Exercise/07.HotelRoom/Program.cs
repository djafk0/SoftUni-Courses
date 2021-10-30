using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());

            double priceForStudio = 1;
            double priceForApartement = 1;
            double discount = 1;

            if (month == "May" || month == "October")
            {
                priceForStudio = 50;
                priceForApartement = 65;
                if (days > 7 && days <= 14)
                {
                    discount = 0.95;
                }
                else if (days > 14)
                {
                    discount = 0.7;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceForStudio = 75.2;
                priceForApartement = 68.7;
                if (days > 14)
                {
                    discount = 0.8;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceForStudio = 76;
                priceForApartement = 77;
            }
            if (days > 14)
            {
                double apartement = priceForApartement * days * 0.9;
                Console.WriteLine($"Apartment: {apartement:f2} lv.");
            }
            else
            {
                double apartement = priceForApartement * days;
                Console.WriteLine($"Apartment: {apartement:f2} lv.");
            }
            double studio = priceForStudio * days * discount;
            Console.WriteLine($"Studio: {studio:f2} lv.");
        }
    }
}
