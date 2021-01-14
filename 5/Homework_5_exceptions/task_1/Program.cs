/*      Завдання 1.
Написати клас Employee (Працівник), що описує працівника, містить дані про
    o ім'я, 
    o прізвище,
    o посаду, 
    o заробітну плату
    o номер договору про прийом на роботу 
    o властивості доступу до полів
Визначити у класі методи
    o вводу імені та прізвища,
    o вводу заробітної плати.
 Методи повинні викидати винятки
    - при введені у ім’я чи прізвище недопустимих символів(цифр, чи ін),
    - введенні символьних даних в числові поля(заробітна плата)
Створити клас Department(відділ), що міститиме масив(або список List<>) з працівників(Employeе) та методи
    o додавання працівників,
    o видалення працівника(за номером договору чи прізвищем та іменем) 
    o перегляд відділу
До класу Department додати обробку виняткових ситуацій o перевищення розміру масиву
працівників відділу(або деякої кількості, якщо обрано колекцію List<>)
    o видалення даних з пустого масиву(списку), тобто видалення працівника з відділу, 
якщо в відділі ще немає жодного працівника)
У програмі надати користувачу можливість здійснити повторну спробу введення даних.
Можна визначити свої класи винятків class
    FullDerartmentException : ApplicationException
    { 
    public FullDerartmentException(string message = "Department is full") : base(message){ }
    }*/

