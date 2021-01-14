using Indexator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator.Classes
{
    class Student: Person, ICanWork
    {
        private int age;
        //private string name;

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Student() : this("None", 0)
        {

        }

        new public void DoWork()
        {
            Console.WriteLine("I'm Student {0}, Stupendia  - {1} ", Name, Salary);
        }

        public Student(string name, int age) : base(name, "learn", "student", 900)
        {
            //Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name {Name} === > {Age} y.o";
        }
    }
}
