using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "buy")
            {
                string productName = input[0];
                double productPrice = double.Parse(input[1]);
                int productQty = int.Parse(input[2]);

                if (!products.ContainsKey(input[0]))
                {
                    products.Add(input[0], new double[2]);
                }

                double previousQty = products[productName][1];
                double[] priceQty = new double[] { productPrice, productQty + previousQty };
                products[productName] = priceQty;


                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in products)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
