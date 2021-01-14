using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonDemo
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public Guid StudentId { get; private set; } // щось схоже на хеш код 3456-53вц- ... global unifield id

            public Student()
            {
                StudentId = Guid.NewGuid();
            }

            public override string ToString()
            {
                return Name + " " + LastName + ", Age  " + Age + ", ID: " + StudentId;
            }
        }
        static void Main(string[] args)
        {
            /*  Example Json serealization
                {
                    Name: "Ivan",
                    LastName: "Ivanenko",
                }
            */

            #region Serialize Json
            /*
            Student student = new Student
            {
                Name = "Ivan",
                LastName = "Ivanenko",
                Age = 18,
            };

            Console.WriteLine("Student 1: " + student);

            string json = JsonConvert.SerializeObject(student, Formatting.Indented);
            Console.WriteLine(json);

            File.WriteAllText("student.json", json);

            List<Student> group = new List<Student>()
            {
                new Student{Name="Olia", LastName="Olivkova", Age = 19},
                new Student{Name="Alex", LastName="lexov", Age = 19},
                new Student{Name="Vova", LastName="Vinov", Age = 20},
            };

            group.Add(student);

            json = JsonConvert.SerializeObject(group, Formatting.Indented);
            File.WriteAllText("student.json", json);
            */
            #endregion


            //Student student1 = null; - але має бути у студенті один студент а не група
            string json;// = File.ReadAllText("student.json");
            //student1 = JsonConvert.DeserializeObject<Student>(json);

            //Console.WriteLine(student1);

            List<Student> list = null;

            json = File.ReadAllText("student.json");
            list = JsonConvert.DeserializeObject<List<Student>>(json);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
