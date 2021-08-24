using System;

namespace _2.__Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string word1 = input[0];
            string word2 = input[1];
            int sum = 0;
            int totalSum = 0;
            int i = 0;
            for (i = 0; i < Math.Min(word2.Length, word1.Length); i++)
            {
                char bla = word1[i];
                char blaa = word2[i];
                sum = bla * blaa;
                totalSum += sum;
            }
            if (word1.Length > word2.Length)
            {
                for (int j = i; j < word1.Length; j++)
                {
                    char bla = word1[j];
                    totalSum += bla;
                }
            }
            else if (word1.Length < word2.Length)
            {
                for (int j = i; j < word2.Length; j++)
                {
                    char blaa = word2[j];
                    totalSum += blaa;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
