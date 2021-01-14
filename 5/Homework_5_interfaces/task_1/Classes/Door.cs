using task_1.interfaces;

namespace task_1.Classes
{
    enum TypeDoor
    {
        Glass,
        Metal,
        Wooden,
        Profile,
    }
    class Door : IPart
    {
        double myreadypercent;
        private TypeDoor typedoor;

        public TypeDoor Typedoor
        {
            get { return typedoor; }
            set { typedoor = value; }
        }

        public Door(TypeDoor typedoor)
        {
            myreadypercent = 0;
            Typedoor = typedoor;
        }

        public double MyPercentPlus
        {
            get { return myreadypercent; }
        }

        public object GetName()
        {
            return "Door";
        }

        public bool IsIReady()
        {
            if (myreadypercent == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddToMyPercent(double percent)
        {
            if (percent < 100 && percent + myreadypercent <= 100 && percent > 0)
            {
                myreadypercent += percent;
            }
            else if (percent < 100 && percent > 0)
            {
                myreadypercent = 100;
            }
        }
    }
}
