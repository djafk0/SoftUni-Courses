using System;
using System.Collections.Generic;

namespace _3.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> dic = new SortedDictionary<string, Dictionary<string, double>>();

            string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Revision")
            {
                string market = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);

                if (dic.ContainsKey(market) == false)
                {
                    dic.Add(market, new Dictionary<string, double>());
                }

                if (dic[market].ContainsKey(product) == false)
                {
                    dic[market].Add(product, price);
                }

                command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var product in dic)
            {
                Console.WriteLine($"{product.Key}->");

                foreach (var price in product.Value)
                {
                    Console.WriteLine($"Product: {price.Key}, Price: {price.Value}");

                }
            }
        }
    }
}
