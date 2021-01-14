using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_1.Class_exceptions;

namespace task_1.Classes
{
    class Department
    {
        List<Employee> employees = new List<Employee>();
        int maxEployees;

        public Department()
        {
            maxEployees = 1;
        }

        public Department(int maxEployees)
        {
            this.maxEployees = maxEployees;
        }

        public void AddEployee(Employee empl)
        {
            if (maxEployees < employees.Count + 1)
            {
                throw new FullDerartmentException();
            }
            else
            {
                employees.Add(empl);
            }
        }

        public void RemoveEmployee(string name, string lastname)
        {
            if (IsEmptyDepartment())
            {
                throw new EmptyDerartmentException();
            }
            else
            {
                employees.RemoveAt(FindByNameLastName(name, lastname));
            }
        }

        public void RemoveEmployee(int number)
        {
            if (IsEmptyDepartment())
            {
                throw new EmptyDerartmentException();
            }
            else
            {
                employees.RemoveAt(FindByNumber(number));
            }
        }

        public void PrintDepartment()
        {
            Console.WriteLine("\t ---Department---");

            if (IsEmptyDepartment())
            {
                throw new EmptyDerartmentException();
            }
            else
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine(employees[i]);
                }
                Console.WriteLine();
            }
        }

        public int FindByNameLastName(string name, string lastname)
        {
            string text = name + lastname;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name + employees[i].Lastname == text)
                {
                    return i;
                }
            }

            throw new Exception("Not Found Employee");
        }

        public int FindByNumber(int number)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].NumberOfContract == number)
                {
                    return i;
                }
            }

            throw new Exception("Not Found Employee");
        }

        public bool IsEmptyDepartment()
        {
            if (employees.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee this[int index]
        {
            get
            {
                if (index < 0 || index > employees.Count)
                    throw new ArgumentException("index incorect");
                return employees[index];
            }
            set
            {
                if (index < 0 || index > employees.Count)
                    throw new ArgumentException("index incorect");
                employees[index] = value;
            }
        }
    }
}
