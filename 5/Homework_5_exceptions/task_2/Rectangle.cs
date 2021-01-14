using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Rectangle : Shape
    {
        double height;
        double width;

        public Rectangle(double height = 0, double width = 0)
        {
            if (height >= 0 && width >= 0)
            {
                this.height = height;
                this.width = width;
            }
            else
            {
                throw new Exception("Inccorect height or width!");
            }
        }
        public override double Area
        {
            get
            {
                return height * width;
            }
        }
    }
}
