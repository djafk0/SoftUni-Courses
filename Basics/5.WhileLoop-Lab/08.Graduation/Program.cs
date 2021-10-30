using System;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double currentYear = 1;
            double gradeTotal = 0;
            double currentGrade = 0;
            double counter4 = 1;

            while (currentYear <= 12)
            {
                currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4)
                {
                    currentYear++;
                }

                else if (currentGrade < 4)
                {
                    if (counter4 >= 2)
                    {

                        Console.WriteLine($"{name} has been excluded at {currentYear} grade");
                        break;
                    }


                    counter4++;
                }

                gradeTotal += currentGrade;

            }


            gradeTotal = gradeTotal / 12;

            if (gradeTotal >= 4.00 && counter4 < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {gradeTotal:F2}");
            }
        }
    }
}
