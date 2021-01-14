using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    abstract class Shape 
    {
        abstract public double Area { get; }

        virtual public void Print()
        {
            Console.WriteLine($"Figure: {this.GetType().Name,-20} \t\t Area: { Area}");
        }
    }
}
