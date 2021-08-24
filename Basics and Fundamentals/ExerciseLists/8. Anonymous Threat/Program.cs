using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "3:1")
            {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);
                if (command[0] == "merge" && endIndex < data.Count)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        data.Add(data[i]);
                        data.RemoveAt(i);
                    }
                }


                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join("", data));
        }
    }
}
