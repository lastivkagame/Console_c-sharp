/*6. Cтворити статичні методи  для роботи з прямокутною двовимірною матрицею.
	- заповнення матриці випадковими числами
	- вивід матриці на  екран
	- обмін місцями двох колонок матриці(номери колонок передаються як параметри у метод) 
	- створення матриці, транспонованої до даної(рядки матриці стають колонками у транспонованій матриці, тобто
		1-й рядок матриці записується як перша колонка трансп. матриці
		2-й рядок матриці записується як друга колонка трансп. матриці

Перевірити роботу методів  у методі Main()*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //1,2 - створення, заповнення, вивід
            Console.Write("Enter row x col: ");
            int row = Int32.Parse(Console.ReadLine());
            int col = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[row, col];
            FillMatrixRand(matrix, -10, 20);
            PrintMatrix(matrix);
            Console.WriteLine();

            //3 - змінна 2 колон місцями
            Console.Write("Enter col_1 x col_2 that you want chage: ");
            ChangeColumnPlaces(matrix, Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();

            //4 - рядки стануть колонами, а колони рядками
            Console.WriteLine(" -After we do columns -> rows and rows -> columns-");
            DoColumnToRows(ref matrix);
            PrintMatrix(matrix);
        }

        static void FillMatrixRand(int[,] matrix, int min = 0, int max = 10)
        {
            Random random = new Random();
            int temp;

            if (min > max)
            {
                temp = min;
                min = max;
                max = temp;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max);
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("\t --- Matrix --- ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],7 }");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ChangeColumnPlaces(int[,] matrix, int col1, int col2)
        {
            int temp;

            if (col1 <= 0 || col1 > matrix.GetLength(1))
            {
                col1 = 1;
                Console.WriteLine("You entered inccorect col1 -> I do that col1 = 1");
            }

            if (col2 <= 0 || col2 > matrix.GetLength(1))
            {
                col2 = matrix.GetLength(0);
                Console.WriteLine("You entered inccorect col2 -> I do that col2 = last column");
            }

            if (col1 > col2)
            {
                temp = col1;
                col1 = col2;
                col2 = temp;
                Console.WriteLine("Inccorect, so temp = col1, col1 = col2, col2 = temp");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                temp = matrix[i, col1 - 1];
                matrix[i, col1 - 1] = matrix[i, col2 - 1];
                matrix[i, col2 - 1] = temp;
            }
        }

        static void DoColumnToRows(ref int[,] matrix)
        {
            int[,] temp = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[j, i] = matrix[i, j];
                }
            }

            matrix = temp;
        }
    }
}
