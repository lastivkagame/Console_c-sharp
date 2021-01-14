/*2. Перерозташувати елементи у масиві( відємні, невідємні).
 Використання методів класу Array надає додатковий бал.
 1 2 -4 -6 -7 10 100
 -4 -6 -7   1 2 10 100*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size: ");
            int[] arr = new int[Convert.ToInt32(Console.ReadLine())];

            FillRandArr(arr);
            PrintArr(arr);
            ArrayChangePlace(arr);
            PrintArr(arr);
        }

        static void ArrayChangePlace(int[] arr)
        {
            Array.Sort(arr);
            int[] countMinusNum = Array.FindAll(arr, (int x) => { return x < 0; });
            Array.Reverse(arr, 0, countMinusNum.Length);
        }

        static void FillRandArr(int[] arr, int left = -50, int right = 50)
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
