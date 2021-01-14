/*  Завдання 2.
 Створити базовий абстрактний клас Shape.  
     o Визначити у класі  абстрактну властивість для читання Area(обчислення площі фігури)
     o Визначити у класі віртуальний  метод Print(), вивести назву фігури(this.GetType().Name) та її площу(Area).

 Створити клас Circle, похідний від  класу Shape. 
     o Визначити у класі поле radius 
     o Реалізувати у класі віртуальну властивість для читання Area.

 Створити клас Rectangle, похідний від  класу Shape.
     o Визначити у класі поля висота та ширина.
     o Реалізувати у класі віртуальну властивість для читання Area (ширина  * висота).

 Створити для перевірки список( List<> )з фігур. Помістити у список різного типу фігури. 
     o Вивести інформацію про всі фігури 
     o Впорядкувати список фігур за зростанням площ фігур oЗібрати фігури, 
            що є колами  у окремий список(FindAll)*/

using System;
using System.Collections.Generic;
using System.Threading;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();

            Console.WriteLine("\t---List Shape---");

            double radius = -1;
            double height = -1;
            double width = -1;

            do
            {
                try
                {
                    Console.WriteLine(" - Circle - ");
                    Console.Write("Enter radius: ");
                    radius = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Clear();
            } while (radius <= 0);

            do
            {
                try
                {
                    Console.WriteLine("\n - Rectangle -");
                    Console.Write("Enter height: ");
                    height = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter width: ");
                    width = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Clear();
            } while (height <= 0 || width <= 0);

            shapes.Add(new Circle(radius));
            shapes.Add(new Rectangle(height, width));
            shapes.Add(new Circle(10));
            shapes.Add(new Rectangle(5, 20));
            PrintList(shapes); //Вивести інформацію про всі фігури 

            shapes.Sort((x, y) => (x as Shape).Area.CompareTo((y as Shape).Area)); //Впорядкувати список фігур 
            Console.WriteLine("-After sort-");                                      //за зростанням площ фігур 
            PrintList(shapes);

            List<Shape> circles = shapes.FindAll((x) => x is Circle); //oЗібрати фігури, що є колами 
            Console.WriteLine("-New List of Circle only-");             //у окремий список(FindAll)
            PrintList(circles);
        }

        static void PrintList(List<Shape> shapes)
        {
            Console.WriteLine(" -Shape List-");
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Print();
            }
            Console.WriteLine();
        }
    }
}
