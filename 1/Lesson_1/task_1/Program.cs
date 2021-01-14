using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {
        static void Main(/*string[] args*/)
        {
            #region nulleable
            // -nulleable-
            //int? temp = null;
            //Console.WriteLine(temp);
            //Console.WriteLine(temp ?? 50); //if temp = null to print 50 else print temp
            //Console.WriteLine(temp);

            //temp = temp ?? 50; //50
            //Console.WriteLine(temp);
            //temp = temp ?? -30; //50
            //Console.WriteLine(temp);
            //Nullable<int> str = null;

            #endregion

            #region task_1
            /* Даны целые положительные числа A, B, C.
             Значение этих чисел программа должна запрашивать у пользователя.
             На прямоугольнике размера A*B размещено максимально возможное 
             количество квадратов со стороной C. Квадраты не накладываются друг на друга.
             Найти количество квадратов, размещенных на прямоугольнике, а также площадь
             незанятой части прямоугольника. Необходимо предусмотреть служебные сообщения
             в случае, если в прямоугольнике нельзя разместить ни одного квадрата со 
             стороной С (например, если значение С превышает размер сторон прямоугольника).*/

            double A = 0, B = 0, C = 0;

            try
            {
                Console.Write("Enter number A: ");
                A = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Enter number B: ");
                B = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Enter number C: ");
                C = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (A <= 0 || B <= 0 || C < 0)
            {
                Console.WriteLine("Inccorect direction!(A < 0 || B < 0 || C < 0)");
            }
            else if (C > A && C > B)
            {
                Console.WriteLine("Inccorect direction! (C>A  && C > B)");
            }
            else
            {
                double allsquare = A * B;
                double Csquare = C * C;

                double resalt = Math.Ceiling(Convert.ToInt32(allsquare / Csquare));
                Console.WriteLine("Rectangle can include: " + resalt);
                double freeArea = (allsquare - (Csquare * resalt));
                Console.WriteLine("Free area: " + freeArea);
            }

            #endregion

            #region task_2
            /*2. Начальный вклад в банке равен 10000 грн. 
                Через каждый месяц размер вклада увеличивается на P
                процентов от имеющейся суммы (P — вещественное
                число, 0 < P < 25). Значение Р программа должна получать у пользователя.
                По данному P определить через сколько месяцев размер вклада превысит 11000 грн.,
                и вывести найденное количество месяцев K (целое
                число) и итоговый размер вклада S (вещественное число).*/

            double beginSum = 10000, P = 0, max = 11000, finalSum = 10000;
            int K = 0;

            try
            {
                Console.Write("Enter procent P: ");
                P = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (P < 0 || P > 25)
            {
                Console.WriteLine("Inccorect P!");
            }
            else
            {
                do
                {
                    K++;
                    finalSum += ((finalSum / 100) * P);
                } while (finalSum < max);

                Console.WriteLine("Final Sum: " + finalSum);
                Console.WriteLine("Month: " + K);
            }

            #endregion

            #region task_3
            /*3. Даны целые положительные числа A и B (A < B). 
             Вывести все целые числа от A до B включительно; 
             каждое число должно выводиться на новой строке; 
             при этом каждое число должно выводиться количество раз,
             равное его значению (например, число 3 выводится 3 раза). 
             Например: если А = 3, а В = 7, то программа должна 
             сформировать в консоли следующий вывод:
                 3 3 3
                 4 4 4 4
                 5 5 5 5 5
                 6 6 6 6 6 6
                 7 7 7 7 7 7 7 */

            //int A = 0, B = 0;

            //try
            //{
            //    Console.Write("Enter number A: ");
            //    A = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    Console.Write("Enter number B: ");
            //    B = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (A < B && A > 0 && B > 0) 
            //{
            //    for (int i = A; i <= B; i++)
            //    {
            //        for (var j = 0; j < i; j++)
            //        {
            //            Console.Write(i);
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Inccorect direction!");
            //}

            #endregion

            #region task_4
            /*4. Дано целое число N большее 0, найти число, полученное
             при прочтении числа N справа налево. Например,
             если было введено число 345, то программа должна вывести число 543*/

            //int N = 0;

            //try
            //{
            //    Console.Write("Enter number N: ");
            //    N = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (N < 0)
            //{
            //    Console.WriteLine("Inccorect direction!");
            //}
            //else
            //{
            //    int digit = 0, temp = N;

            //    while (temp > 0)
            //    {
            //        temp /= 10;
            //        digit++;
            //    }


            //    int r;

            //    //for (int i = digit; i > 0; i++)
            //    //{
            //    //    r = N / 10;
            //    //    Console.WriteLine(r);
            //    //}

            //    //v -1
            //    //int arr[digit]; //спитати
            //    string ready = Convert.ToString(N);
            //    var ready2 = (ready.Reverse());//спитати

            //    string str = new string(ready2.ToArray());
            //    Console.WriteLine("ready: " + str);

            //    //for (int i = digit; i > 0; i--)
            //    //{
            //    //    Console.Write(ready[i]);
            //    //}

            //    //v2
            //    //

            //    //Console.Write(" Your digit navpaku: " + ready2);
            //    //foreach (var i in ready)
            //    //{
            //    //    Console.Write(i);
            //    //}
            //    Console.WriteLine();

            //    //for (int i = digit;i > 0; i--)
            //    ////foreach(var i in ready)
            //    //{
            //    //    ready[i] = Convert.ToString(N);
            //    //    N /= 10;
            //    //}


            //}

            #endregion
        }
    }
}
