/*5. Знайти суму парних елементів цілочислового масиву, кількість одноцифрових елементів масиву. 
Для обробки не користуватися звичайними циклами(спробувати  щось із ForEach,  лямбда, Count).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size: ");
            int[] arr = new int[Convert.ToInt32(Console.ReadLine())];
            int sum = 0;
            FillRandArr(arr, -10, 30);
            PrintArr(arr);

            foreach (var item in arr)
            {
                if (item % 2 == 0)
                {
                    sum += item;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sum of pair elements: " + sum);
            Console.WriteLine("Count one digit elements: " + arr.Count((int x) => { return (x / 10) <= 0; }));
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
