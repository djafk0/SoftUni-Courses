using System;

namespace Problem_1._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counter = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                if (energy < distance || energy <= 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {energy} energy");
                    return;
                }
                counter++;
                energy -= distance;
                if (counter % 3 == 0)
                {
                    energy += counter;
                }
                command = Console.ReadLine();
            }
                Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
        }
    }
}
