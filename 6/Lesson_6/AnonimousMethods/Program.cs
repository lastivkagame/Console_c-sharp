using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonimousMethods
{
    class Program
    {
        delegate int CalcDeleg(int a);
        delegate double CalcAverangeDeleg(params int[] a);
        delegate int Transformer(ref int a);
        static void Main(string[] args)
        {
            // анонімний метод
            CalcDeleg sqr = delegate (int x)
            {
                return x * x;
            };

            Console.WriteLine("sqr(10) = " + sqr(10));

            CalcDeleg cube = delegate (int x)
            {
                return sqr(x) * x;
            };

            Console.WriteLine("cube(5) = " + cube(5));

            int number = 100;
            CalcDeleg test = delegate (int x)
            {
                return number + x;
            };

            Console.WriteLine("test(5) = " + test(5));

            number++;

            CalcDeleg deleg = delegate{ return number; };  // якщо параметр не використовується можна опустити

            Console.WriteLine("deleg = " + deleg(0));

            CalcAverangeDeleg avg = delegate (int[] a)
            {
                double avgTemp = a.Average();
                return avgTemp;
            };

            Console.WriteLine("Average = " + avg(1, 2, 3, 4, 5));

            Transformer t = (ref int a) => a--;
            Console.WriteLine("transformer -- = " + t(ref number) + " ---- > " + number);
        }
    }
}
