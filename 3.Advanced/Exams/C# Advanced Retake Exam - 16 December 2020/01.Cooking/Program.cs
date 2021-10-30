using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {

        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(25, 0);
            dic.Add(50, 0);
            dic.Add(75, 0);
            dic.Add(100, 0);

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                if (dic.ContainsKey((liquids.Peek() + ingredients.Peek())))
                {
                    dic[liquids.Dequeue() + ingredients.Pop()]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (dic.ContainsValue(0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Dictionary<string, int> resultDic = new Dictionary<string, int>()
            {
                { "Bread", dic.FirstOrDefault(x => x.Key == 25).Value },
                { "Cake", dic.FirstOrDefault(x => x.Key == 50).Value },
                { "Pastry", dic.FirstOrDefault(x => x.Key == 75).Value },
                { "Fruit Pie", dic.FirstOrDefault(x => x.Key == 100).Value }
            };

            foreach (var item in resultDic.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
