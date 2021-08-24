using System;

namespace small
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    price = 0.50;
                }
                else if (city == "Plovdiv")
                {
                    price = 0.4;
                }
                else if (city == "Varna")
                {
                    price = 0.45;
                }
            }
            if (product == "water")
            {
                if (city == "Sofia")
                {
                    price = 0.80;
                }
                else if (city == "Plovdiv" || city == "Varna")
                {
                    price = 0.7;
                }
            }
            if (product == "beer")
            {
                if (city == "Sofia")
                {
                    price = 1.2;
                }
                else if (city == "Plovdiv")
                {
                    price = 1.15;
                }
                else if (city == "Varna")
                {
                    price = 1.1;
                }
            }
            if (product == "sweets")
            {
                if (city == "Sofia")
                {
                    price = 1.45;
                }
                else if (city == "Plovdiv")
                {
                    price = 1.3;
                }
                else if (city == "Varna")
                {
                    price = 1.35;
                }
            }
            if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    price = 1.60;
                }
                else if (city == "Plovdiv")
                {
                    price = 1.5;
                }
                else if (city == "Varna")
                {
                    price = 1.55;
                }
            }
            decimal finalResult = (decimal) (price * quantity);
            Console.WriteLine(finalResult);
        }
    }
}
