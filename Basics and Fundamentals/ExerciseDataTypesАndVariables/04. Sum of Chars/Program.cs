using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int peopleFitInside = int.Parse(Console.ReadLine());
            if (people % peopleFitInside == 0)
            {
                Console.WriteLine(people / peopleFitInside);
            }
            else if (people <= peopleFitInside)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine($"{people / peopleFitInside + 1}");
            }
        }
    }
}
