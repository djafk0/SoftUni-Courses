using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecondsForOneMeter = double.Parse(Console.ReadLine());

            double haveToSwim = distanceInMeters * timeInSecondsForOneMeter;

            double plus = Math.Floor(distanceInMeters / 15) * 12.5;
            double totalTime = haveToSwim + plus;

            if (recordInSeconds <= totalTime)
            {
                double timeNeeded = (totalTime - recordInSeconds);
                Console.WriteLine($"No, he failed! He was {timeNeeded:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
        }
    }
}
