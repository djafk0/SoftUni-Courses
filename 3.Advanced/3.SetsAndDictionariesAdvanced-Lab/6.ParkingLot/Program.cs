using System;
using System.Collections.Generic;

namespace _6.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    set.Add(input[1]);
                }
                else
                {
                    set.Remove(input[1]);
                }

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
