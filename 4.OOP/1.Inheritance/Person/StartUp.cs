using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person child;

            if (age <= 15)
            {
                child = new Child(name, age);
            }
            else
            {
                child = new Person(name, age);
            }

            Console.WriteLine(child);
        }
    }
}