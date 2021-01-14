/*Задание 1. 
1.1	Разработать один из классов, в соответствии с полученным вариантом.
1.2	Реализовать не менее пяти закрытых полей (различных типов), представляющих основные характеристики рассматриваемого класса. 
1.3	Создать не менее трех методов управления классом и методы доступа к его закрытым полям. 
1.4	Создать метод, в который передаются аргументы по ссылке. 
1.5	Создать не менее двух статических полей  (различных типов), представляющих общие характеристики объектов данного класса.  
1.6	Обязательным требованием является реализация нескольких перегруженных конструкторов, аргументы которых определяются 
    студентом,исходя из специфики реализуемого класса, а так же реализация конструктора по умолчанию.
1.7	Создать статический конструктор.  
1.8	Создать массив (не менее 5 элементов) объектов  созданного класса. 
1.9	Создать дополнительный метод для данного класса в другом файле, используя ключевое слово partial.

Варианты (по выбору):
1.	автомобиль; 
2.	мотоцикл; 
 -> 3.	самолет;   <--- MY CHOOSE
4.	бытовая техника (на выбор); 
5.	продукты питания (на выбор); 
6.	канцелярские товары (на выбор); 
7.	мебель (на выбор); 
8.	ракета;
9.	поезд;
10.	зажигалка.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_3
{
    partial class Airplane
    {
        #region All non static fields 
        private string name;
        private string model;
        private int number;
        private int maxSpeed;
        private double flightHours;
        private int countPairWings;
        private string colorFuselage;
        private double price;
        private bool isTurbineEngine;
        private string owner;
        #endregion

        #region All static fields
        private static int CountOfMachine;
        public static double PriceOfAllMachine;
        #endregion

        static Airplane()
        {
            CountOfMachine = 0;
            PriceOfAllMachine = 0;
        }

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Model
        {
            get { return model; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0) { maxSpeed = value; }
            }
        }

        public double FlightHours
        {
            get { return flightHours; }
            private set { if (value > 0) { flightHours = value; } }
        }

        public int CountPairWings
        {
            get { return countPairWings; }
            set
            {
                if (value > 0 && value <= 3) 
                {
                    countPairWings = value;
                }
                else
                {
                    Console.WriteLine("countPairWings will be set to min normal(1)");
                    countPairWings = 1;
                }
            }
        }

        public string ColorFuselage
        {
            get { return colorFuselage; }
            set { colorFuselage = value; }
        }

        public double Price
        {
            get { return price; }
            set { if (value > 0) { PriceOfAllMachine -= price; price = value; PriceOfAllMachine += value; } }
        }

        public bool IsTurbineEngine
        {
            get { return isTurbineEngine; }
            set { isTurbineEngine = value; }
        }

        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        #endregion

        public Airplane(string name, string model, int number, int maxSpeed, double flightHours,
            int countPairWings, string colorFuselage, double price, bool isTurbineEngine, string owner)
        {
            Name = name;
            this.model = model;
            Number = number;
            MaxSpeed = maxSpeed;
            FlightHours = flightHours;
            CountPairWings = countPairWings;
            ColorFuselage = colorFuselage;
            Price = price;
            IsTurbineEngine = isTurbineEngine;
            Owner = owner;

            CountOfMachine++;
        }

        public Airplane() : this("none", "unknown", 0, 0, 0, 0, "unknown color", 0, false, "noneone") { }

        public static void GetCountOfMachine(ref int count)
        {
            count = CountOfMachine;
        }
    }

    class Program
    {
        // текст меню
        static string[] text = new string[] { "Select an operation, select the down-up arrows,\n to confirm  clicking - Enter \n ",
                "1: Print", "2: Change Something", "3: Fly","4: Add Airplane","5: Remove Airplane", "6: Exit" };
        static void Main(string[] args)
        {
            Airplane[] airplanes = CreateArr();
            bool flag = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\t --- Airplanes Array --- ");

                foreach (string t in text) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(text); //виклик менюшки 
                switch (num)
                {
                    case 1: // вивід масиву
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t --- Airplanes Array --- ");
                            Console.WriteLine("\n\t - > Section #1: Print < -");

                            if (IsEmpty(airplanes)) // чи пустий
                            {
                                Console.WriteLine("Array is empty!");
                            }
                            else
                            {
                                for (int i = 0; i < airplanes.Length; i++)
                                {
                                    Console.WriteLine("\n\t  -Airplane #" + i + " at array-");
                                    Console.WriteLine(airplanes[i]);
                                }

                            }

                            Console.WriteLine("\n -Special characteristics of the species- ");

                            int count = 0;
                            Airplane.GetCountOfMachine(ref count);
                            Console.WriteLine(">Count of machine: " + count);

                            Console.WriteLine(">Price Of All Airplane: " + Airplane.PriceOfAllMachine);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        };
                        break;
                    case 2: // дає змогу змінити дещо у якомусь вибраному елементі масиву
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t --- Airplanes Array --- ");
                            Console.WriteLine("\n   - > Section #2: ChangeSomething < -");

                            Console.WriteLine("\t  - All Airplanes-");
                            for (int i = 0; i < airplanes.Length; i++)
                            {
                                Console.WriteLine(" " + i + "-" + " > " + airplanes[i].Name);
                            }

                            if (IsEmpty(airplanes)) // чи пустий
                            {
                                Console.WriteLine("Array is empty!");
                            }
                            else
                            {
                                Console.Write(">Enter in how airplanes you want change something: ");
                                int choose = Convert.ToInt32(Console.ReadLine());

                                if (choose >= airplanes.Length || choose < 0)
                                {
                                    Console.WriteLine("Iccorect direction!");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\t--- Airplanes Array --- ");
                                    string[] temp = {"-What you want choose-",
                                             " price",
                                             " owner",
                                             " number",
                                             " name",
                                             " max speed",
                                             " is turbine engine",
                                             " color fusulage"
                                };



                                    foreach (string t in temp)
                                    {
                                        Console.WriteLine("  " + t);
                                    }

                                    int num2 = keys(temp);//виклик менюшки 

                                    string name, colorFuselage, owner;
                                    int number, maxSpeed;
                                    double price;
                                    bool isTurbineEngine;

                                    Console.Clear();
                                    Console.WriteLine("\n\t --- Airplanes Array --- ");

                                    switch (num2)
                                    {
                                        case 1:
                                            Console.Write("Enter price: ");
                                            price = Convert.ToDouble(Console.ReadLine());

                                            airplanes[choose].Price = price;
                                            break;
                                        case 2:
                                            Console.Write("Enter owner: ");
                                            owner = Console.ReadLine();

                                            airplanes[choose].Owner = owner;
                                            break;
                                        case 3:
                                            Console.Write("Enter number: ");
                                            number = Convert.ToInt32(Console.ReadLine());

                                            airplanes[choose].Number = number;
                                            break;
                                        case 4:
                                            Console.Write("Enter name: ");
                                            name = Console.ReadLine();

                                            airplanes[choose].Name = name;
                                            break;
                                        case 5:
                                            Console.Write("Enter maxSpeed: ");
                                            maxSpeed = Convert.ToInt32(Console.ReadLine());

                                            airplanes[choose].MaxSpeed = maxSpeed;
                                            break;
                                        case 6:
                                            Console.Write("Enter isTurbineEngine(true or false): ");
                                            isTurbineEngine = Convert.ToBoolean(Console.ReadLine());

                                            airplanes[choose].IsTurbineEngine = isTurbineEngine;
                                            break;
                                        case 7:
                                            Console.Write("Enter colorFuselage: ");
                                            colorFuselage = Console.ReadLine();

                                            airplanes[choose].ColorFuselage = colorFuselage;
                                            break;
                                        default:
                                            Console.WriteLine("Inccorect direction!");
                                            break;
                                    }
                                }
                            }
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: //типу літаки літаки літають і додаються години до певної змінної(години в небі)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t --- Airplanes Array --- ");
                            Console.WriteLine("\n\t - > Section #3: Fly < -");
                            double hours;

                            if (IsEmpty(airplanes)) // чи пустий
                            {
                                Console.WriteLine("Array is empty!");
                            }
                            else
                            {
                                for (int i = 0; i < airplanes.Length; i++)
                                {
                                    Console.Write("Airplane " + airplanes[i].Name + " will be fly.\n  Enter how long will be this travel(in hours): ");
                                    hours = Convert.ToDouble(Console.ReadLine());

                                    if (hours <= 15 && hours > 0)
                                    {
                                        Console.Clear();

                                        airplanes[i].Fly(hours);

                                        Console.Write("fly ");
                                        for (int j = 0; j < 3; j++)
                                        {
                                            Console.Write(" . ");
                                            Thread.Sleep(700);
                                        }

                                        Console.WriteLine("\nAirplane " + airplanes[i].Name + " end flying.");
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("Inccorect direction!(hours must be <= 15)!");
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                            }
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: // додавання літака в масив
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t --- Airplanes Array --- ");
                            Console.WriteLine("\n   - > Section #4: Add Airplane < -");

                            Array.Resize(ref airplanes, airplanes.Length + 1);
                            airplanes[airplanes.Length - 1] = AddOneAirplane();

                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n  Sucssess! You add new airplane!  \n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 5: // видалення літака з масиву
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t --- Airplanes Array --- ");
                            Console.WriteLine("\n   - > Section #5: Remove Airplane < -");

                            Console.WriteLine("\t  - All Airplanes-");


                            if (IsEmpty(airplanes)) // чи пустий
                            {
                                Console.WriteLine("There is no airplanes!");
                            }
                            else
                            {
                                for (int i = 0; i < airplanes.Length; i++)
                                {
                                    Console.WriteLine(" " + i + "-" + " > " + airplanes[i].Name);
                                }

                                Console.Write(">Enter in how airplanes you want change something: ");
                                int choose2 = Convert.ToInt32(Console.ReadLine());

                                if (choose2 >= airplanes.Length || choose2 < 0)
                                {
                                    Console.WriteLine("Iccorect direction!");
                                    Thread.Sleep(3000);

                                }
                                else
                                {
                                    Airplane.PriceOfAllMachine -= airplanes[choose2].Price;

                                    for (int i = choose2; i < airplanes.Length - 1; i++)
                                    {
                                        airplanes[i] = airplanes[i + 1];
                                    }
                                    Array.Resize(ref airplanes, airplanes.Length - 1);
                                    Console.WriteLine("Now exist:" + airplanes.Length + " airplanes");
                                }
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 6: // вихід 
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
                }
                Console.Clear();
            } while (flag == true);
        }

        static bool IsEmpty(Airplane[] arr)
        {
            if (arr.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static Airplane[] CreateArr() // створює і повертає масив Airplane
        {
            Console.Write("Enter size: ");
            int size = Convert.ToInt32(Console.ReadLine());

            if (size < 5) // бо умова така
            {
                size = 5;
                Console.WriteLine(" Number that you input is low than 5 thenfore -> size = 5\n");
            }
            Console.WriteLine(" -size is now set- \n");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  Sucssess! \n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Now fill them.\n");

            Airplane[] airplanes = new Airplane[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("\n\t --- Airplanes Array --- ");
                Console.WriteLine("airplane #" + i);

                airplanes[i] = AddOneAirplane();
            }

            return airplanes;
        }

        static Airplane AddOneAirplane() // створює і повертає один Airplane
        {
            string name, model, colorFuselage, owner;
            int number, maxSpeed, countPairWings;
            double flightHours, price;
            bool isTurbineEngine;

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter model: ");
            model = Console.ReadLine();

            Console.Write("Enter colorFuselage: ");
            colorFuselage = Console.ReadLine();

            Console.Write("Enter owner: ");
            owner = Console.ReadLine();

            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter maxSpeed: ");
            maxSpeed = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter countPairWings: ");
            countPairWings = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter flightHours: ");
            flightHours = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter price: ");
            price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter isTurbineEngine(true or false): ");
            isTurbineEngine = Convert.ToBoolean(Console.ReadLine());
            Console.Clear();

            return new Airplane(name, model, number, maxSpeed, flightHours,
                 countPairWings, colorFuselage, price, isTurbineEngine, owner);
        }
        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\n\t --- Airplanes Array --- ");
            Console.WriteLine("  " + texts[0]);

            for (int j = 1; j < texts.Length; j++)
            {
                if (j == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> " + texts[j] + " <");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
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