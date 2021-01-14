using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static class Sumator
        {
            public static int Sum(int a, int b)
            {
                Console.WriteLine("works int Sum(int a, int b)");
                return a + b;
            }

            public static int Sum(params int[] args) // params - довільна к-сть аргументів в нашому випадку int
            {
                Console.WriteLine("int Sum(params int[] args)");
                int suma = 0;
                foreach (var item in args)
                {
                    suma += item;
                }
                return suma;
            }
        }
        static void Main(string[] args)
        {
            //ref and out
            int value = 19;
            Inc(ref value);
            Console.WriteLine(value + " in main");

            //int mod, div;
            DivAndMod(17, 3, out int div, out int mod);
            //Console.WriteLine("Div: " + div);
            //Console.WriteLine("Mod: " + mod);
            Console.WriteLine($"Resalt DivAndMod (17,3): Div = {div} \t Mod = {mod}");

            Console.Clear();
            Console.WriteLine("Test params");
            Console.WriteLine("1) " + Sumator.Sum(1, 6));
            Console.WriteLine("2) " + Sumator.Sum(1, 2, 9, 5, -6));
            int[] arr = { 6, 8, 1, 90 };
            Console.WriteLine("3) " + Sumator.Sum(arr));
            Console.WriteLine("3) " + Sumator.Sum(new[] { 90, 10, 30, 40, -50 }));
        }
        static void Inc(ref int value) //int  - value type
        {
            Console.WriteLine($"Inc try to increment value {value}");
            Console.WriteLine($"in Inc() value = {++value}");
        }

        static void DivAndMod(int value1, int value2, out int resultDiv, out int resultMod)
        {
            resultDiv = value1 / value2;
            resultMod = value1 % value2;
        }
    }
}
