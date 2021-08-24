using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengerCountOfEachWagon = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacityOfEachWagon = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    passengerCountOfEachWagon.Add(int.Parse(command[1]));
                }
                else if (int.Parse(command[0]) >= 0)
                {
                    //int moreThatMaxCapacity = 0;
                    for (int i = 0; i < passengerCountOfEachWagon.Count; i++)
                    {
                        if (int.Parse(command[0]) + passengerCountOfEachWagon[i] <= maxCapacityOfEachWagon)
                        {
                            passengerCountOfEachWagon[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            Console.WriteLine(string.Join(' ', passengerCountOfEachWagon));
        }
    }
}
