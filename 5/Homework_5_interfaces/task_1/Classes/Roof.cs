using task_1.interfaces;

namespace task_1.Classes
{
    enum TypeRoof
    {
        Gable,
        Hip,
        Dutch,
        Mansard,
        Flat,
        Shed,
        Butterfly,
        Gambrel,
        Dormer,
        M_Shaped,
    }
    class Roof : IPart
    {
        double myreadypercent;
        private TypeRoof typeroof;

        public TypeRoof Typeroof
        {
            get { return typeroof; }
            set { typeroof = value; }
        }

        public Roof(TypeRoof typeroof)
        {
            myreadypercent = 0;
            Typeroof = typeroof;
        }

        public double MyPercentPlus
        {
            get { return myreadypercent; }
        }

        public object GetName()
        {
            return "Roof";
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
