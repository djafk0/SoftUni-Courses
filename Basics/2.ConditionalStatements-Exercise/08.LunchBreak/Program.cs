using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double episodeLength = double.Parse(Console.ReadLine());
            double breakTime = double.Parse(Console.ReadLine());

            double lunch = breakTime * 1 / 8;
            double rest = breakTime * 1 / 4;
            double time = breakTime - lunch - rest;

            if (time >= episodeLength)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(time - episodeLength)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(episodeLength - time)} more minutes.");
            }
        }
    }
}
