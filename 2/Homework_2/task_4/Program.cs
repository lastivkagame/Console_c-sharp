/*4. Визначити суму елементів, розміщених між максимальним та мінімальним елементом масиву.
Користуватися методами (Max, Min, IndexOf)*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size: ");
            int[] arr = new int[Convert.ToInt32(Console.ReadLine())];
            FillRandArr(arr);
            PrintArr(arr);
            int sum = 0;

            Console.WriteLine();
            Console.WriteLine("Min: " + arr.Min());
            Console.WriteLine("Max: " + arr.Max());
            Console.WriteLine();

            if (Array.IndexOf(arr, arr.Min()) < Array.IndexOf(arr, arr.Max()))
            {
                for (int i = Array.IndexOf(arr, arr.Min()) + 1; i < Array.IndexOf(arr, arr.Max()); i++)
                {
                    sum += arr[i];
                }
            }
            else
            {
                for (int i = Array.IndexOf(arr, arr.Max()) + 1; i < Array.IndexOf(arr, arr.Min()); i++)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine("Sum(numbers begin min to max): " + sum + "\n");
        }

        static void FillRandArr(int[] arr, int left = 0, int right = 100)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(left, right);
            }
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine(" --- Array --- ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
