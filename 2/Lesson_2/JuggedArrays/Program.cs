using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            Random random = new Random();
            int[][] jugged = new int[rows][]; //рваний масив = масив масивів

            for (int i = 0; i < jugged.Length; i++)
            {
                jugged[i] = new int[i + 1];
                for (int j = 0; j < jugged[i].Length; j++)
                {
                    jugged[i][j] = random.Next(-20, 20);
                }
            }
            PrintJugged(jugged);

            sortJugged(jugged);

            Console.WriteLine();
            PrintMinElements(jugged);
            Console.WriteLine();
            PrintMaxElements(jugged);
            Console.WriteLine();
            PrintAverageElements(jugged);
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Enter first: ");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Second: ");
            int second = Convert.ToInt32(Console.ReadLine());

            ChangeStringPlace(jugged, first, second);
        }

        private static void ChangeStringPlace(int[][] jugged, int first, int second)
        {
            if (first >= 0 && first < jugged.Length && first < second && second >= 0 && second < jugged.Length)
            {
                int[] beginArr;
                int[] endArr;

                beginArr = jugged[first];
                endArr = jugged[second];

                jugged[second] = beginArr;
                jugged[first] = endArr;

                Console.WriteLine();
                Console.WriteLine("After change string to other places: ");
                PrintJugged(jugged);
            }
            else
            {
                Console.WriteLine("Inccorect");
            }
        }

        private static void PrintAverageElements(int[][] jugged)
        {
            Console.WriteLine("Average El-s:");
            for (int i = 0; i < jugged.Length; i++)
            {
                Console.Write(jugged[i].Average() + "\t");  //коден рядок рваного масиву - це одновимірний масив, застосов стат метод Sоrt класу
            }
            Console.WriteLine();
        }

        private static void PrintMaxElements(int[][] jugged)
        {
            Console.WriteLine("Max El-s:");
            for (int i = 0; i < jugged.Length; i++)
            {
                Console.Write(jugged[i].Max() + "\t");  //коден рядок рваного масиву - це одновимірний масив, застосов стат метод Sоrt класу
            }
            Console.WriteLine();
        }

        private static void PrintMinElements(int[][] jugged)
        {
            Console.WriteLine("Min El-s:");
            for (int i = 0; i < jugged.Length; i++)
            {
                Console.Write(jugged[i].Min() + "\t");  //коден рядок рваного масиву - це одновимірний масив, застосов стат метод Sоrt класу
            }                             //Array для
            Console.WriteLine();
        }

        private static void sortJugged(int[][] jugged)
        {
            Console.WriteLine();
            for (int i = 0; i < jugged.Length; i++)
            {
                Array.Sort(jugged[i]);  //коден рядок рваного масиву - це одновимірний масив, застосов стат метод Sоrt класу
            }                             //Array для
            PrintJugged(jugged);
        }

        static void PrintJugged(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{ arr[i][j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}
