using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split(' ');
            string fullName = inputData[0] + " " + inputData[1];
            List<string> city = inputData.Skip(3).ToList();
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, inputData[2], string.Join(' ', city));

            inputData = Console.ReadLine().Split(' ');
            bool isDrunk = inputData[2] == "drunk";
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(inputData[0], int.Parse(inputData[1]), isDrunk);

            inputData = Console.ReadLine().Split(' ');
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(inputData[0], double.Parse(inputData[1]), inputData[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
