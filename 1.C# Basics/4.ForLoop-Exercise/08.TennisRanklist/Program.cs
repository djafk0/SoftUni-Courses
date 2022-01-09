using System;

namespace _08.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int startingPoint = int.Parse(Console.ReadLine());
            string stage = string.Empty;
            int points = 0;
            double average = 0;
            double percent = 0;
            int numberOfWonTournaments = 0;

            points = startingPoint;

            for (int i = 0; i < numberOfTournaments; i++)
            {
                stage = Console.ReadLine();

                if (stage == "F")
                {
                    points += 1200;
                }
                else if (stage == "W")
                {
                    points += 2000;
                    numberOfWonTournaments++;
                }
                else if (stage == "SF")
                {
                    points += 720;
                }
            }
            average = (points - startingPoint) / numberOfTournaments;
            percent = ((double)numberOfWonTournaments / numberOfTournaments) * 100;

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}
