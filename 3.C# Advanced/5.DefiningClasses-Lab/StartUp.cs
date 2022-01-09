using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[1] != "more")
            {
                int firstYear = int.Parse(command[0]);
                double firstPressure = double.Parse(command[1]);
                int secondYear = int.Parse(command[2]);
                double secondPressure = double.Parse(command[3]);
                int thirdYear = int.Parse(command[4]);
                double thirdPressure = double.Parse(command[5]);
                int forthYear = int.Parse(command[6]);
                double forthPressure = double.Parse(command[7]);

                Tire[] inputTire = new Tire[4]
                {
                        new Tire(firstYear,firstPressure),
                        new Tire(secondYear,secondPressure),
                        new Tire(thirdYear,thirdPressure),
                        new Tire(forthYear,forthPressure)
                };

                tires.Add(inputTire);
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[1] != "done")
            {
                int horsePower = int.Parse(command[0]);
                double cubicCapacity = double.Parse(command[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            int counter = 0;
            command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Show")
            {
                string make = command[0];
                string model = command[1];
                int year = int.Parse(command[2]);
                double fuelQuantity = double.Parse(command[3]);
                double fuelConsumption = double.Parse(command[4]);
                int engineIndex = int.Parse(command[5]);
                int tiresIndex = int.Parse(command[6]);
                Engine engine = engines[engineIndex];
                Tire[] tireSet = tires[tiresIndex];
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tireSet);
                double totalPressure = tireSet.Sum(t => t.Pressure);

                if (year >= 2017 && engines[counter].HorsePower > 330 && totalPressure > 9 && totalPressure < 10)
                {
                    cars.Add(car);
                }

                counter++;
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"Make: {item.Make}\nModel: {item.Model}\nYear: {item.Year}\nHorsePowers: {item.Engines.HorsePower}\nFuelQuantity: {item.FuelQuantity - 20 * item.FuelConsumption / 100}");
            }

        }
    }
}
