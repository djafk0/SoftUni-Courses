using System;
using System.Linq;
using System.Collections.Generic;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            string left = "";
            string right = "";
            while (command != "Lumpawaroo")
            {
                if (command.Contains('|'))
                {
                    string[] splitted = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    left = splitted[1];
                    if (right != splitted[1] && right != left)
                    {
                        right = splitted[1];
                    }
                    foreach (var item in users)
                    {
                        item.Value.Remove(splitted[1]);
                    }
                    if (!users.ContainsKey(splitted[0]))
                    {
                        users.Add(splitted[0], new List<string> { });
                    }
                    users[splitted[0]].Add(splitted[1]);

                }
                else if (command.Contains('>'))
                {
                    bool some = false;
                    string[] splitted = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    left = splitted[1];
                    if (right != splitted[1] && right != left)
                    {
                        right = splitted[1];
                    }
                    foreach (var item in users)
                    {
                        some = item.Value.Remove(splitted[0]);
                    }
                    if (!users.ContainsKey(splitted[1]))
                    {
                        users.Add(splitted[1], new List<string> { });
                    }
                    if (some)
                    {
                        foreach (var item in users)
                        {
                            item.Value.Remove(splitted[0]);
                        }
                        users[left].Add(splitted[0]);

                    }
                    else
                    {
                        users[splitted[1]].Add(splitted[0]);
                    }
                    Console.WriteLine($"{splitted[0]} joins the {splitted[1]} side!");
                }

                command = Console.ReadLine();
            }
            foreach (var item in users.OrderBy(x => x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    item.Value.Sort();
                    Console.WriteLine($"! {string.Join("\n! ", item.Value)}");
                }
            }
        }
    }
}
