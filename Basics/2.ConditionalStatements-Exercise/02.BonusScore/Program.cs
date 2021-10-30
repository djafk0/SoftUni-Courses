using System;

namespace _02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0;
            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number > 100 && number <= 1000)
            {
                bonus = number * 0.2;
            }
            else if (number > 1000)
            {
                bonus = number * 0.1;
            }

            double otherBonus = 0;

            if (number % 2 == 0)
            {
                otherBonus = 1;
            }
            else if (number % 10 == 5)
            {
                otherBonus = 2;
            }



            double bonuses = bonus + otherBonus;
            double final = number + bonus + otherBonus;
            Console.WriteLine(bonuses);
            Console.WriteLine(final);
        }
    }
}
