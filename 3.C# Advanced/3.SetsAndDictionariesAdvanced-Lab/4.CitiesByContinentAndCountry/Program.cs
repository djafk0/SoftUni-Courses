using System;
using System.Collections.Generic;

namespace _4.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dic = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (dic.ContainsKey(continent) == false)
                {
                    dic.Add(continent, new Dictionary<string, List<string>>());
                }

                if (dic[continent].ContainsKey(country) == false)
                {
                    dic[continent].Add(country, new List<string>());
                }

                dic[continent][country].Add(city);
            }

            foreach (var continent in dic)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
