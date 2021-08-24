using System;
using System.Text;

namespace _1._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                
                int firstIndex = input.IndexOf('@');
                int secondIndex = input.IndexOf('|');
                int thirdIndex = input.IndexOf('#');
                int fourthIndex = input.IndexOf('*');

                string name = input.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
                string age = input.Substring(thirdIndex + 1, fourthIndex - thirdIndex - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
