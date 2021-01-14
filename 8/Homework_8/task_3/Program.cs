/*3. Визначити клас Продукт(назва, тип продукту, ціна, кількість) або використати один з 
створених раніше класів(Студент, Працівник).Виконати xml-серіалізацію обєкта(масиву обєктів). 
Відновити збережену інформацію(десеріалізувати).*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace task_3
{
    [Serializable]
    public class Employee
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Skills")]
        public string[] Skills { get; set; }

        [XmlElement("Salary")]
        public double Salary { get; set; }

        public Employee()
        {

        }

        public Employee(string name, string lastname, int id, string[] skills, double salary)
        {
            Name = name;
            LastName = lastname;
            Id = id;
            Skills = skills;
            Salary = salary;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Serialization One Employee
            Employee empl1 = new Employee("Jonh", "White", 213342, new[] { "Adobe Photoshop", "Adobe illustrator", "Adobe After Effect" }, 12000);

            try
            {
                XmlSerializer xml = new XmlSerializer(empl1.GetType(), new[] { typeof(string) });
                //xml.Serialize(new FileStream("employee.xml", FileMode.OpenOrCreate), empl1); - 1 для запису

                Employee empl2 = null;
                empl2 = (Employee)xml.Deserialize(new FileStream("employee.xml", FileMode.Open)); // 2 - для зчитування

                Console.WriteLine($"Employee 2: {empl2.Name} {empl2.LastName} Id: {empl2.Id} \n Skills: ");

                foreach (var item in empl2.Skills)
                {
                    Console.WriteLine("\t - " + item);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Serealization list Employees
            List<Employee> employees = new List<Employee>()
            {
                new Employee("Emmy", "Pink", 787239, new[] { "Exel", "Word", "PowerPoint" }, 9000),
                new Employee("Alex", "Gray", 672323, new[] { "c#", "c++", "c" }, 20000),
                new Employee("David", "Green", 278456, new[] { "ArchiCad", "3D Compas", "Maya 3D" }, 20000),
            };

            XmlSerializer xml2 = new XmlSerializer(employees.GetType(), new[] { typeof(string) });
            //xml2.Serialize(new FileStream("employees_list.xml", FileMode.OpenOrCreate), employees); - 1 для запису

            employees.Clear();

            employees = (List<Employee>)xml2.Deserialize(new FileStream("employees_list.xml", FileMode.Open));

            Console.WriteLine("\t\t -Employees-");

            foreach (var item in employees)
            {
                Console.WriteLine($" Employee: {item.Name} {item.LastName} Id: {item.Id} \n Skills: ");

                foreach (var item2 in item.Skills)
                {
                    Console.WriteLine("\t - " + item2);
                }
                Console.WriteLine();
            }
            #endregion

            #region Serealization Employee Array
            Employee[] arr_employees = { employees[0], employees[1], employees[2], empl1 };

            XmlSerializer xml3 = new XmlSerializer(arr_employees.GetType(), new[] { typeof(string) });
            //xml3.Serialize(new FileStream("employees_arr.xml", FileMode.OpenOrCreate), arr_employees); //- 1 для запису

            Employee[] arr_employees2 = null;

            arr_employees2 = (Employee[])xml3.Deserialize(new FileStream("employees_arr.xml", FileMode.Open));

            Console.WriteLine("\n\n\t\t -Employees arr-");

            foreach (var item in arr_employees2)
            {
                Console.WriteLine($" Employee: {item.Name} {item.LastName} Id: {item.Id} \n Skills: ");

                foreach (var item2 in item.Skills)
                {
                    Console.WriteLine("\t - " + item2);
                }
                Console.WriteLine();
            } 
            #endregion
        }
    }
}
