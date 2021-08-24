using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int counter = input.Count;
            int location = 0;

            while (command[0] != "Love!")
            {
                location += int.Parse(command[1]);
                if (location >= input.Count)
                {
                    location = 0;
                    int savedNumber = input[0];
                    input.RemoveAt(0);
                    input.Insert(0, savedNumber - 2);
                }
                else
                {
                    int savedNumber = input[location];
                    input.RemoveAt(location);
                    input.Insert(location, savedNumber - 2);
                }

                if (input[location] == 0 || input[location] == -1)
                {
                    counter--;
                    Console.WriteLine($"Place {location} has Valentine's day.");
                }
                if (input[location] < -1)
                {
                    Console.WriteLine($"Place {location} already had Valentine's day.");
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine($"Cupid's last position was {location}.");

            if (counter == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
        }
    }
}
