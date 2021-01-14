using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAsParam
{
    class Program
    {
        delegate void Transformer(ref int value);
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 6, 2, 8, 3, 12 };
            Console.WriteLine("Array");
            Print(arr);

            Console.WriteLine("Change Array by Inc");
            ChangeArray(arr, Inc);
            Print(arr);

            Console.WriteLine("Change Array by Mult");
            ChangeArray(arr, Mult);
            Print(arr);

            Console.WriteLine("Change Array by Mult");
            ChangeArray(arr, new Transformer(Mult));
            ChangeArray(arr, Mult);
            Print(arr);

            Console.WriteLine("Change Array by Lamda");
            ChangeArray(arr, (ref int x) => x = x * x);
            Print(arr);
        }

        static void ChangeArray(int []arr, Transformer method)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                method(ref arr[i]);
            }
        }

        static void Inc(ref int value)
        {
            value++;
        }

        static void Mult(ref int value)
        {
            value *= 2;
        }

        static void Print(int [] arr)
        {
            //Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine("\n");
        }
    }
}
