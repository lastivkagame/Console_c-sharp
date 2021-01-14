using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializationDemo
{
    [Serializable]
    class Car
    {
        private int speed;
        private string brand;
        private string model;
        [NonSerialized]
        private double weight;
        private Engine engine;

        public Car(int speed, string brand, string model, double weight, double power)
        {
            this.brand = brand;
            this.speed = speed;
            this.model = model;
            this.weight = weight;

            this.engine = new Engine { Power = power };
        }

        public override string ToString()
        {
            return $" {brand} {model} {engine.Power}, max speed {speed} km/hour, weighr {weight} ";
        }
    }

    [Serializable]
    class Engine
    {
        public double Power { get; set; }
    }
}
