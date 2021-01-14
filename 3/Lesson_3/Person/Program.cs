using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        static int count; // статичне поле не належить обєкту, а належить класу 

        public static int GetCount()
        {
            return count;
        }
        public string Name { get; set; }
        public int Age { get; set; } // prop tab tab
        private string gender; //propfull tab tab

        int @this = 2;
        public List<string> Skills { get; set; } = new List<string>();
        public string NameAge => Name + " " + Age; //стрелковий метод або комбінованна властивість

        public string Gender
        {
            get { return gender; }
            set
            {
                //if (value != null)
                //gender = value;
                gender = value ?? "empty"; // перевірка на null
            }
        }

        public Person(string name, int age, string gender) //ctor tab tab
        {
            Name = name;
            Age = age;
            Gender = gender;
            count++;
        }

        public Person()
        {
            count++;
        }

        public Person(Person person)
        {
            Name = person.Name;
            Age = person.Age;
            Gender = person.Gender;
        }

        static Person()
        {
            Console.WriteLine("Work static c-tor");
            count = 0;
        }

        public override string ToString() => $"{Name} - {Age} y.o - {Gender}";
        //{
        //    return $"{Name} - {Age} y.o - {Gender}";
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person defaultperson = new Person();
            Person someperson = new Person("Demien", 18, "male");
            Console.WriteLine(defaultperson);
            Console.WriteLine(someperson);

            Person p2 = new Person
            {
                Name = "Olia",
                Gender = "female"
            };

        Console.WriteLine(p2);

            Person p3 = new Person();
            p3.Name = "Andrew";
            p3.Gender = "male";
            p3.Age = 15;

            Console.WriteLine("Count = " + Person.GetCount());

            p2 = p3; //поверхнева копія - скопійовали посилання
            Console.WriteLine(p2);
            p2.Age = 34;
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            Person p4 = new Person(p2);
            p4.Name = "Kostia";
            Console.WriteLine(p2);
            Console.WriteLine(p4);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(p4.NameAge);
        }
    }
}
