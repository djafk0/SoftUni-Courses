using System;

namespace _09.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDay = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();
            int night = countDay - 1;
            double pricePerDay = 0.0;

            if (roomType == "room for one person")
            {
                pricePerDay = night * 18.00;
            }
            else if (roomType == "apartment")
            {
                pricePerDay = night * 25.00;
                if (countDay > 15)
                {
                    pricePerDay *= 0.50;
                }
                else if (countDay >= 10 && countDay <= 15)
                {
                    pricePerDay *= 0.65;
                }
                else
                {
                    pricePerDay *= 0.70;
                }
            }
            else if (roomType == "president apartment")
            {
                pricePerDay = night * 35.00;
                if (countDay > 15)
                {
                    pricePerDay *= 0.80;
                }
                else if (countDay >= 10 && countDay <= 15)
                {
                    pricePerDay *= 0.85;
                }
                else
                {
                    pricePerDay *= 0.90;
                }
            }

            if (rating == "positive")
            {
                pricePerDay *= 1.25;
            }
            else if (rating == "negative")
            {
                pricePerDay *= 0.90;
            }
            Console.WriteLine($"{pricePerDay:f2}");
        }
    }
}
