using System;
using System.Collections.Generic;
using System.Threading;

namespace task_2.Classes_Car
{
    class Racing
    {
        public delegate void Finish(Car car);
        public static event Finish finish; // використовую якщо відстань яку машина пройде буде більша рівна всій відстані типу скільки треба пройти до фінішу
        static public void StartRacing()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);

            Console.Clear();
            Console.WriteLine("\t ---Racing---");

            int countcar = 0;

            do
            {
                try
                {
                    Console.Write("Enter count car that be at racing: ");
                    countcar = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (countcar <= 1);

            List<Car> car = new List<Car>();
            string[] carstr = { "Enter type ... ", "SportCar", "BusCar", "TruckCar", "EasyCar" };

            for (int i = 0; i < countcar; i++)
            {
                Console.Clear();
                Console.WriteLine("\t ---Racing---");
                foreach (string t in carstr) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(carstr); //виклик менюшки 

                switch (num)
                {
                    case 1:
                        {
                            car.Add(new SportCar());
                        }
                        break;
                    case 2:
                        {
                            car.Add(new BusCar());
                        }
                        break;
                    case 3:
                        {
                            car.Add(new TruckCar());
                        }
                        break;
                    case 4:
                        {
                            car.Add(new EasyCar());
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("\t ---Racing---");
            Console.WriteLine("\t  Racing is START");

            Random rand = new Random();

            finish += FinishFunc;
            int alldistance = rand.Next(2000, 2500);
            int part = rand.Next(1, 4);

            for (int i = 0; i < car.Count; i++)
            {
                car[i].go += car[i].Go;
                car[i].start += Start;
            }

            Console.WriteLine("Car is started preparation ...");
            for (int i = 0; i < car.Count; i++)
            {
                car[i].IsReady = true;
            }

            Console.Write("\n Press something ...");
            Console.ReadKey();
            Console.Clear();

            bool flag = true;

            do
            {
                Console.WriteLine("\t ---Racing---");
                Console.WriteLine("To win cars must drive distance " + alldistance + "..\n\n");
                for (int i = 0; i < car.Count; i++)
                {
                    car[i].Speed = rand.Next(Convert.ToInt32(car[i].MaxSpeed));
                    car[i].Distance += car[i].Speed * part;

                    if (car[i].Distance >= alldistance)
                    {
                        //Console.Clear();
                        finish.Invoke(car[i]);
                        flag = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine(car[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                        //break;
                    }
                    else
                    {
                        Console.WriteLine(car[i]);
                    }
                }

                Console.Write("\n Press something ...");
                Console.ReadKey();
                Console.Clear();
            } while (flag);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\tHave a nice day!\t\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(3000);
        }

        public static void FinishFunc(Car car)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Racing end! Win car " + car.Name + " by owner " + car.Owner + "!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Start(Car car)
        {
            Console.WriteLine("  " + car.Name + " is ready to start");
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t ---Racing---");
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
