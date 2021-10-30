using System;

namespace _08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());

            double shoes = 0.6 * tax;
            double equip = 0.8 * shoes;
            double ball = 0.25 * equip;
            double accessories = 0.2 * ball;

            double result = tax + shoes + equip + ball + accessories;

            Console.WriteLine(result);
        }
    }
}
