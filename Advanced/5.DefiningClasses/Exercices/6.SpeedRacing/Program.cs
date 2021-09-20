using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = inputData[0];
                
                int engineSpeed = int.Parse(inputData[1]);
                int enginePower = int.Parse(inputData[2]);
                Engine engine = new Engine();
                engine.EngineSpeed = engineSpeed;
                engine.EnginePower = enginePower;

                int cargoWeight = int.Parse(inputData[3]);
                string cargoType= inputData[4];
                Cargo cargo = new Cargo();
                cargo.CargoWeight = cargoWeight;
                cargo.CargoType = cargoType;

                double tireOnePressure = double.Parse(inputData[5]);
                int tireOneAge = int.Parse(inputData[6]);
                double tireTwoPressure = double.Parse(inputData[7]);
                int tireTwoAge = int.Parse(inputData[8]);
                double tireThreePressure = double.Parse(inputData[9]);
                int tireThreeAge = int.Parse(inputData[10]);
                double tireForthPressure = double.Parse(inputData[11]);
                int tireForthAge = int.Parse(inputData[12]);
                Tire tire = new Tire();
                tire.TireOnePressure = tireOnePressure;
                tire.TireOneAge = tireOneAge;
                tire.TireTwoPressure = tireTwoPressure;
                tire.TireTwoAge = tireTwoAge;
                tire.TireThreePressure = tireThreePressure;
                tire.TireThreeAge = tireThreeAge;
                tire.TireForthPressure = tireForthPressure;
                tire.TireForthAge = tireForthAge;

                Car car = new Car(model, engine,cargo,tire);
                cars.Add(car);
            }

            string searchingType = Console.ReadLine();

            foreach (Car searchedCar in cars)
            {
                if (searchedCar.Cargo.CargoType == searchingType && searchedCar.Tire.Contains(1))
                {
                    Console.WriteLine(searchedCar.Model);
                }
                else if (searchedCar.Cargo.CargoType == searchingType && searchedCar.Engine.EnginePower > 250)
                {
                    Console.WriteLine(searchedCar.Model);
                }
            }
        }
    }
}
