using System;

namespace pipes_in_pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipeOne = int.Parse(Console.ReadLine());
            int pipeTwo = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double resultPipeOne = pipeOne * hours;
            double resultPipeTwo = pipeTwo * hours;
            double resultVolume = resultPipeOne + resultPipeTwo;

            double volumePercentage = resultVolume / volume * 100;
            double pipeOnePercentage = resultPipeOne / resultVolume * 100;
            double pipeTwoPercentage = resultPipeTwo / resultVolume * 100;

            if (resultVolume <= volume)
            {
                Console.WriteLine($"The pool is {volumePercentage:f2}% full. Pipe 1: {pipeOnePercentage:f2}%. Pipe 2: {pipeTwoPercentage:f2}%.");
            }
            else
            {
                double overflow = resultVolume - volume;
                Console.WriteLine($"For {hours} hours the pool overflows with {overflow} liters.");
            }
        }
    }
}
