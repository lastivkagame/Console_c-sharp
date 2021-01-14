using Indexator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator.Classes
{
    class Person: ICanWork, IEmployee, ICanRun
    {
        public string Name { get; set; }

        public string Proffesion { get; set; }

        public string Skill { get; set; }

        //u - беззнаковий
        public uint Salary { get; set; }
        public uint Salry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Person(string name = "none name", string skill = "read", string proffesion = "empty", uint salary = 0)
        {
            Name = name;
            Skill = skill;
            Salary = salary;
            Proffesion = proffesion;
        }

        public void DoWork() //неявно реалізований метод 
        {
            Console.WriteLine("Person {0} can do {1}!", Name, Skill);
        }

        public void Run()
        {
            Console.WriteLine("Person {0} runs!", Name);
        }

        public void Walk()
        {
            Console.WriteLine("Person {0} goes for a walk!", Name);
        }

        void IEmployee.DoWork() //явеа реалізація методу DoWork з інтерфейсу IEmployee
        {
            Console.WriteLine("Person {0} can do {1}, got {2}!", Name, Skill, Salary);
        }

        public override string ToString()
        {
            return $" {Name} - {Proffesion} - {Skill} - {Salary}";
        }
    }
}
