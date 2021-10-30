using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzle = 2.6;
            const double talkingDoll = 3;
            const double bear = 4.1;
            const double minion = 8.2;
            const double truck = 2;

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double percent = 1;

            if (puzzles + talkingDolls + bears + minions + trucks >= 50)
            {
                percent = 0.75;
            }

            double result = (puzzles * puzzle + talkingDolls * talkingDoll + bears * bear + minions * minion + trucks * truck) * percent * 0.9;

            if (result >= tripPrice)
            {
                Console.WriteLine($"Yes! {result - tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice - result:f2} lv needed.");
            }
        }
    }
}
