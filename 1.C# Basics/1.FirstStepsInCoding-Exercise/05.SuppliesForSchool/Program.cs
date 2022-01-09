using System;

namespace _05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            const double penPacket = 5.8;
            const double markerPacket = 7.2;
            const double cleanerLitre = 1.2;

            int penPackets = int.Parse(Console.ReadLine());
            int markerPackets = int.Parse(Console.ReadLine());
            int cleanerLitres = int.Parse(Console.ReadLine());
            double decrease = double.Parse(Console.ReadLine());

            double result = (penPackets * penPacket + markerPackets * markerPacket + cleanerLitres * cleanerLitre) * ((100 - decrease) / 100);

            Console.WriteLine(result);
        }
    }
}
