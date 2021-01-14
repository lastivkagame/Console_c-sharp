/*7.Створити статичні методи для роботи з рваним 2-вимірним масивом(масив масивів).
	- заповненнЯ масиву випадковими числами
	- вивід  на екран
	- циклічний зсув рядків матриці вверх на певну кількість рядків
	- циклічний зсув рядків матриці вниз на певну кількість рядків*/

using System;

namespace task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size: ");
            int[][] jugged = new int[Convert.ToInt32(Console.ReadLine())][]; //рваний масив = масив масивів

            FillJugged(jugged);
            PrintJugged(jugged);

            Console.WriteLine(" --- After we use ShiftRowsUp used 2 times---");
            ShiftRowsUp(ref jugged, 2); //Зміщення рядків вгору
            PrintJugged(jugged);

            Console.WriteLine(" --- After we use ShiftRowsDown used 1 times ---");
            ShiftRowsDown(ref jugged, 1);  //Зміщення рядків вниз
            PrintJugged(jugged);
        }

        static void FillJugged(int[][] jugged, int min = 0, int max = 10)
        {
            Random random = new Random();

            for (int i = 0; i < jugged.Length; i++)
            {
                jugged[i] = new int[i + 1];
                for (int j = 0; j < jugged[i].Length; j++)
                {
                    jugged[i][j] = random.Next(min, max);
                }
            }
        }

        static void PrintJugged(int[][] arr)
        {
            Console.WriteLine(" --- Jugged --- ");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{ arr[i][j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ShiftRowsUp(ref int[][] jugged, int count)
        {
            for (int k = 0; k < count; k++)
            {
                int[][] temp = new int[jugged.Length][];
                temp[jugged.Length - 1] = jugged[0];

                for (int i = 0; i < jugged.Length - 1; i++)
                {
                    temp[i] = jugged[i + 1];
                }
                jugged = temp;
            }
        }

        static void ShiftRowsDown(ref int[][] jugged, int count)
        {
            for (int k = 0; k < count; k++)
            {
                int[][] temp = new int[jugged.Length][];
                temp[0] = jugged[jugged.Length - 1];

                for (int i = 1; i < jugged.Length; i++)
                {
                    temp[i] = jugged[i - 1];
                }
                jugged = temp;
            }
        }
    }
}
