using _Randomize_Words;
using System;
using System.Collections.Generic;

namespace _1.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Mira", "Breton Shpanyol", 1, 15, 0.4);
            Dog dog2 = new Dog("Gord", "Cane Corso", 4, 50, 0.6);
            
            dog.SayHi();
            dog2.SayHi();
            
        }
    }
}
