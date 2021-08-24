using System;

namespace _9._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            int result = firstValue.CompareTo(secondValue);
            if (result < 0)
            {
                Console.WriteLine(secondValue);
            }
            else 
            {
                Console.WriteLine(firstValue);
            }
        }
    }
}
