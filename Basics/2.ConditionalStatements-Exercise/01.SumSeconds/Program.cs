using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsOne = int.Parse(Console.ReadLine());
            int secondsTwo = int.Parse(Console.ReadLine());
            int secondsThree = int.Parse(Console.ReadLine());

            int totalSeconds = secondsOne + secondsTwo + secondsThree;

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
