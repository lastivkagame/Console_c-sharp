using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_STD
{
    class Program
    {
        //Action - delegate void Action<T>(до 16 параметрів)
        //Func   - delegate T_out Func<T_in, T_result>(до 16 параметрів) 
        //Predicate - delegate bool Predicate()

        // відповідає сигнатурі Action
        static void PrintSquare(int a)
        {
            Console.WriteLine("Square = {0}", a * a);
        }

        static void PrintCube(int a)
        {
            Console.WriteLine("Cube = {0}", a * a * a);
        }

        static void PrintValue<T>(int a)
        {
            Console.WriteLine("Value = {0}", a);
        }

        // відповідає сигнатурі Func
        static int CountDigits(string str)
        {
            return str.Count(c => char.IsDigit(c));
        }

        // відповідає сигнатурі Func
        static int CountVowers(string str)
        {
            return str.Count(c => c == 'o' || c == 'a' || c == 'e' || c == 'i');
        }
        static void Main(string[] args)
        {
            #region Action
            //Action<int> action = PrintSquare;
            //action(5);

            //Action<int>[] arrayAction = { PrintCube, PrintSquare, PrintValue<int> };

            //foreach (var item in arrayAction)
            //{
            //    item(5);
            //} 
            #endregion

            #region Func
            //Func<string, int> func = CountDigits;
            //int result = func("Hello 12 bye 34");
            //Console.WriteLine("digits = " + result);

            //func += CountVowers;
            //Console.WriteLine("Wovels: " + func("Hello world"));

            //Func<int, int, double> func2 = (x, y) => (x + y) / 2.0;
            //Console.WriteLine("Func2 = " + func2(2, 5)); 
            #endregion
        }
    }
}
