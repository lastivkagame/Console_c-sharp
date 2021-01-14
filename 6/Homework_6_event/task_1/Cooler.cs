using System;

namespace task_1
{
    class Cooler
    {
        public void Cool(Hothouse house)
        {
            house.Temperature -= 5;
            Console.WriteLine("Cooler start work. Temperature at hothouse is low on 5");
        }
    }
}
