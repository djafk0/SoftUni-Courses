using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {
                if (!courses.ContainsKey(command[0]))
                {
                    courses.Add(command[0], new List<string> { });
                }
                courses[command[0]].Add(command[1]);

                command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.Sort();
                Console.WriteLine($"-- {string.Join("\n-- ", item.Value)}");
            }
        }
    }
}
