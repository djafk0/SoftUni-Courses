using System;

namespace _04.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lillysAge = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());
            double birthdayMoney = 0;
            int toysCounter = 0;
            double finalmoney = 0;

            for (int i = 1; i <= lillysAge; i++)
            {
                if (i % 2 != 0)
                {
                    toysCounter += 1;
                }
                else if (i % 2 == 0)
                {
                    int money = (i / 2) * 10;
                    birthdayMoney += money;
                }
            }

            finalmoney = birthdayMoney + (toysCounter * toysPrice) - (lillysAge - toysCounter);

            if (washingMachinePrice <= finalmoney)
            {
                double moneyLeft = finalmoney - washingMachinePrice;
                Console.WriteLine($"Yes! {moneyLeft:F2}");
            }
            else
            {
                double moneyNeeded = washingMachinePrice - finalmoney;
                Console.WriteLine($"No! {moneyNeeded:F2}");
            }
        }
    }
}
