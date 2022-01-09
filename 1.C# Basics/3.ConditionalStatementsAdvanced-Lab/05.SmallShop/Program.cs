using System;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (product == "coffee" && city == "Sofia")
            {
                double priceForCoffee = 0.50;
                Console.WriteLine(priceForCoffee * quantity);
            }
            else if (product == "coffee" && city == "Plovdiv")
            {
                double priceForCoffee = 0.40;
                Console.WriteLine(priceForCoffee * quantity);
            }
            else if (product == "coffee" && city == "Varna")
            {
                double priceForCoffee = 0.45;
                Console.WriteLine(priceForCoffee * quantity);
            }
            else if (product == "water" && city == "Sofia")
            {
                double priceForWater = 0.80;
                Console.WriteLine(priceForWater * quantity);
            }
            else if (product == "water" && (city == "Plovdiv" || city == "Varna"))
            {
                double priceForWater = 0.70;
                Console.WriteLine(priceForWater * quantity);
            }
            else if (product == "beer" && city == "Sofia")
            {
                double priceForBeer = 1.20;
                Console.WriteLine(priceForBeer * quantity);
            }
            else if (product == "beer" && city == "Plovdiv")
            {
                double priceForBeer = 1.15;
                Console.WriteLine(priceForBeer * quantity);
            }
            else if (product == "beer" && city == "Varna")
            {
                double priceForBeer = 1.10;
                Console.WriteLine(priceForBeer * quantity);
            }
            else if (product == "sweets" && city == "Sofia")
            {
                double priceForSweets = 1.45;
                Console.WriteLine(priceForSweets * quantity);
            }
            else if (product == "sweets" && city == "Plovdiv")
            {
                double priceForSweets = 1.30;
                Console.WriteLine(priceForSweets * quantity);
            }
            else if (product == "sweets" && city == "Varna")
            {
                double priceForSweets = 1.35;
                Console.WriteLine(priceForSweets * quantity);
            }
            else if (product == "peanuts" && city == "Sofia")
            {
                double priceForPeanuts = 1.60;
                Console.WriteLine(priceForPeanuts * quantity);
            }
            else if (product == "peanuts" && city == "Plovdiv")
            {
                double priceForPeanuts = 1.50;
                Console.WriteLine(priceForPeanuts * quantity);
            }
            else if (product == "peanuts" && city == "Varna")
            {
                double priceForPeanuts = 1.55;
                Console.WriteLine(priceForPeanuts * quantity);
            }
        }
    }
}