using System;
using System.Threading;
using task_1.Class_exceptions;
using task_1.Classes;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);

            int maxEmployee = 1;

            Console.Clear();

            do
            {
                Console.Write("Enter max employee at department(must be more than 0): ");

                try
                {
                    maxEmployee = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    maxEmployee = 1;
                }
            } while (maxEmployee <= 0);

            Department department = new Department(maxEmployee);

            bool flag = true;
            string[] menu = { "-Menu-", "Print Department","Print One Employee","Add Employee",
                "Remove Employee By Name And Lastname","Remove Employee By Number Of Contract",
                "Change Info About Employee","Exit" };

            do
            {
                Console.Clear();
                Console.WriteLine("\t ---Department---");

                foreach (string t in menu) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(menu); //виклик менюшки 
                switch (num)
                {
                    case 1: //Print Department
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #1: Print Department <-\n");

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 2: //Print One Employee
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #2: Print One Employee <-\n");

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();

                            Console.WriteLine("Choose employee ...");
                            Console.WriteLine(" 1 -> By name and lastname  2 -> By number");
                            Console.Write("Answer: ");
                            int choose2 = 3;

                            try
                            {
                                choose2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            string name, lastname;
                            int number;

                            if (choose2 == 1)
                            {
                                try
                                {
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();

                                    Console.Write("Enter lastname: ");
                                    lastname = Console.ReadLine();

                                    Console.Clear();

                                    Console.WriteLine();
                                    Console.WriteLine(department[department.FindByNameLastName(name, lastname)]);
                                    Console.WriteLine();
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (choose2 == 2)
                            {
                                try
                                {
                                    Console.Write("Enter number: ");
                                    number = Convert.ToInt32(Console.ReadLine());

                                    Console.Clear();

                                    Console.WriteLine();
                                    Console.WriteLine(department[department.FindByNumber(number)]);
                                    Console.WriteLine();
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Inccorect input! Try again later!");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: //Add Employee
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #3: Add Employee <-\n");

                            string name = "none", lastname = "none", post = "none";
                            double salary = 1;
                            int numberOfContract = 1;

                            try
                            {
                                Console.Write("Enter name: ");
                                name = Console.ReadLine();

                                Console.Write("Enter lastname: ");
                                lastname = Console.ReadLine();

                                Console.Write("Enter post: ");
                                post = Console.ReadLine();

                                Console.Write("Enter salary: ");
                                salary = Convert.ToDouble(Console.ReadLine());

                                Console.Write("Enter numberOfContract: ");
                                numberOfContract = Convert.ToInt32(Console.ReadLine());

                                try
                                {
                                    department.AddEployee(new Employee(name, lastname, post, salary, numberOfContract));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: //Remove Employee By Name And Lastname
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #4: Remove Employee By Name And Lastname <-\n");

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();

                            string name, lastname;

                            try
                            {
                                Console.Write("Enter name: ");
                                name = Console.ReadLine();

                                Console.Write("Enter lastname: ");
                                lastname = Console.ReadLine();

                                Console.Clear();

                                Console.WriteLine();
                                Console.WriteLine(department[department.FindByNameLastName(name, lastname)] + "\n will be removed");
                                Console.WriteLine();

                                Thread.Sleep(1000);
                                Console.Clear();

                                department.RemoveEmployee(name, lastname);
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Operation end");

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 5: //Remove Employee By Number Of Contract
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #5: Remove Employee By Number Of Contract <-\n");

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();

                            int number;

                            try
                            {
                                Console.Write("Enter number: ");
                                number = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();

                                Console.WriteLine();
                                Console.WriteLine(department[department.FindByNumber(number)] + "\n will be removed");
                                Console.WriteLine();

                                Thread.Sleep(1000);
                                Console.Clear();

                                department.RemoveEmployee(number);
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opreration end");

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 6: //Change Info About Employee
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Department---");
                            Console.WriteLine("\n -> Section #6: Change Info About Employee <-\n");

                            try
                            {
                                department.PrintDepartment();
                            }
                            catch (EmptyDerartmentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();

                            Console.WriteLine("Choose employee ...");
                            Console.WriteLine(" 1 -> By name and lastname  2 -> By number");
                            Console.Write("Answer: ");
                            int choose2 = 3;

                            try
                            {
                                choose2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            if (choose2 == 1 || choose2 == 2)
                            {
                                string oldname = " ", oldlastname = " ";
                                int oldnumber = 1;

                                if (choose2 == 1)
                                {
                                    Console.Write("Enter name: ");
                                    oldname = Console.ReadLine();

                                    Console.Write("Enter lastname: ");
                                    oldlastname = Console.ReadLine();
                                }
                                else
                                {
                                    Console.Write("Enter number: ");
                                    oldnumber = Convert.ToInt32(Console.ReadLine());
                                }

                                string name = "none", lastname = "none", post = "none";
                                double salary = 1;
                                int numberOfContract = 1;

                                string[] text6 = { "What you want change?","name", "lastname", "post",
                            "salary","numberOfContract" };

                                Console.Clear();

                                foreach (string t in text6) // вивід менюшки
                                {
                                    Console.WriteLine("  " + t);
                                }

                                int num3 = keys(text6);

                                try
                                {
                                    switch (num3)
                                    {
                                        case 1:
                                            {
                                                Console.Write("Enter name: ");
                                                name = Console.ReadLine();

                                                if (choose2 == 1)
                                                {
                                                    department[department.FindByNameLastName(oldname, oldlastname)].Name = name;
                                                }
                                                else
                                                {
                                                    department[department.FindByNumber(oldnumber)].Name = name;
                                                }
                                            }
                                            break;
                                        case 2:
                                            {
                                                Console.Write("Enter lastname: ");
                                                lastname = Console.ReadLine();

                                                if (choose2 == 1)
                                                {
                                                    department[department.FindByNameLastName(oldname, oldlastname)].Lastname = lastname;
                                                }
                                                else
                                                {
                                                    department[department.FindByNumber(oldnumber)].Lastname = lastname;
                                                }
                                            }
                                            break;
                                        case 3:
                                            {
                                                Console.Write("Enter post: ");
                                                post = Console.ReadLine();

                                                if (choose2 == 1)
                                                {
                                                    department[department.FindByNameLastName(oldname, oldlastname)].Post = post;
                                                }
                                                else
                                                {
                                                    department[department.FindByNumber(oldnumber)].Post = post;
                                                }
                                            }
                                            break;
                                        case 4:
                                            {
                                                Console.Write("Enter salary: ");
                                                salary = Convert.ToDouble(Console.ReadLine());


                                                if (choose2 == 1)
                                                {
                                                    department[department.FindByNameLastName(oldname, oldlastname)].Salary = salary;
                                                }
                                                else
                                                {
                                                    department[department.FindByNumber(oldnumber)].Salary = salary;
                                                }
                                            }
                                            break;
                                        case 5:
                                            {
                                                Console.Write("Enter numberOfContract: ");
                                                numberOfContract = Convert.ToInt32(Console.ReadLine());

                                                if (choose2 == 1)
                                                {
                                                    department[department.FindByNameLastName(oldname, oldlastname)].NumberOfContract = numberOfContract;
                                                }
                                                else
                                                {
                                                    department[department.FindByNumber(oldnumber)].NumberOfContract = numberOfContract;
                                                }
                                            }
                                            break;
                                        default:

                                            break;
                                    };
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Incorect input!");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 7: // Exit
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\tHave a nice day!\t\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Thread.Sleep(4000);
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }
            } while (flag);
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t ---Department---");
            Console.WriteLine("  " + texts[0]);

            for (int j = 1; j < texts.Length; j++)
            {
                if (j == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> " + texts[j] + " <");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  " + texts[j]);
                }
            }
        }
        static int keys(string[] texts) //робота менюшки
        {
            int num = 0;
            int max = texts.Length;
            bool flag = false;
            do
            {
                ConsoleKeyInfo keyPushed = Console.ReadKey();
                if (keyPushed.Key == ConsoleKey.DownArrow)
                {
                    num++;
                }
                if (keyPushed.Key == ConsoleKey.UpArrow)
                {
                    num--;
                }
                if (keyPushed.Key == ConsoleKey.Enter)
                {
                    flag = true;
                }
                if (num <= 0)
                {
                    num = max - 1;
                }
                else if (num >= max)
                {
                    num = 1;
                }

                Text(num, texts);
            } while (!flag);
            return num;
        }
    }
}
