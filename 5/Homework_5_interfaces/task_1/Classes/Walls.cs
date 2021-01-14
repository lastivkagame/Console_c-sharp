using task_1.interfaces;

namespace task_1.Classes
{
    enum TypeWalls
    {
        PrecastConcrete,
        Retaining,
        Masonry,
        PrePanelizedLoadBearingMetalStud,
        EngineeringBrick,
        Stone,
    }
    class Walls : IPart
    {
        double myreadypercent;
        private TypeWalls typewalls;

        public TypeWalls Typewalls
        {
            get { return typewalls; }
            set { typewalls = value; }
        }

        public Walls(TypeWalls typewalls)
        {
            myreadypercent = 0;
            Typewalls = typewalls;
        }

        public double MyPercentPlus
        {
            get { return myreadypercent; }
        }

        public object GetName()
        {
            return "Walls";
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
