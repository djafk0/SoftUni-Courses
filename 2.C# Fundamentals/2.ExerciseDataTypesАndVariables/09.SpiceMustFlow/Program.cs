using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int spice = int.Parse(Console.ReadLine());
            int currentSpice = spice, leavingSpice = spice;
            int days = 0, sum = 0;
            int dayConsume = 10, workersConsume = 26;
            while (currentSpice >= 100)
            {
                days++;
                leavingSpice -= workersConsume;
                sum += leavingSpice;
                currentSpice -= dayConsume;
                leavingSpice = currentSpice;
            }
            Console.WriteLine(days);
            if (days > 0)
            {
                sum -= 26;
            }
            Console.WriteLine(sum);
            
        }
    }
}
