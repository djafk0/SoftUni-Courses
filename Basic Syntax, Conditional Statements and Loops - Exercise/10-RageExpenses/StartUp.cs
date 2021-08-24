using System;

namespace _10_RageExpenses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double monitorPrice = double.Parse(Console.ReadLine());
            int headset = 0;
            int mouse = 0;
            int keyboard = 0;
            int monitor = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headset++;
                }
                if (i % 3 == 0)
                {
                    mouse++;
                }
                if (i % 6 == 0)
                {
                    keyboard++;
                }
                if (i % 12 == 0)
                {
                    monitor++;
                }
            }
            double rageCost = headset * headsetPrice + mouse * mousePrice + keyboard * keyboardPrice + monitor * monitorPrice;
            Console.WriteLine($"Rage expenses: {rageCost:f2} lv.");
        }
    }
}
