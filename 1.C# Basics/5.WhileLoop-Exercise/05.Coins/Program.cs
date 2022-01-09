using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal input = decimal.Parse(Console.ReadLine());
            double coins = 0;

            while (input != 0)
            {
                if (input >= 2)
                {
                    input -= 2;
                }
                else if (input >= 1)
                {
                    input -= 1;
                }
                else if (input >= 0.5m)
                {
                    input -= 0.5m;
                }
                else if (input >= 0.2m)
                {
                    input -= 0.2m;
                }
                else if (input >= 0.1m)
                {
                    input -= 0.1m;
                }
                else if (input >= 0.05m)
                {
                    input -= 0.05m;
                }
                else if (input >= 0.02m)
                {
                    input -= 0.02m;
                }
                else if (input >= 0.01m)
                {
                    input -= 0.01m;
                }
            
                coins++;
            }

            Console.WriteLine(coins);
        }
    }
}
