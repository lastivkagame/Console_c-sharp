using System;

namespace task_2.Classes_Car
{
    class SportCar : Car
    {
        public SportCar() : base(0, "Sport Car", "Racer " + count, 500) { }

        public override void Go(Car car)
        {
            Console.WriteLine(Name + " go");
            Speed = car.Speed;
        }
    }
}
