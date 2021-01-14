using Indexator.Classes;
using Indexator.Interfaces;
using System;

namespace Indexator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Indexators
            //Group group = new Group();
            //group.AddStudent(new Student("Homer", 20));
            //group.AddStudent(new Student("Maruv", 23));
            //group.AddStudent(new Student("Liza", 18));

            //Console.WriteLine("Student 0: " + group[0]);
            //Console.WriteLine("Student[Liza]: " + group["Liza"]);
            //group[1] = new Student("andew", 17);
            //Console.WriteLine("Student[1]: " + group[1]); 
            #endregion

            Bee bee = new Bee();
            bee.Fly();
            bee.DoWork();
            Separator();

            ICanFly ifly = bee; // обєкт не явно можна привести до інтерфейсу, який він реалізує
            ifly.Fly();
            ICanWork iwork = bee;
            bee.DoWork();
            Separator();

            Person person = new Person("Ivan", ".Net", "proggramer", 3500);
            Console.WriteLine(person);
            person.Run();
            person.Walk();
            person.Salary += 200;
            Console.WriteLine(person);
            person.DoWork();   //ICanWork - бо неявно реалізований
            Console.WriteLine();
            (person as IEmployee).DoWork(); // явний виклик методу з  інтерфейсу IEmployee
            (person as ICanWork).DoWork(); // явний виклик методу з  інтерфейсу ICanWork
            Separator();

            ICanWork[] workers = {new Bee(),
                new Person("Olia", "make candies", "confectioner", 5000),
                new Student("Oleg", 18)
            };

            foreach (var item in workers)
            {
                item.DoWork();

                if (item is Person)
                    (item as Person).Run();
            }

            Separator();
        }

        private static void Separator()
        {
            Console.WriteLine("\n");
        }
    }
}
