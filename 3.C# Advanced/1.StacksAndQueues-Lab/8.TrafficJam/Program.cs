using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count <= 0)
                        {
                            break;
                        }
                        counter++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }

                    input = Console.ReadLine();
                    continue;
                }

                cars.Enqueue(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
