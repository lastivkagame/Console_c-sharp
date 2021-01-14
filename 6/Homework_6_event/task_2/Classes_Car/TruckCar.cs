using System;

namespace task_2.Classes_Car
{
    class TruckCar : Car
    {
        public TruckCar() : base(0, "Truck Car", "Racer " + count, 300) { }

        public override void Go(Car car)
        {
            Console.WriteLine(Name + " go");
            Speed = car.Speed;
        }
    }
}
