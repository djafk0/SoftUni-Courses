using System;

namespace harvers
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMeters = int.Parse(Console.ReadLine());
            double perOneSquare = double.Parse(Console.ReadLine());
            int litersNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double totalGrape = perOneSquare * squareMeters;
            double wine = 0.4 * totalGrape / 2.5;
            if (wine >= litersNeeded)
            {
                double perWorker = (wine - litersNeeded) / workers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters." +
                    $"\n{Math.Ceiling(wine - litersNeeded)} liters left -> {Math.Ceiling(perWorker)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(litersNeeded - wine)} liters wine needed.");
            }
        }
    }
}
