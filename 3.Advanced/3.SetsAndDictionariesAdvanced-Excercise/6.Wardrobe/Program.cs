using System;
using System.Collections.Generic;

namespace _6.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {

                    if (wardrobe[color].ContainsKey(cloth) == false)
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth] += 1;
                }
            }

            string[] searched = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searched[0];
            string searchedCloth = searched[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == searchedColor && cloth.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
