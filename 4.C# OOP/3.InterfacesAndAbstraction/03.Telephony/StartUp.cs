using System;
using System.Linq;

namespace _3.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            string[] urls = Console.ReadLine().Split(' ');

            foreach (var number in numbers)
            {
                if (!number.All(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                ICallable callable = null;

                if (number.Length == 7)
                {
                    callable = new StationaryPhone();
                }
                else if (number.Length == 10)
                {
                    callable = new Smartphone();
                }

                callable.Call(number);
            }

            foreach (var url in urls)
            {
                if (url.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                IBrowsable browsable = new Smartphone();
                browsable.Browsing(url);
            }
            
        }
    }
}
