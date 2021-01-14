/*-------------Одновимірні масиви C #---------------------------------------------
  1. Визначити методи для роботи з одновимірним цілочисловим масивом
     - створення масиву int [] CreateArr(int size)
     - заповнення масиву вип числами void FillRandArr(int [] arr, intl left = 0, int right = 100) 
     - вивід елементів масиву на екран
     - поміняти місцями елементи перший з другим, третій з четвертим і т.д.
     - метод повертає кількість додатних елементів масиву(використати Array.FindAll())
     - метод повертає кількість парних  елементів масиву(використати Count())
     - знайти індекс першого кратного 7(якщо таке є) (IndexOf)*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" --- Array --- ");
            Console.Write("Enter size: ");
            int[] arr = CreateArr(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Enter min element: ");
            int min = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter max element: ");
            int max = Convert.ToInt32(Console.ReadLine());

            FillRandArr(arr, min, max);
            PrintArr(arr);

            ChangeElemPlaces(arr);
            PrintArr(arr);
            Console.WriteLine();

            Console.WriteLine("Count Positive Element: " + CountPositiveElem(arr));
            Console.WriteLine("Count Pair Element: " + CountPairElem(arr));
            Console.WriteLine("Index Element: " + IndexElem(arr));
        }
        static int[] CreateArr(int size)
        {
            if (size > 0)
            {
                int[] arr = new int[size];
                return arr;
            }
            else
            {
                int[] arr = new int[2];
                return arr;
            }
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

        static void ChangeElemPlaces(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i += 2)
            {
                temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }

        static int CountPositiveElem(int[] arr)
        {
            int[] plus = Array.FindAll(arr, x => x > 0);
            return plus.Length;
        }

        static int CountPairElem(int[] arr)
        {
            return arr.Count(x => x % 2 == 0);
        }

        static int IndexElem(int[] arr)
        {
            return Array.IndexOf(arr, Array.Find(arr, x => x % 7 == 0));
        }
    }
}
