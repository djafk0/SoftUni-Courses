using System;
using System.Collections.Generic;

namespace _5.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                dic.Add(input[0], int.Parse(input[1]));
            }

            string type = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string whatToPrint = Console.ReadLine();

            foreach (var item in dic)
            {
                if (whatToPrint == "name age")
                {
                    if (type == "younger" && age > item.Value)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                    else if (type == "older" && age <= item.Value)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
                else if (whatToPrint == "name")
                {
                    if (type == "younger" && age > item.Value)
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                    else if (type == "older" && age <= item.Value)
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                }
                else if (whatToPrint=="age")
                {
                    if (type == "younger" && age > item.Value)
                    {
                        Console.WriteLine($"{item.Value}");
                    }
                    else if (type == "older" && age <= item.Value)
                    {
                        Console.WriteLine($"{item.Value}");
                    }
                }
            }
        }
    }
}
