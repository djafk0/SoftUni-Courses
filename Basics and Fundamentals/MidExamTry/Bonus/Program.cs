using System;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double countOfStudents = double.Parse(Console.ReadLine());
            double countOfLectures = double.Parse(Console.ReadLine());
            double initialBonus = double.Parse(Console.ReadLine());
            double blabla = 0;
            for (int i = 0; i < countOfStudents; i++)
            {
                int somethingLectures = int.Parse(Console.ReadLine());
                if (somethingLectures > blabla)
                {
                    blabla = somethingLectures;
                }
            }
            double totalBonus = Math.Ceiling((blabla / countOfLectures) * (5 + initialBonus));
            if (countOfStudents == 0 || countOfLectures == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
            }
            else
            {
            Console.WriteLine($"Max Bonus: {totalBonus}.");
            }
            Console.WriteLine($"The student has attended {blabla} lectures.");
        }
    }
}
