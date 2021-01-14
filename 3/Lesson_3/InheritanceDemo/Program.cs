using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    abstract class AbstractPerson
    {
        abstract public string Name { get; set; }
        abstract public int Age { get; set; }
        abstract public void Busy(); //абстрактиний метод без реалізації

        protected int hours = 0;

        public void Print()
        {
            Console.WriteLine($"{Name} {this.GetType().Name}, \t {Age}\t{hours}");
        }
    }

    class Person: AbstractPerson
    {
        private int id_other = 1;
        protected int ID { get => id_other; set => id_other = value; }

        public override string Name { get; set; }
        public override int Age { get; set; }

        public Person(string name = "Empty", int age = 0)
        {
            Name = name ?? "Empty";
            Age = age;
            hours += 20; 
        }

        public override string ToString() => $"Name: {Name}, id: {id_other}";

        public override void Busy()
        {
            Console.WriteLine("Somthing doing ... ");
        }
    }

    class Employee : Person
    {
        public string Position { get; set; }
        public Employee(string name = "Empty", string position = "Unknown position", int age = 0) : base(name, age)
        {
            Position = position ?? "Unknown";
            //id_other = 2;
            ID = 2;
            Age = age;
            hours = 40;
        }

        public override string ToString()
        {
            return base.ToString() + " " + "Position = " + Position;
        }

        //new public void Busy() - do new
        override public void Busy()
        {
            Console.WriteLine("Do work ... ");
        }
    }

    sealed class Student : Person //sealed - не модна успадковувати
    {
        public string Spec { get; set; }

        public Student(string name = "Empty", string spec = "Unknown position", int age = 0) : base(name, age)
        {
            Spec = spec ?? "Unknown";
            //id_other = 2;
            Age = age;
            ID = 3;
        }

        public new void Print()
        {
            Console.WriteLine("I learn " + Spec);
        }

        public override string ToString()
        {
            return base.ToString() + " " + "Spec = " + Spec;
        }

        //new public void Busy() - do new
        override public void Busy()
        {
            Console.WriteLine("Do study ... ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractPerson> people = new List<AbstractPerson>
            {
                new Person("Olivia"),
                new Student("Ivan", "IT")
            };

            Student s1 = new Student() { Name = "Andrew", Spec = "Admin" };
            people.Add(s1);
            people.AddRange(new Person[]
            {
                new Employee("Oleg", "Programmer", 22),
                new Employee("Alex", "Economist", 17),
                new Person("Galyna", 30),
                new Employee("Ira", "Cook-master"),
                new Student(name: "Pavlo", spec: "Psyhology"),
            });

            foreach (var item in people)
            {
                Console.WriteLine(item);
                item.Busy();
                item.Print();
                Console.WriteLine();
            }

            Console.Clear();

            Student newStud = new Student("vova", "it", 20);
            Console.WriteLine(newStud);
            newStud.Print();
        }
    }
}
