﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-z]+)<<(?<price>\d+\.?\d*)!(?<quant>\d+)";

            string input = Console.ReadLine();
            var items = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                MatchCollection matched = Regex.Matches(input, regex);
                foreach (Match m in matched)
                {
                    var name = m.Groups["name"].Value;
                    var price = double.Parse(m.Groups["price"].Value);
                    var quant = int.Parse(m.Groups["quant"].Value);
                    items.Add(name);
                    totalPrice += price * quant;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, items)}");
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
