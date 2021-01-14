using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialisation
{
    [Serializable]
    public class Car
    {
        private int speed;
        [XmlElement("Brand")]
        public string brand;
        [XmlElement("Model")]
        public string model;
        [XmlIgnore]
        public double weight;
        public Engine engine;

        public Car(int speed, string brand, string model, double weight, double power)
        {
            this.brand = brand;
            this.speed = speed;
            this.model = model;
            this.weight = weight;

            this.engine = new Engine { Power = power };
        }

        public Car() // необхідний для xml серіалізації
        {
            engine = new Engine(); 
        }

        public override string ToString()
        {
            return $" {brand} {model} {engine.Power}, max speed {speed} km/hour, weighr {weight} ";
        }
    }

    [Serializable]
    public class Engine
    {
        [XmlAttribute]
        public double Power { get; set; }

        public Engine() // необхідний для xml серіалізації
        {
            Power = 1.2;
        }
    }
}
