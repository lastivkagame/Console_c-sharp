using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        delegate double DelCal(double first, double second); // тип делегата, такого типу делегати можуть посилатись
                                                             // на метод відповідної сигнатури
        class Calc
        {
            double number;

            public Calc(double num)
            {
                number = num;
            }

            public static double Add(double a, double b)
            {
                return a + b;
            }

            public static double Sub(double a, double b)
            {
                return a - b;
            }

            public double Mult(double a, double b)
            {
                return a * b;
            }

            public double Div(double a, double b)
            {
                return a / b;
            }
        }
        static void Main(string[] args)
        {
            DelCal d1 = new DelCal(Calc.Add);//створила екземпляр делегата? який посилається на статичний метод класа Calc

            Console.WriteLine("d1 = Calc.Add(23,1)= {0}", d1(23, 1));
            Console.WriteLine($"Method name: { d1.Method.Name} \n Target name: {d1.Target}");// Target = null - бо метод статичний
            Console.WriteLine();

            d1 = Calc.Sub;

            Console.WriteLine();
            Console.WriteLine("d1 = Calc.Sub(23,1)= {0}", d1.Invoke(23, 1));
            Console.WriteLine($"Method name: { d1.Method.Name} \n Target name: {d1.Target}");

            Calc calc = new Calc(10);
            d1 = calc.Mult;

            Console.WriteLine();
            Console.WriteLine("d1 = Calc.Mult(23,1)= {0}", d1(3, 4));
            Console.WriteLine($"Method name: { d1.Method.Name} \n Target name: {d1.Target}");

            DelCal d2 = new DelCal(Calc.Add);
            if (d2 != null)
                Console.WriteLine(d2(3, 5));

            Console.WriteLine(d2?.Invoke(3, 5));
        }
    }
}
