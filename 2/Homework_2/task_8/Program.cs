/*----------------C# Методи --------------------------------
8. Визначити метод для обміну значень двох змінних однакового типу(Swap)
9. Визначити метод для знаходження у одновимірному масиву максимального та мінімального. 
    Метод повинен повертати ці значення через свої параметри. 
    void MaxMin(int [] arr, .... int max, .... int min)*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region task_8
            Console.Write("Enter number 1: ");
            StringBuilder str1 = new StringBuilder(Console.ReadLine());
            Console.Write("Enter number 2: ");
            StringBuilder str2 = new StringBuilder(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Number 1: " + str1);
            Console.WriteLine("Number 2: " + str2);

            Console.WriteLine();
            Console.WriteLine(" --- After Swap --- ");
            Swap(ref str1, ref str2);
            Console.WriteLine("Number 1: " + str1);
            Console.WriteLine("Number 2: " + str2);
            #endregion

            #region task_9
            Console.WriteLine();
            Console.Write("Enter size: ");
            int[] arr = new int[Convert.ToInt32(Console.ReadLine())];
            FillRandArr(arr);
            PrintArr(arr);

            MaxMin(arr, out int max, out int min);
            Console.WriteLine();
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine();
            #endregion
        }

        static void Swap(ref StringBuilder num1, ref StringBuilder num2)
        {
            StringBuilder temp;
            temp = num2;
            num2 = num1;
            num1 = temp;
        }

        static void MaxMin(int[] arr, out int max, out int min)
        {
            max = arr.Max();
            min = arr.Min();
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine(" --- Array --- ");
            foreach (var item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

        static void FillRandArr(int[] arr, int left = 0, int right = 100)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(left, right);
            }
        }
    }
}
