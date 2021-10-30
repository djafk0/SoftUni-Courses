using System;

namespace _06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            const double nylonPrice = 1.5;
            const double paintPrice = 14.5;
            const double paintThinnerPrice = 5;

            int nylonNeeded = int.Parse(Console.ReadLine());
            int paintNeeded = int.Parse(Console.ReadLine());
            int paintThinnerNeeded = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double materials = (nylonNeeded + 2) * nylonPrice + paintNeeded * 1.1 * paintPrice + paintThinnerNeeded * paintThinnerPrice + 0.4;
            double workers = materials * 0.3 * hours;
            double totalSum = materials + workers;

            Console.WriteLine(totalSum);
        }
    }
}
