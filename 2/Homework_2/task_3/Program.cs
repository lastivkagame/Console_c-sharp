/*3. Вводиться число. Масив заповнити вип. числами. Знайти кількість входжень у масив введеного числа.
Використання методів класу Array надає додатковий бал.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" --- Array --- ");
            Console.Write("Enter size: ");
            int[] arr = new int[Convert.ToInt32(Console.ReadLine())];
            FillRandArr(arr);
            PrintArr(arr);
            Console.Write("Enter number that you want find: ");
            int number = Convert.ToInt32(Console.ReadLine());
            bool flag = true;

            if (Array.Find(arr, (int x) => { return x == number; }) == 0)
            {
                if (number != 0)
                {
                    Console.WriteLine("Number that you searched for NOT exist at this array");
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == number)
                        {
                            Console.WriteLine("Number that you searched for is exist at this array");
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                    {
                        Console.WriteLine("Number that you searched for NOT exist at this array");
                    }
                }
            }
            else
            {
                Console.WriteLine("Number that you searched for is exist at this array");
            }
        }

        static void FillRandArr(int[] arr, int left = -10, int right = 20)
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
