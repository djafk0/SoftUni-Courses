using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" -> ");

            while (command[0] != "End")
            {
                if (!users.ContainsKey(command[0]))
                {
                    users.Add(command[0], new List<string> { });
                }
                if (!users[command[0]].Contains(command[1]))
                {
                    users[command[0]].Add(command[1]);
                }

                command = Console.ReadLine().Split(" -> ");
            }
            foreach (var item in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"-- {string.Join("\n-- ", item.Value)}");
            }
        }
    }
}
