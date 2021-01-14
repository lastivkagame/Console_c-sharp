using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class Program
    {
        enum Level
        {
            Beginer,
            Intermediate,
            Advanced
        }
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Blue;

            #region MyRegion
            //Level level; //= Level.Intermediate;

            //string levelToParse = Console.ReadLine();
            //level = (Level)Enum.Parse(typeof(Level), levelToParse);
            //Console.WriteLine(level);
            //Console.WriteLine(level);

            //switch (level)
            //{
            //    case Level.Beginer:
            //        Console.WriteLine("Hurry to learn");
            //        break;
            //    case Level.Intermediate:
            //        Console.WriteLine("Good");
            //        break;
            //    case Level.Advanced:
            //        Console.WriteLine("Don't lie");
            //        break;
            //} 
            #endregion

            string color = Console.ReadLine();
            ConsoleColor console = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
            try
            {
                Console.ForegroundColor = console;
            }
            catch { };

            var colors = Enum.GetValues(typeof(ConsoleColor));

            //foreach(var item in colors)
            foreach(ConsoleColor item in colors)
            {
                //Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), item);
                Console.ForegroundColor = item;
                Console.WriteLine(item);
            }
        }
    }
}
