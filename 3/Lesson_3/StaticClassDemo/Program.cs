using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassDemo
{
    /*static*/
    class StaticDemo // не можна створити обєкт класу
    {
        static int number = 0;
        static int count;
        int number2;

        static StaticDemo()
        {
            count = 0;
        }

        public StaticDemo(int number = 200)  //member of class
        { 
            number2 = number;
        }

        public static int Action(int val)
        {
            count++;
            return number * val;
        }

        public static int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public static int Count
        {
            get
            {
                return count;
            }
        }

        public override string ToString()
        {
            return number2.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StaticDemo sd = new StaticDemo();

            Console.WriteLine(sd);

            StaticDemo.Number = 1000;

            int res = StaticDemo.Action(5);
            Console.WriteLine("Action() res = " + res);
            Console.WriteLine("Count: " + StaticDemo.Count);
        }
    }
}
