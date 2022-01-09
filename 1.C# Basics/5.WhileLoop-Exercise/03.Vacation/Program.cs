using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyVacation = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());

            string typeAction = string.Empty;
            double sum = 0;
            int countDays = 0;
            int countSpendMoney = 0;

            while ((moneyAvailable < moneyVacation) && (countSpendMoney < 5))
            {
                countDays++;
                typeAction = Console.ReadLine();//spend or save
                sum = double.Parse(Console.ReadLine());

                if (typeAction == "spend")
                {
                    moneyAvailable -= sum;
                    if (moneyAvailable < 0)
                    {
                        moneyAvailable = 0;
                    }
                    countSpendMoney++;
                }

                if (countSpendMoney == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(countDays);
                    return;
                }
                else if (typeAction == "save")
                {
                    countSpendMoney = 0;
                    moneyAvailable += sum;
                }
            }

            if (moneyAvailable >= moneyVacation)
            {
                Console.WriteLine($"You saved the money for {countDays} days.");

            }
        }
    }
}
