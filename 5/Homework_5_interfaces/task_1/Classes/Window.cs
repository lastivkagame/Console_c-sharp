using task_1.interfaces;

namespace task_1.Classes
{
    enum TypeWindow
    {
        Cross,
        Eyebrow,
        Fixed,
        SingleHungSash,
        DoubleHungSash,
        FoldUp,
        Casement,
        Pivot,
        Hopper,
    }
    class Window : IPart
    {
        double myreadypercent;
        private TypeWindow typewindow;

        public TypeWindow Typewindow
        {
            get { return typewindow; }
            set { typewindow = value; }
        }

        public Window(TypeWindow typewindow)
        {
            myreadypercent = 0;
            Typewindow = typewindow;
        }

        public double MyPercentPlus
        {
            get { return myreadypercent; }
        }

        public object GetName()
        {
            return "Windows";
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
