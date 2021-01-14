/*Бінарна серіалізація.
XML. XML - серіалізація.
1. Зберегти і завантажити масив  студентів :) (чи ін) за допомогою BinaryFormatter'а.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace task_1
{
    class Program
    {
        [Serializable]
        public class Student
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public List<Grade> grades { get; private set; }
            public Guid StudentId { get; private set; }

            public Student()
            {
                StudentId = Guid.NewGuid();
                grades = new List<Grade>();
            }

            public override string ToString()
            {
                return $"{Name,-15} {LastName,-15} Age: {Age,-15}  ID: {StudentId,-15}";
            }

            public void AddMark(string sublect, int mark)
            {
                Grade find = grades.Find(x => x.Subject.Equals(sublect));

                if (find != null)
                {
                    find.Mark = mark;
                }
                else
                {
                    grades.Add(new Grade { Mark = mark, Subject = sublect });
                }
            }


        }

        [Serializable]
        public class Grade
        {
            public Grade()
            {

            }
            public int Mark { get; set; }
            public string Subject { get; set; }
        }

        static void Main(string[] args)
        {
            //1.Зберегти і завантажити масив студентів :) (чи ін) за допомогою BinaryFormatter'а.
            List<Student> list = new List<Student>
                {
                new Student { Name = "Sergiy", LastName = "Vovkov", Age = 19 },
                new Student { Name = "Yana", LastName = "Romashkova", Age = 20 },
                new Student { Name = "Ema", LastName = "Persukova", Age = 22 },
            };

            list[0].AddMark("c#", 12);
            list[1].AddMark("Java Script", 10);
            list[2].AddMark("c++", 11);

            BinarySerialization(list);
            list.Clear();
            list = BinaryDesearilisation();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static List<Student> BinaryDesearilisation()
        {
            List<Student> list = new List<Student>();

            using (FileStream fs = new FileStream("list_stud.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                list = (List<Student>)bf.Deserialize(fs);
            }

            return list;
        }

        private static void BinarySerialization(List<Student> list)
        {
            using (FileStream fs = new FileStream("list_stud.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);
            }
        }
    }
}
