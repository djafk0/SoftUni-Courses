using System;

namespace _07_Vending_Machine
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double sum = 0;
            double inputMoney = 0;
            
            
            while (command != "Start")
            {
                inputMoney = double.Parse(command);

                if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                {
                    sum += inputMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputMoney}");
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            double productPrice = 0;
            while (command != "End")
            {
                if (command == "Nuts")
                {
                    productPrice = 2;
                }
                else if (command == "Water")
                {
                    productPrice = 0.7;
                }
                else if (command == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (command == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (command == "Coke")
                {
                    productPrice = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    command = Console.ReadLine();
                    continue;
                }


                if (sum >= productPrice)
                {
                    sum -= productPrice;
                    Console.WriteLine($"Purchased {command.ToLower()}");
                }
                
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                command = (Console.ReadLine());

            }
            
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
