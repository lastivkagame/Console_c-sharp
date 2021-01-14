/*  Завдання 3.
 Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках). 
 Для классареализовать перегрузку операторов
        + (сложение денежных сумм),
        –(вычитаниесумм),
        / (деление суммы на целоечисло),
        (умножение суммы на целое число),
        ++ (суммаувеличивается на 1 копейку),
        --(сумма уменьшается на1 копейку),
        <, >, ==, !=.
Класс не может содержать отрицательную сумму.В случае если при исполнении какой-либо операции 
получается отрицательная сумма денег, то класс генерируетисключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money. 
Обработка исключительных ситуаций производится в программе.*/

using System;
using System.Threading;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);

            Console.Clear();

            double beginsum = 0;

            do
            {
                try
                {
                    Console.Write("Enter begin sum(sum must be more than 0): ");
                    beginsum = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Clear();
            } while (beginsum <= 0);

            Money mymoney = new Money(beginsum);

            bool flag = true;
            string[] menu = { "-Menu-", "ShowCountMoney", " + (add sum)", " - (sub sum)", " * (mult sum)",
                " / (div sum)", " == or != (compare sum)", " ++ (inc sum)", " -- (dec sum)", " is sum 0", "Exit" };

            do
            {
                Console.Clear();
                Console.WriteLine("\t ---Your Money---");

                foreach (string t in menu) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(menu); //виклик менюшки 

                switch (num)
                {
                    case 1: //ShowCountMoney
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #1: ShowCountMoney <-\n");

                            Console.WriteLine("You have: " + mymoney);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 2: // + (add sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #2:  + (add sum) <-\n");

                            double sum;

                            try
                            {
                                Console.Write("Enter sum: ");
                                sum = Convert.ToDouble(Console.ReadLine());
                                mymoney += sum;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: // - (sub sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #3: - (sub sum) <-\n");

                            double sum;

                            try
                            {
                                Console.Write("Enter sum: ");
                                sum = Convert.ToDouble(Console.ReadLine());
                                mymoney -= sum;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: // * (mult sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #4: * (mult sum) <-\n");

                            int sum;

                            try
                            {
                                Console.Write("Enter sum: ");
                                sum = Convert.ToInt32(Console.ReadLine());
                                mymoney *= sum;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 5: // / (div sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #5: / (div sum) <-\n");

                            int sum;

                            try
                            {
                                Console.Write("Enter sum: ");
                                sum = Convert.ToInt32(Console.ReadLine());
                                mymoney /= sum;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (DivideByZeroException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 6: // == or != (compare sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #6:  == or != (compare sum) <-\n");

                            double sum;

                            try
                            {
                                Console.Write("Enter sum: ");
                                sum = Convert.ToInt32(Console.ReadLine());

                                if (mymoney == new Money(sum))
                                {
                                    Console.WriteLine("sums are equal");
                                }
                                else
                                {
                                    Console.WriteLine("sums are no equal");
                                }
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 7: // ++ (inc sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #7: ++ (inc sum) <-\n");

                            try
                            {
                                mymoney++;
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 8: // -- (dec sum)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #8: -- (dec sum) <-\n");

                            try
                            {
                                mymoney--;
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 9: // is sum 0
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Your Money---");
                            Console.WriteLine("\n -> Section #8: -- (dec sum) <-\n");

                            try
                            {
                                if (mymoney)
                                {
                                    Console.WriteLine("sum is not 0");
                                }
                                else
                                {
                                    Console.WriteLine("sum is 0");
                                }
                            }
                            catch (ExceptionBankruptcy ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine("Opertion end");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 10: //exit
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\tHave a nice day!\t\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(4000);
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }
            } while (flag);
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t ---Your Money---");
            Console.WriteLine("  " + texts[0]);

            for (int j = 1; j < texts.Length; j++)
            {
                if (j == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> " + texts[j] + " <");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  " + texts[j]);
                }
            }
        }
        static int keys(string[] texts) //робота менюшки
        {
            int num = 0;
            int max = texts.Length;
            bool flag = false;
            do
            {
                ConsoleKeyInfo keyPushed = Console.ReadKey();
                if (keyPushed.Key == ConsoleKey.DownArrow)
                {
                    num++;
                }
                if (keyPushed.Key == ConsoleKey.UpArrow)
                {
                    num--;
                }
                if (keyPushed.Key == ConsoleKey.Enter)
                {
                    flag = true;
                }
                if (num <= 0)
                {
                    num = max - 1;
                }
                else if (num >= max)
                {
                    num = 1;
                }

                Text(num, texts);
            } while (!flag);
            return num;
        }
    }
}
