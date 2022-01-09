using System;

namespace _03_Vacation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int peopleGoing = int.Parse(Console.ReadLine());
            string typeOfTheGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;
            double discount = 1;

            if (typeOfTheGroup == "Students")
            {
                if (peopleGoing >= 30)
                {
                    discount *= 0.85;
                }
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.8;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if (typeOfTheGroup == "Business")
            {
                if (peopleGoing >= 100)
                {
                    peopleGoing -= 10;
                }

                if (dayOfWeek == "Friday")
                {
                    price = 10.9;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.6;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
            }
            else if (typeOfTheGroup == "Regular")
            {
                if (peopleGoing >= 10 && peopleGoing <= 20)
                {
                    discount = 0.95;
                }
                if (dayOfWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.5;
                }
            }
            double totalPrice = peopleGoing * price * discount;
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
