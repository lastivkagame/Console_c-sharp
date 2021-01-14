using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(350, "audi", "a8", 1700, 3.5);
            Console.WriteLine(car1);

            // Серіалізація - збереження стану об'єкта у файл

            //BinarySerialization(car1);

            //Десеріалізація об'єкта - відтворення стану об'єкта із файлу

            //Car car2 = BinaryDesearilisation();

            List<Car> cars = new List<Car>()
            {
                new Car(350, "audi", "a8", 1700, 3.5),
                new Car(270, "Mersedes", "ML", 2000, 2.5),
                new Car(250, "Honda", "CRV", 1500, 1.9),
                new Car(380, "Buggatti", "x", 2100, 5.0),
                new Car(220, "ford", "Mustang", 1400, 1.6),
             };

            //BinarySerialization(cars);
            cars.Clear();

            using (FileStream fs = new FileStream("car.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                cars = (List<Car>)bf.Deserialize(fs);
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }

        private static Car BinaryDesearilisation()
        {
            Car car2 = null;

            using (FileStream fs = new FileStream("car.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                car2 = (Car)bf.Deserialize(fs);
            }
            Console.WriteLine("Car 2: ");
            Console.WriteLine(car2);

            return car2;
        }

        private static void BinarySerialization(object obj)
        {
            using (FileStream fs = new FileStream("car.bin", FileMode.Create))
            {
                //Бінарна серіалізація точна(зберігаються як відкриті так і закриті поля)
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }
    }
}
