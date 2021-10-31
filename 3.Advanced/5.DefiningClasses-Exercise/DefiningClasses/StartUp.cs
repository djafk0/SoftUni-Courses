using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.DateBetweenTwoDatesInDays(firstDate, secondDate);
            Console.WriteLine($"{Math.Abs(days)}");
        }
    }
}
