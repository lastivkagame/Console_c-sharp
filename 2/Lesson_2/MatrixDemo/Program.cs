using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rov x col: ");
            int row = Int32.Parse(Console.ReadLine());
            int col = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[row, col];

            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-99, 100);
                }
            }

            Console.WriteLine("Your 2d array: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4 }");
                }
                Console.WriteLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine($"{ item,-5}");
            }

            Console.WriteLine();
            Console.WriteLine("Rank matrix: " + matrix.Rank);
            Console.WriteLine("Length: " + matrix.Length);

            Console.WriteLine("_______Test 3d arrays_______");
            int[,,] array3d = new int[3, 2, 2]
            {
                {{9,5 },{78,3 } },
                {{ 12,43},{ -67,54} },
                {{14,41 },{89, 73 } }
            };

            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        Console.Write($"{array3d[i, j, k],5}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Rank matrix: " + array3d.Rank);
            Console.WriteLine("Length: " + array3d.Length);
        }//main
    }//class
}//namespace
