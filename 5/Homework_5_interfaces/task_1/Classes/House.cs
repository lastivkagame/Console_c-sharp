using System;
using System.Collections.Generic;
using task_1.interfaces;

namespace task_1.Classes
{
    class House
    {
        public List<IPart> parts = new List<IPart>();

        public House(Team team, TypeBasement typebasement = 0, TypeWalls typewalls1 = 0, TypeWalls typewalls2 = 0,
            TypeWalls typewalls3 = 0, TypeWalls typewalls4 = 0, TypeRoof typeroof = 0,
            TypeDoor typedoor = 0, TypeWindow typewindow1 = 0, TypeWindow typewindow2 = 0, TypeWindow typewindow3 = 0,
            TypeWindow typewindow4 = 0)
        {
            /*Будинок  складається  з  фундаменту (Basement), стін (Wall), вікон (Window),дверей (Door), даху (Roof).
         Згідно проекту, в будинку повинно бути 1 фундамент, 4 стіна, 1 двері, 4 вікна і 1 дах. */

            parts.Add(new Basement(typebasement));

            parts.Add(new Walls(typewalls1));
            parts.Add(new Walls(typewalls2));
            parts.Add(new Walls(typewalls3));
            parts.Add(new Walls(typewalls4));

            parts.Add(new Roof(typeroof));

            parts.Add(new Door(typedoor));

            parts.Add(new Window(typewindow1));
            parts.Add(new Window(typewindow2));
            parts.Add(new Window(typewindow3));
            parts.Add(new Window(typewindow4));

            team.BuildHouse(parts);
            bool flag = true;

            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[0].IsIReady() == false)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                PrintReadyHouse();
            }
        }

        void PrintReadyHouse()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tWelcome House is Ready!!!\t\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(@"     _______________________      ");
            Console.WriteLine(@"    / \_____________________\     ");
            Console.WriteLine(@"   /   \________\______\_____\    ");
            Console.WriteLine(@"  /  _  \ ____________________\   ");
            Console.WriteLine(@" |  |_|  |   _____     _____  |  ");
            Console.WriteLine(@" |   _   |  |__|__|   |__|__| |  ");
            Console.WriteLine(@" |  | |  |  |__|__|   |__|__| |  ");
            Console.WriteLine(@" \__|_|__+____________________+  ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tHave a nice day!\t\t\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
