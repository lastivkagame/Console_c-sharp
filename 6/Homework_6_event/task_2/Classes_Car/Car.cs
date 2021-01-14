namespace task_2.Classes_Car
{
    abstract class Car
    {
        private double speed;
        private string name;
        private string owner;
        private double maxSpeed;
        private double distamce;
        private bool isready;

        public bool IsReady
        {
            get { return isready; }
            set
            {
                isready = value;

                if (isready == true)
                {
                    start?.Invoke(this);
                }
            }
        }

        public double Distance
        {
            get { return distamce; }
            set
            {
                if (distamce == 0 && value > 0)
                {
                    go?.Invoke(this);
                }

                if (value >= 0)
                {
                    distamce = value;
                }
            }
        }

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0)
                {
                    maxSpeed = value;
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Speed
        {
            get { return speed; }
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
            }
        }

        abstract public void Go(Car car);

        public delegate void GoDeleg(Car car);
        public event GoDeleg go; //викликаю для показу початку руху машини(у відповідб на зміну пройденої відстані)

        public delegate void IsOnStart(Car car);
        public event IsOnStart start;  //подія викликаю якщо машна на старті(true) на старті

        public static int count; // лічильник я використову його щоб власники були різні( по номерам)

        static Car()
        {
            count = 0;
        }

        public Car(double speed = 1, string name = "none", string owner = "none", double maxSpeed = 1)
        {
            count++;
            Speed = speed;
            Name = name;
            Owner = owner;
            MaxSpeed = maxSpeed;
            Distance = 0;
            IsReady = false;
        }

        public override string ToString()
        {
            return $" Name: {Name,-15} NowSpeed: {Speed,-5} Owner: {Owner,-10} MaxSpeed: {MaxSpeed,-7} PassedDistance: {Distance}";
        }
    }
}
