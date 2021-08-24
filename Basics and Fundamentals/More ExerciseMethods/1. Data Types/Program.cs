using System;

namespace _1._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();
            DataType(type, input);
        }

        private static void DataType(string type, string input)
        {
            if (type == "int")
            {
                int result = int.Parse(input) * 2;
                Console.WriteLine(result);
            }
            else if (type == "real")
            {
                double result = double.Parse(input) * 1.5;
                Console.WriteLine($"{result:f2}");
            }
            else if (type == "string")
            {
                string result = $"${input}$";
                Console.WriteLine(result);
            }
        }
    }
}
