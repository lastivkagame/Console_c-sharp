using System;

namespace task_2.Classes_Car
{
    class BusCar : Car
    {
        public BusCar() : base(0, "Bus Car", "Racer " + count, 100) { }

        public override void Go(Car car)
        {
            Console.WriteLine(Name + " go");
            Speed = car.Speed;
        }
    }
}
