using System;

namespace scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarship = minimalSalary * 0.35;
            double scholarshipForExellentResults = average * 25;

            if (socialScholarship > scholarshipForExellentResults)
            {
                if (minimalSalary >= income && average >= 4.5)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
                else if (average >= 5.5)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarshipForExellentResults} BGN");
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            else
            {
                if (minimalSalary >= income && average >= 4.5)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
                else if (average >= 5.5)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarshipForExellentResults} BGN");
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            

        }
    }
}
