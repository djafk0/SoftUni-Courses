using System;

namespace cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesPerOneWalking = int.Parse(Console.ReadLine());
            int countOfWalking = int.Parse(Console.ReadLine());
            int takenCalories = int.Parse(Console.ReadLine());

            int totalMinutes = minutesPerOneWalking * countOfWalking;
            int burnCalories = totalMinutes * 5;

            if (takenCalories / 2 <= burnCalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCalories}.");
            }
        }
    }
}
