using System;

namespace _06.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double academiPoints = double.Parse(Console.ReadLine());
            int broiOceniteli = int.Parse(Console.ReadLine());

            double sumPoints = academiPoints;
            bool flag = false;

            for (int i = 0; i < broiOceniteli; i++)
            {
                string nameJury = Console.ReadLine();
                double pointsJury = double.Parse(Console.ReadLine());
                double momentPoints = (nameJury.Length * pointsJury) / 2;
                sumPoints = sumPoints + momentPoints;
                if (sumPoints >= 1250.5)
                {
                    flag = true;
                    break;
                }



            }
            if (flag)
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {sumPoints:F1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - sumPoints:F1} more!");
            }
        }
    }
}
