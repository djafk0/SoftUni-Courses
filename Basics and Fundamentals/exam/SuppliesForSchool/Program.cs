using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pensCost = 5.8;
            const double markersCost = 7.2;
            const double cleanerCost = 1.2;

            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double cleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double totalPens = pens * pensCost;
            double totalMarkers = markers * markersCost;
            double totalCleaner = cleaner * cleanerCost;


            double totalProducts = totalCleaner + totalMarkers + totalPens;
            double totalDiscount = totalProducts * discount / 100;

            double total = totalProducts - totalDiscount;

            Console.WriteLine($"{total:f3}");
        }
    }
}
