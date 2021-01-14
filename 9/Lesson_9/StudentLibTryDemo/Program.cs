using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib;

namespace StudentLibTryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { Name = "Oleg", LastName = "Kovalchuk", Age = 21 };
            StudentService list = new StudentService();

            student.AddMark("c#", 10);
            list.AddStudent(student);
            list.AddStudent(new Student { Name = "Sergiy", LastName = "Vovkov", Age = 19 });
            list.AddStudent(new Student { Name = "Yana", LastName = "Romashkova", Age = 20 });
            list.AddStudent(new Student { Name = "Ema", LastName = "Persukova", Age = 22 });
            //list.DeleteStudent(st);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();

            Console.Clear();

            try
            {
                list.Serialize_Binary(Directory.GetCurrentDirectory() + "/bin_students.bin");
                //list.Serialize_XML(Directory.GetCurrentDirectory()+ "/xml_students.xml");
                list.Serialize_Json(Directory.GetCurrentDirectory() + "/json_students.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Clear();
            list.ClearList();
            try
            {
                list.Deserialize_Binary(Directory.GetCurrentDirectory() + "/bin_students.bin");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Deserialize binary\n\n");
            PrintList(list);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();

            //Console.Clear();
            //list.ClearList();
            //list.Deserialize_Json(Directory.GetCurrentDirectory() + "/json_students.json");
            //Console.WriteLine("Deserialize Json");
            //PrintList(list);
            //Console.WriteLine("\n Press something ...");
            //Console.ReadKey();

            Console.Clear();
            list.ClearList();
            list.Deserialize_XML(Directory.GetCurrentDirectory() + "/xml_students.xml");
            Console.WriteLine("Deserialize XML");
            PrintList(list);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();

        }

        private static void PrintList(StudentService list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
