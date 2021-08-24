
using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            string area = Console.ReadLine();

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}
