using System;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            const double doubleConverter = 1.0;
            int n = int.Parse(Console.ReadLine());
            int sep2 = 0;
            int sep3 = 0;
            int sep4 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 ==0)
                {
                    sep2++;
                }
                if (num % 3 == 0)
                {
                    sep3++;
                }
                if (num % 4 == 0)
                {
                    sep4++;
                }
            }
            double sepp2 = doubleConverter * sep2 * 100 / n;
            double sepp3 = doubleConverter * sep3 * 100 / n;
            double sepp4 = doubleConverter * sep4 * 100 / n;
            Console.WriteLine($"{sepp2:f2}%");
            Console.WriteLine($"{sepp3:f2}%");
            Console.WriteLine($"{sepp4:f2}%");
        }
    }
}
