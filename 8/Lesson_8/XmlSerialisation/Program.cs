using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XmlSerialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car car1 = new Car(350, "Audi", "A8", 1700, 3.5);
            //Console.WriteLine(car1);

            //XmlSerializer xml = new XmlSerializer(car1.GetType());
            //xml.Serialize(new FileStream("xmlFile.xml", FileMode.Create), car1);


            //Car car2 = null;
            //XmlSerializer xml = new XmlSerializer(typeof(Car));
            //car2 = (Car)xml.Deserialize(new FileStream("xmlFile.xml", FileMode.Open));
            //Console.WriteLine(car2);

            List<Car> cars = new List<Car>()
            {
                new Car(350, "audi", "a8", 1700, 3.5),
                new Car(270, "Mersedes", "ML", 2000, 2.5),
                new Car(250, "Honda", "CRV", 1500, 1.9),
                new Car(380, "Buggatti", "x", 2100, 5.0),
                new Car(220, "ford", "Mustang", 1400, 1.6),
             };

            //XmlSerializer xml = new XmlSerializer(cars.GetType(), new[] { typeof(Engine) });
            //xml.Serialize(new FileStream("xmlFileCars.xml", FileMode.Create), cars);

            cars.Clear();

            XmlSerializer xml2 = new XmlSerializer(typeof(List<Car>), new[] { typeof(Engine) });
            cars = (List<Car>)xml2.Deserialize(new FileStream("xmlFileCars.xml", FileMode.Open));

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
