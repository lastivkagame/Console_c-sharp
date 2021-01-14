using task_1.interfaces;

namespace task_1.Classes
{
    public enum TypeBasement
    {
        Tape,
        Precast,
        Columnar,
        Solid,
        Welded
    }
    class Basement : IPart
    {
        double myreadypercent;
        private TypeBasement typebasement;

        public TypeBasement Typebasement
        {
            get { return typebasement; }
            set { typebasement = value; }
        }

        public Basement(TypeBasement typebasement)
        {
            myreadypercent = 0;
            Typebasement = typebasement;

        }

        public double MyPercentPlus 
        {
            get { return myreadypercent; }
        }

        public object GetName()
        {
            return "Basement";
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