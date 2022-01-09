using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int halfOfN = n / 2;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int counter = 0;
            while (n >= m)
            {
                n -= m;
                counter++;
                if (y > 0 && halfOfN == n)
                {
                    n /= y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
