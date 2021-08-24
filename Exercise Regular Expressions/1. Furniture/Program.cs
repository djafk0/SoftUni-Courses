using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = ">>(?<product>[a-zA-Z]+)<<(?<price>.*)!(?<quantity>[0-9]+)";
            Regex regex = new Regex(pattern);
            List<string> products = new List<string>();
            List<double> prices = new List<double>();
            List<int> quantities = new List<int>();
            double sum = 0;
            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    int productIndex1 = input.LastIndexOf(">>");
                    int productIndex2 = input.IndexOf("<<");
                    string product = input.Substring(productIndex1 + 2, productIndex2 - productIndex1 - 2);
                    products.Add(product);
                    int priceIndex = input.IndexOf('!');
                    double price = double.Parse(input.Substring(productIndex2 + 2, priceIndex - productIndex2 - 2));
                    prices.Add(price);
                    int quantity = int.Parse(input.Substring(priceIndex + 1));
                    quantities.Add(quantity);
                }
                
                    input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
                sum += prices[i] * quantities[i];
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
