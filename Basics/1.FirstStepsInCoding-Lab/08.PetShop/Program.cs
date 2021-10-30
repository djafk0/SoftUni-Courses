using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogs = int.Parse(Console.ReadLine());
            int numberOfOtherDogs = int.Parse(Console.ReadLine());

            double priceOfDogFood = 2.50;
            double priceOfOtherFood = 4;

            double dogs = numberOfDogs * priceOfDogFood;
            double others = numberOfOtherDogs * priceOfOtherFood;

            double total = dogs + others;

            Console.WriteLine($"{total} lv.");
        }
    }
}
