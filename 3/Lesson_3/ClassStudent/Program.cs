using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudent
{
    class Info
    {
        public string Group { get; set; }
        public string Spec { get; set; }

        public Info(string group = "none", string spec = "none")
        {
            Spec = spec;
            Group = group;
        }

        public override string ToString()
        {
            return $"Group: { Group},  Spec: { Spec}";
        }

        //if Group and Spec are private
        //public string GetGroup()
        //{
        //    return Group;
        //}

        //public string GetSpec()
        //{
        //    return Spec;
        //}
    }

    class Student
    {
        private string Name { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        private Info info = new Info();
        public Info info2 { get; set; }
        public Student(string name, string lastname, int age, Info info)
        {
            Name = name;
            LastName = lastname;

            if (age > 0)
            {
                Age = age;
            }
            else
            {
                age = 0;
            }

            this.info = info;
        }

        public void ChangeSpec(string spec)
        {
            info.Spec = spec;
        }

        public void ChangeLastName(string lastname)
        {
            LastName = lastname;
        }

        public Student() : this("none", "none", 0, new Info())
        {}

        public override string ToString()
        {
            return $" Name: {Name},  LastName: {LastName},  Age: {Age}, " + info;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(name: "Vova", age: 21, lastname: "Ivanov", info: new Info("32pHr9", "somthing"));
            Student defaultStudent = new Student();

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(defaultStudent);

            student.ChangeSpec("somthing new"); //у мене кінчилася фантазія
            student.ChangeLastName("Petrow");

            Console.WriteLine();
            Console.WriteLine(student);
        }
    }
}
