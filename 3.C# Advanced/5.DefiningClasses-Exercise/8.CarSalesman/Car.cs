using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; } = "n/a";
        public string Color { get; set; } = "n/a";
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public override string ToString()
        {
            return $"{Model}:\n  {Engine}\n  Weight: {Weight}\n  Color: {Color}";
        }
    }
}
