using System;

namespace _09_Padawan_Equipment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalPrice = priceOfBelts * (countOfStudents - (countOfStudents / 6)) +
                (priceOfLightsabers * Math.Ceiling(countOfStudents * 1.1)) +
                countOfStudents  * priceOfRobes;

            if (amountOfMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - amountOfMoney:f2}lv more.");
            }
        }
    }
}
