using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    partial class Animal
    {
        public void Print()
        {
            Console.WriteLine($" Name: {this.name};  Age: {age};" +  "Weight: {weight}");
        }
    }
}
