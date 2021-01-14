using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task_1.Classes
{
    class Employee
    {
        private string name;
        private string lastname;
        private string post;
        private double salary;
        private int numberOfContract;

        public Employee(string name = "none", string lastname = "none", string post = "none", double salary = 1, int numberOfContract = 1)
        {
            Name = name;
            Lastname = lastname;
            Post = post;
            Salary = salary;
            NumberOfContract = numberOfContract;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (IsStringWithoutNumber(value))
                {
                    name = value;
                }
                else
                {
                    throw new FormatException("Inccorect input! You must enter in NAME only symbols! No Digits!");
                }
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (IsStringWithoutNumber(value))
                {
                    lastname = value;
                }
                else
                {
                    throw new FormatException("Inccorect input! You must enter in LASTNAME only symbols! No Digits!");
                }
            }
        }

        public string Post
        {
            get { return post; }
            set
            {
                if (IsStringWithoutNumber(value))
                {
                    post = value;
                }
                else
                {
                    throw new FormatException("Inccorect input! You must enter in POST only symbols! No Digits!");
                }
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (IsDigitsString(value.ToString()))
                {
                    if (value > 0)
                    {
                        salary = value;
                    }
                    else
                    {
                        throw new Exception("Salary must be more than 0!");
                    }
                }
                else
                {
                    throw new FormatException("Inccorect input! You must enter in SALARY only digits! No Symbols!");
                }
            }
        }

        public int NumberOfContract
        {
            get { return numberOfContract; }
            set
            {
                if (IsDigitsString(value.ToString()))
                {
                    numberOfContract = value;
                }
                else
                {
                    throw new FormatException("Inccorect input! You must enter in NumberOfContract only digits! No Symbols!");
                }
            }
        }

        public bool IsDigitsString(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStringWithoutNumber(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $" Name: {Name};      LastName: {Lastname};      Post: {Post};       Salary: {Salary};       NumberOfContract: {NumberOfContract};";
        }
    }
}
