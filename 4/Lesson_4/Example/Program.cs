using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        struct Any //value type
        {
            public int value;
        }

        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3 }, arr2 = { 1, 2, 3 }; //ref type
            int[] arr3 = arr1; //?
            Console.WriteLine("Test Arrays");
            Console.WriteLine($"Reference equels(arr1,arr2) = {object.ReferenceEquals(arr1, arr2)}");//false
            Console.WriteLine($"Equels(arr1,arr2) = {object.Equals(arr1, arr2)}"); //true - I want but will be false becouse po referense

            Console.WriteLine();
            Console.WriteLine($"Reference equels(arr1,arr3) = {object.ReferenceEquals(arr1, arr3)}");//true
            Console.WriteLine($"Equels(arr1,arr3) = {object.Equals(arr1, arr3)}");//true

            Console.WriteLine();
            int first = 11, second = 11;
            Console.WriteLine($"Reference equels(arr1,arr3) = {ReferenceEquals(first, second)}");//false
            Console.WriteLine($"Equels(arr1,arr3) = {Equals(first, second)}");//true
            Console.WriteLine();

            Any any1 = new Any() { value = 100 },
                any2 = new Any();
            any2.value = any1.value;

            Console.WriteLine($"Reference equels(any1,any2) = {ReferenceEquals(any1, any2)}");//false
            Console.WriteLine($"Equels(any1,any2) = {Equals(any1, any2)}");//true
        }
    }
}
