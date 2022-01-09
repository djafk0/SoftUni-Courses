using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            string calculator = Console.ReadLine();

            double result = 0;
            string evenOrOdd = "";

            if (calculator == "+")
            {
                result = numberOne + numberTwo;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{numberOne} + {numberTwo} = {result} - {evenOrOdd}");
            }
            else if (calculator == "-")
            {
                result = numberOne - numberTwo;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{numberOne} - {numberTwo} = {result} - {evenOrOdd}");

            }
            else if (calculator == "*")
            {
                result = numberOne * numberTwo;
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{numberOne} * {numberTwo} = {result} - {evenOrOdd}");

            }
            else if (calculator == "/")
            {
                result = numberOne / numberTwo;
                if (numberTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {numberOne} by zero");
                }
                else
                {
                    Console.WriteLine($"{numberOne} / {numberTwo} = {result:f2}");
                }
            }
            else if (calculator == "%")
            {
                result = numberOne % numberTwo;
                if (numberTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {numberOne} by zero");
                }
                else
                {
                    Console.WriteLine($"{numberOne} % {numberTwo} = {result}");
                }
            }
        }
    }
}
