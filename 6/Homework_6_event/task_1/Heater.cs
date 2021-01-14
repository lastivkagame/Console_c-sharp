using System;

namespace task_1
{
    class Heater
    {
        public void Warm(Hothouse house)
        {
            house.Temperature += 5;
            Console.WriteLine("Heater start work. Temperature at hothouse is up on 5");
        }
    }
}
