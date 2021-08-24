using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = "\\+359(-| )2\\1[0-9]{3}\\1[0-9]{4}\\b";

            var phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, regex);

           

            Console.WriteLine(string.Join(", ", phoneMatches));
        }
    }
}
