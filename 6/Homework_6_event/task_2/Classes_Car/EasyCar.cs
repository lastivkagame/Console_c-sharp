namespace task_2.Classes_Car
{
    class EasyCar : Car
    {
        public EasyCar() : base(0, "Easy Car", "Racer " + count, 200) { }

        public override void Go(Car car)
        {
            Speed = car.Speed;
        }
    }
}
