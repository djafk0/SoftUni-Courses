using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> input = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!input.ContainsKey(word))
                {
                input.Add(word, new List<string>());
                }
                input[word].Add(synonym);
            }
            foreach (var s in input)
            {
                Console.WriteLine($"{s.Key} - {string.Join(", ", s.Value)}");
            }
        }
    }
}
