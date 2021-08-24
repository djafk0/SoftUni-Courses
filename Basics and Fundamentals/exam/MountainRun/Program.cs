using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsPerOneMeter = double.Parse(Console.ReadLine());

            double secondsNeeded = distance * secondsPerOneMeter;
            double secondsWithDelay = Math.Floor(distance / 50);
            double second = secondsWithDelay * 30;

            double seconds = secondsNeeded + second;

            double diff = Math.Abs(record - seconds);

            if (seconds < record) Console.WriteLine($"Yes! The new record is {seconds:f2} seconds.");

            else Console.WriteLine($"No! He was {diff:f2} seconds slower.");
        }
    }
}
