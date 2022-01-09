using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browsing(string url)
        {
            Console.WriteLine($"Browsing: {url}!");

        }
    }
}
