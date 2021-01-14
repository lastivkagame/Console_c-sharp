using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    class Program
    {
        static void Main()
        {

            #region Task_1
            /*Задание 1. Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка. 
                    Программа должна сосчитать количество введенных пользователем пробелов. */
            //Task1(); 
            #endregion

            #region Task_2
            /*Задание 2. Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить
                 является ли данный билет счастливым (если на билете напечатано шестизначное число,
                 и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым).*/
            //Task2(); 
            #endregion

            #region Task_3
            /*Задание 3. Числовые значения символов нижнего регистра в коде ASCII отличаются 
                 от значений символов верхнего регистра на величину 32. Используя эту  информацию,
                 написать программу, которая считывает с клавиатуры и конвертирует все символы
                 нижнего регистра в символы верхнего регистра и наоборот.*/
            //Task_3(); 
            #endregion

            #region Task_4
            /*Задание 4.  Даны целые положительные числа A и B (A < B).Вывести все целые числа от A до B включительно; 
                 каждое число должно выводиться на новой строке; при этом каждое число должно выводиться количество раз,
                 равное его значению. Например: если А = 3, а В = 7, то программа должна сформировать в консоли
                 следующий вывод:
                 3 3 3
                 4 4 4 4
                 5 5 5 5 5
                 6 6 6 6 6 6
                 7 7 7 7 7 7 7*/

            //Task_4();
            #endregion

            #region Task_5
            /*Задание 5.  Дано целое число N (> 0), найти число, полученное при прочтении числа N справа налево.
                 Например, если было введено число 345,  то  программа должна вывести число 543.*/

            //Task_5();
            #endregion
        }

        static void Task1()
        {
            Console.Write("Enter some symbols: ");

            char input;
            int spaceCount = 0;

            do
            {
                input = Console.ReadKey().KeyChar;

                /*ReadKey () - використовується для отримання наступного символу або функціональної клавіші,
                 натиснутого користувачем. Натиснута клавіша відобразиться на консолі. KeyChar повертає 
                 символ Unicode, представлений поточною системою 
                 -https://docs.microsoft.com/ru-ru/dotnet/api/system.consolekeyinfo.keychar?view=netframework-4.8*/

                if (input == ' ')
                {
                    spaceCount++;
                }
            }
            while (input != '.');

            Console.WriteLine("\nQuantity of spaces: " + spaceCount);
        }
        static void Task2()
        {
            string ticket;
            bool isdigit = true;
            int begin = 0, end = 0;

            Console.Write("Enter number ticket: ");
            ticket = Console.ReadLine();

            if (ticket.Length == 6)
            {
                for (int i = 0; i < ticket.Length; i++)
                {
                    isdigit = Char.IsDigit(ticket[i]);

                    if (isdigit == false)
                    {
                        break;
                    }
                }

                if (isdigit == true)
                {
                    for (int i = 0; i < ticket.Length; i++)
                    {
                        if (i < 3)
                        {
                            begin += ticket[i];
                        }
                        else
                        {
                            end += ticket[i];
                        }
                    }

                    if (begin == end)
                    {
                        Console.WriteLine("This is ticket is happy!!!");
                    }
                    else
                    {
                        Console.WriteLine("This ticket is not happy.");
                    }
                }
                else
                {
                    Console.WriteLine("Inccorect you enter some letter. You must enter only digits");
                }
            }
            else
            {
                Console.WriteLine("Inccorect direction! You enter more or less than 6 length ");
            }
        }
        static void Task_3()
        {
            bool isNeed = false;
            Console.Write("Enter something: ");
            string symbol = Console.ReadLine();
            string resalt = "";

            for (int i = 0; i < symbol.Length; i++)
            {
                var symbolChar = Convert.ToInt32(symbol[i]);

                if (symbol[i] >= 65 && symbol[i] <= 90)
                {
                    symbolChar += 32;
                    isNeed = true;
                }
                else if (symbol[i] >= 97 && symbol[i] <= 122)
                {
                    symbolChar -= 32;
                    isNeed = true;
                }

                resalt += Convert.ToString(Convert.ToChar(symbolChar));
            }

            Console.WriteLine("Rezalt: " + resalt);
        }
        static void Task_4()
        {
            int A = 0, B = 0;

            try
            {
                Console.Write("Enter number A: ");
                A = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Enter number B: ");
                B = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (A < B && A > 0 && B > 0)
            {
                for (int i = A; i <= B; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        Console.Write(" " + i);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Inccorect direction!");
            }
        }
        static void Task_5()
        {
            int N = 0;

            try
            {
                Console.Write("Enter number N: ");
                N = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (N < 0)
            {
                Console.WriteLine("Inccorect direction!");
            }
            else
            {
                bool isnumber = true;

                string number = N.ToString();

                for (int i = 0; i < number.Length; i++)
                {
                    isnumber = Char.IsDigit(number[i]);

                    if (isnumber == false)
                    {
                        break;
                    }
                }

                if (isnumber == true)
                {
                    Console.Write("Resalt: ");
                    for (int i = number.Length - 1; i >= 0; i--)
                    {
                        Console.Write(number[i]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
