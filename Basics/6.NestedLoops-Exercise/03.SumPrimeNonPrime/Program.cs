using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().ToLower();
            int counter;
            int prime = 0;
            int nonPrime = 0;

            while (command != "stop")
            {
                int number = int.Parse(command);

                if (number < 0)
                {
                    Console.WriteLine($"Number is negative.");
                }
                else
                {
                    counter = 0;

                    for (int j = 1; j <= number; j++)
                    {
                        if (number % j == 0)
                        {
                            counter++;
                        }
                    }
                    if (counter == 2)
                    {
                        prime += number;
                    }
                    else
                    {
                        nonPrime += number;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {prime}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrime}");
        }
    }
}
