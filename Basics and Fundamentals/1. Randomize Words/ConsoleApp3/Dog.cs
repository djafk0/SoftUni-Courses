using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Randomize_Words
{
    class Dog
    {
        public Dog(string name, string breed, int age, int weight, double height)
        {
            Name = name;
            Breed = breed;
            Age = age;
            Weight = weight;
            Height = height;
        }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hey from dog!");
            Console.WriteLine($"My name is: {Name}");
            Console.WriteLine($"I am {Breed}.");
            Console.WriteLine($"I am {Age} years old.");
            Console.WriteLine($"My weight is: {Weight}kgs.");
            Console.WriteLine($"My height is: {Height}m.");
            Console.WriteLine("Bye!");
        }

    }
}
