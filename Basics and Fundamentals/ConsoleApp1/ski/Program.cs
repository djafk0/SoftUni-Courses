using System;

namespace ski
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string review = Console.ReadLine();

            double discount = 0;
            double priceOfRoom = 0;
            double finalReview = 0;

            if (review == "positive")
            {
                finalReview = 1.25;
                if (days < 10)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.7;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.65;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.85;
                    }
                }
                else if (days > 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.5;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.8;
                    }
                }
            }
            else if (review == "negative")
            {
                finalReview = 0.9;
                if (days < 10)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.7;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.9;
                    }
                }
                else if (days <= 10 && days <= 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.65;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.85;
                    }
                }
                else if (days > 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        priceOfRoom = 18;

                        discount = 0;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        priceOfRoom = 25;

                        discount = 0.5;
                    }
                    else if (typeOfRoom == "president apartment")
                    {
                        priceOfRoom = 35;

                        discount = 0.8;
                    }
                }
            }

            //if (review == "positive")
            //{
            //    double finalReview = 1.25;
            //    double finalResult = (days - 1) * discount * finalReview;
            //    Console.WriteLine($"{finalResult:f2}");

            //}
            //else if (review == "negative")
            //{
            //    double finalReview = 0.9;
            if (discount != 0)
            {
                double finalResult = (days - 1) * priceOfRoom * discount * finalReview;
                Console.WriteLine($"{finalResult:f2}");
            }
            else
            {
                double finalResult = (days - 1) * priceOfRoom * finalReview;
                Console.WriteLine($"{finalResult:f2}");
            }

        }
    }
}
