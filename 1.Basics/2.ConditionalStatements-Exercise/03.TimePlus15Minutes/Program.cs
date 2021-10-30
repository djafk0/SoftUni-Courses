using System;

namespace _03.TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int time = 15;
            int plus = time + minutes;
            if (plus >= 60)
            {
                hours += 1;
                plus -= 60;
            }
            if (hours >= 24)
            {
                hours -= 24;
            }
            Console.WriteLine($"{hours}:{plus:d2}");
        }
    }
}
