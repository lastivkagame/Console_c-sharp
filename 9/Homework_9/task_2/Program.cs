/*Дописати до бібліотеки, яку писали на парі методи для серіалізації/десерiaлізації json
Продемонструвати в Main*/

using StudentLib;
using System;
using System.IO;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { Name = "Oleg", LastName = "Kovalchuk", Age = 21 };
            StudentService list = new StudentService();
            StudentService list2 = new StudentService();

            student.AddMark("c#", 10);
            list.AddStudent(student);
            list.AddStudent(new Student { Name = "Sergiy", LastName = "Vovkov", Age = 19 });
            list.AddStudent(new Student { Name = "Yana", LastName = "Romashkova", Age = 20 });
            list.AddStudent(new Student { Name = "Ema", LastName = "Persukova", Age = 22 });

            Console.Clear();

            string bin = Directory.GetCurrentDirectory() + "/bin_students.bin";
            string xml = Directory.GetCurrentDirectory() + "/xml_students.xml";
            string json = Directory.GetCurrentDirectory() + "/json_students.json";

            try
            {
                list.Serialize_Binary(bin);
                list.Serialize_XML(xml);
                list.Serialize_Json(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Clear();

            try
            {
                list2.Deserialize_Binary(bin);
                Console.WriteLine("Deserialize binary\n");
                PrintList(list2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            list2.ClearList();

            try
            {
                Console.Clear();
                list2.Deserialize_XML(xml);
                Console.WriteLine("Deserialize XML\n");
                PrintList(list2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            list2.ClearList();

            try
            {
                Console.Clear();
                list2.Deserialize_Json(json);
                Console.WriteLine("Deserialize Json\n");
                PrintList(list2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
