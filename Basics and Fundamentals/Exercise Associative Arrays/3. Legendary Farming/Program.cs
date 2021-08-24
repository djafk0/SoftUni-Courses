using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int> 
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 },
            };
            Dictionary<string, int> junks = new Dictionary<string, int>();
            bool isOdd = true;
            bool isFound = false;
            int currentValue = 0;
            while (!isFound)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < command.Length; i++)
                {
                    if (isOdd)
                    {
                        currentValue = int.Parse(command[i]);
                        isOdd = false;
                        continue;
                    }
                    else
                    {
                        command[i] = command[i].ToLower();
                        if (command[i] == "shards" ||
                            command[i] == "motes" ||
                            command[i] == "fragments")
                        {
                            legendaryItems[command[i]] += currentValue;
                        }
                        else
                        {
                            if (!junks.ContainsKey(command[i]))
                            {
                                junks.Add(command[i], 0);
                            }
                            junks[command[i]] += currentValue;
                            isOdd = true;
                            continue;
                        }
                        isOdd = true;
                    }
                    if (legendaryItems[command[i]] >= 250)
                    {
                        legendaryItems[command[i]] -= 250;
                        isFound = true;
                        if (command[i] == "shards")
                        {
                            Console.WriteLine($"Shadowmourne obtained!");
                        }
                        else if (command[i] == "fragments")
                        {
                            Console.WriteLine($"Valanyr obtained!");
                        }
                        else if (command[i] == "motes")
                        {
                            Console.WriteLine($"Dragonwrath obtained!");
                        }
                        break;
                    }
                }
            }
            foreach (var item in legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junks.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}