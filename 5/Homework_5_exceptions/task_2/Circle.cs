using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Circle : Shape
    {
        const double PI = 3.14159;
        double radius;

        public Circle(double radius = 0)
        {
            if (radius >= 0)
            {
                this.radius = radius;
            }
            else
            {
                throw new Exception("Inccorect radius!");
            }
        }
        public override double Area
        {
            get
            {
                return PI * radius * radius;
            }
        }
    }
}
