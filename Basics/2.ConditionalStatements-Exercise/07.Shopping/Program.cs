using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            const double videoCard = 250;

            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double videoCardsPrice = videoCards * videoCard;
            double processorPrice = 0.35 * videoCardsPrice * processors;
            double ramPrice = ram * videoCardsPrice * 0.1;


            double percent = 1;

            if (videoCards > processors)
            {
                percent = 0.85;
            }

            double result = (videoCardsPrice + processorPrice + ramPrice) * percent;

            if (budget >= result)
            {
                Console.WriteLine($"You have {budget - result:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {result - budget:f2} leva more!");
            }
        }
    }
}
