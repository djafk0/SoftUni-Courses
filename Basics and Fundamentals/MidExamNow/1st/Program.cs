using System;

namespace _1st
{
    class Program
    {
        static void Main(string[] args)
        {
            double biscuitsPerDay = double.Parse(Console.ReadLine());
            double countOfWorkers = double.Parse(Console.ReadLine());
            double otherFactory = double.Parse(Console.ReadLine());
            double myFactory = biscuitsPerDay * countOfWorkers * 20 + biscuitsPerDay * 0.75 * countOfWorkers * 10;
            if (myFactory > otherFactory)
            {
                double difference = myFactory - otherFactory;
                double percentage = difference / otherFactory * 100;
                Console.WriteLine($"You have produced {myFactory} biscuits for the past month.");
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                double difference = otherFactory - myFactory;
                double percentage = difference / otherFactory * 100;
                Console.WriteLine($"You have produced {myFactory} biscuits for the past month.");
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
