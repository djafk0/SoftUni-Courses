using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int longestSequence = 1;
            int currentSequence = 1;
            int longestSequenceNumber = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    currentSequence++;
                    if (longestSequence < currentSequence)
                    {
                        longestSequence = currentSequence;
                        longestSequenceNumber = input[i];
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write(longestSequenceNumber + " ");
            }
           
        }
    }
}
