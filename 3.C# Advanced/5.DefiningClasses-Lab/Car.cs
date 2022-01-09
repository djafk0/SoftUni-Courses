using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engines = engine;
            this.Tires = tires;
        }

        public string Make { get; set; } = "VW";
        public string Model { get; set; } = "Golf";
        public int Year { get; set; } = 2025;
        public double FuelQuantity { get; set; } = 200;
        public double FuelConsumption { get; set; } = 10;

        public Engine Engines { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) > 0)
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            string whoAmI = $"{this.Make}\n{this.Model}\n{this.Year}\n{this.FuelQuantity:f2}";
            return whoAmI;
        }
    }
}
