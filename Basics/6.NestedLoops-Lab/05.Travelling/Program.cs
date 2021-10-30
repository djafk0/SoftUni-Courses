using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = 0;
            for (int i = 0; i <= input; i++)
            {
                input = 0;
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    return;
                }
                double moneyNeeded = double.Parse(Console.ReadLine());
                for (int j = 0; j <= input; j++)
                {
                    input += double.Parse(Console.ReadLine());
                    if (input >= moneyNeeded)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
            }
        }
    }
}
