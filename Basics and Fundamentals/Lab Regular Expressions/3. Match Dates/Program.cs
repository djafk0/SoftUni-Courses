using System;
using System.Text.RegularExpressions;

namespace _3._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = "(?<day>[0-9]{2})(?<separator>\\.|\\-|\\/)(?<month>[A-Z][a-z]{2})\\k<separator>(?<year>[0-9]{4})";

            var input = Console.ReadLine();

            var matches = Regex.Matches(input, regex);

            foreach (Match item in matches)
            {
                Console.Write($"Day: {item.Groups["day"].Value},");
                Console.Write($" Month: {item.Groups["month"].Value},");
                Console.WriteLine($" Year: {item.Groups["year"].Value}");
            }
        }
    }
}
