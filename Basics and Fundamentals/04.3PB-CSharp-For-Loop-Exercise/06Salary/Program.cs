using System;

namespace _06Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int facebook = 0;
            int instagram = 0;
            int reddit = 0;

            for (int i = 0; i < n; i++)
            {
                string nameOfTab = Console.ReadLine();
                if (nameOfTab == "Facebook")
                {
                    facebook += 150;
                }
                if (nameOfTab == "Instagram")
                {
                    instagram += 100;
                }
                if (nameOfTab == "Reddit")
                {
                    reddit += 50;
                }
            }
            int sum = facebook + instagram + reddit;
            if (salary <= sum)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - sum);
            }
        }
    }
}
