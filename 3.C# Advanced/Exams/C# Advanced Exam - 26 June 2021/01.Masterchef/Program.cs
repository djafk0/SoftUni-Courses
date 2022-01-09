using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Mastercheff
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(150, 0);
            dic.Add(250, 0);
            dic.Add(300, 0);
            dic.Add(400, 0);

            int[] ingredientsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] freshnessInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);

            while (freshness.Count != 0 && ingredients.Count != 0)
            {
                if (dic.ContainsKey(ingredients.Peek() * freshness.Peek()))
                {
                    dic[ingredients.Peek() * freshness.Peek()] += 1;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            int counter = 0;

            Dictionary<string, int> resultDic = new Dictionary<string, int>();

            foreach (var item in dic)
            {
                if (item.Value != 0)
                {
                    counter++;
                }

                if (item.Key == 150)
                {
                    resultDic.Add("Dipping sauce", item.Value);
                }
                else if (item.Key == 250)
                {
                    resultDic.Add("Green salad", item.Value);
                }
                else if (item.Key == 300)
                {
                    resultDic.Add("Chocolate cake", item.Value);
                }
                else if (item.Key == 400)
                {
                    resultDic.Add("Lobster", item.Value);
                }
            }

            if (counter == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");


                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }

                foreach (var item in resultDic.OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");

                }

                foreach (var item in resultDic.OrderBy(x => x.Key))
                {
                    if (item.Value != 0)
                    {
                        Console.WriteLine($" # {item.Key} --> {item.Value}");
                    }
                }
            }

        }
    }
}
