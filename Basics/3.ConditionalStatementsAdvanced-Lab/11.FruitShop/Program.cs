using System;

namespace _11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (fruit == "banana")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 2.5;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 2.7;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "apple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 1.2;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 1.25;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "orange")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 0.85;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 0.9;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "grapefruit")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 1.45;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 1.6;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "kiwi")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 2.7;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 3;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "pineapple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 5.5;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 5.6;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "grapes")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 3.85;
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 4.2;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            double result = quantity * price;
            if (result != 0)
            {
                Console.WriteLine($"{result:f2}");

            }
        }
    }
}
