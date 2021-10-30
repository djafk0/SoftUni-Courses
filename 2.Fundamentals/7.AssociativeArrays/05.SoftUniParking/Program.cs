using System;
using System.Collections.Generic;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "register")
                {
                    if (!cars.ContainsKey(command[1]))
                    {
                        cars.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {cars[command[1]]}");
                    }
                }
                else
                {
                    if (!cars.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                        continue;
                    }
                    cars.Remove(command[1]);
                    Console.WriteLine($"{command[1]} unregistered successfully");
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
