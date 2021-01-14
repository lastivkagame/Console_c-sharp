using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage(3);
            garage[0] = new Car { Brand = "Audi", Model = "R8", Year = 2018 };
            garage[1] = new Car { Brand = "Toyota", Model = "Camry", Year = 2012 };
            garage[2] = new Car { Brand = "Mazda", Model = "6", Year = 2019 };

            foreach (Car item in garage)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            garage.Sort();

            Console.WriteLine("-After sort-");
            foreach (Car item in garage)
            {
                Console.WriteLine(item);
            }

            garage.Sort(new CompareCars());
            Console.WriteLine();
            Console.WriteLine();
            foreach (Car item in garage)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("After sort by model");
            garage.Sort(new CompareModel());
            Console.WriteLine();
            Console.WriteLine();
            foreach (Car item in garage)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Car car1 = new Car { Brand = "VW", Model = "Golf", Year = 2012, Owner = new Owner { Name = "Alex", Id = "12diki23" } };
            Car car2 = (Car)car1.Clone();
            car2.Year = 2014;
            car2.Owner.Id = "#tyuut";
            Console.WriteLine("car1: "+ car1);
            Console.WriteLine("car2: "+ car2);
        }
    }
}
