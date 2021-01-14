/*Написати програму для виконання операцій з одновимірним масивом за допомогою делегатів.
Користувачу надається наступне меню для вибору типа операції з масивом:
1.    обчислення значення
2.    зміна масиву
Якщо користувач вибрав 1-й тип, вивести підменю вибору операції:
i.    Обчислити кількість негативних елементів
ii.    Визначити суму всіх елементів
iii.    Обрахувати кількість простих чисел
2-й тип:
i.    Змінити всі негативні елементи на 0
ii.    Відсортувати масив
iii.    Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.
Методи першого типу повинні повертати результат обчислення, в той час методи 2-го типу - void.
Реалізувати валідацію вибраного номера операції.*/

using System;
using System.Threading;

/*Примітка від мене стосовно останього пункту: я зробила 2 варіанти
  - вибір стрілками (те що в мейні): цей спосіб мені простіше + валідація проста 
  - вибір вводом (для цього треба викликати метод ChooseNotStrilkamu(); : цей спосіб я зробила бо в умові
  розказано так (але там не не сказано що не можна стрілками ;)*/

namespace Homework_6_delegates
{
    class Program
    {
        delegate int ActionArr(int[] arr); // делегат для методів що повертають int(к-сть простих,негативних чисел, сума всіх ел масиву)
        delegate void ActionArrVoid(int[] arr); // делегат для методів що не повертають значення (print, sort ...)
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

            ActionArrVoid funcvoid = PrintArr;
            ActionArr func = null;

            Console.WriteLine(" --- Array --- ");
            int size = 0, min = 0, max = 0;

            do
            {
                try
                {
                    Console.Write("Enter size: ");
                    size = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter min element: ");
                    min = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter max element: ");
                    max = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (size <= 0 || max <= 0 || min > max);

            int[] arr = CreateArr(size);

            Console.Clear();

            FillRandArr(arr, min, max);
            funcvoid(arr);

            Console.Clear();
            string[] menu = { "\t-Works with array-\n \t   (use strilku)\n\t   -Menu №1-", "1. values calculation",
                "2. changing the array","3. print arr","4. exit" };

            bool flag = true;

            do
            {
                foreach (var item in menu)
                {
                    Console.WriteLine("  " + item);
                }

                int num = keys(menu); //виклик менюшки 

                switch (num)
                {
                    case 1: //1.обчислення значення
                        {
                            string[] menu1 = { "\t-Works with array-\n\t\t-Menu №2-",
                                "i.Calculate the number of negative elements",
                                "ii. Determine the sum of all items", "iii. Calculate the number of primes" };

                            Console.Clear();

                            for (int i = 0; i < menu1.Length; i++)
                            {
                                if (i == 1)
                                {
                                    Console.WriteLine(" >" + menu1[i] + "<");
                                }
                                else
                                {
                                    Console.WriteLine("  " + menu1[i]);
                                }
                            }

                            int num1 = keys(menu1); //виклик менюшки 

                            switch (num1)
                            {
                                case 1: //i. Обчислити кількість негативних елементів
                                    func = new ActionArr(CountNegativeElem);
                                    break;
                                case 2: //ii. Визначити суму всіх елементів
                                    func = new ActionArr(SumArr);
                                    break;
                                case 3: //iii. Обрахувати кількість простих чисел
                                    func = new ActionArr(CountSimpleElem);
                                    break;
                                default:
                                    func = null;
                                    break;
                            }

                            Console.Clear();
                            Console.WriteLine("Rezalt: " + func(arr));
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 2: //2.зміна масиву
                        {
                            string[] menu2 = { "\t-Works with array-\n\t\t-Menu №2-",
                                "i. Change all negative items to 0","ii. Sort the array",
                         "iii. Pass all paired items at the beginning without adding paired actions at the end." };

                            Console.Clear();

                            for (int i = 0; i < menu2.Length; i++)
                            {
                                if (i == 1)
                                {
                                    Console.WriteLine(" >" + menu2[i] + "<");
                                }
                                else
                                {
                                    Console.WriteLine("  " + menu2[i]);
                                }
                            }

                            int num2 = keys(menu2); //виклик менюшки 

                            switch (num2)
                            {
                                case 1:  //i. Змінити всі негативні елементи на 0
                                    funcvoid = new ActionArrVoid(ChangeAllNegativeElemToNull);
                                    break;
                                case 2:  //ii. Відсортувати масив
                                    funcvoid = new ActionArrVoid(SortArray);
                                    break;
                                case 3: //iii. Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.
                                    funcvoid = new ActionArrVoid(SortByParniAndSimpleElem);
                                    break;
                                default:
                                    funcvoid = null;
                                    break;
                            }

                            Console.Clear();
                            funcvoid(arr);
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: //вивід масиву
                        {
                            Console.Clear();
                            funcvoid = new ActionArrVoid(PrintArr);
                            funcvoid(arr);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: // вихід
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\tHave a nice day!\t\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Thread.Sleep(4000);
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (flag);

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

        static void FillRandArr(int[] arr, int left = 0, int right = 100) // заповнює рандомними значеннями
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(left, right);
            }
        }

        static void PrintArr(int[] arr) // друкує всі елементи масиву
        {
            Console.WriteLine();
            Console.WriteLine(" --- Array --- ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        static int CountNegativeElem(int[] arr) // рахує к-сть негативних чисел
        {
            int[] plus = Array.FindAll(arr, x => x < 0);
            return plus.Length;
        }

        static int SumArr(int[] arr) // повертає суму всіх елементів масиву
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        static int CountSimpleElem(int[] arr) // рахує к-сть простих чисел
        {
            bool flag;
            int temp = 0, count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];
                flag = true;

                if (arr[i] < 0)
                {
                    temp *= -1;
                }

                for (int j = 2; j < temp; j++)
                {
                    if (temp % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && temp != 1)
                {
                    count++;
                }
            }

            return count;
        }

        static void ChangeAllNegativeElemToNull(int[] arr) //змінює всі негативні елементи на 0
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
        }

        static void SortArray(int[] arr) //просто сортує
        {
            Array.Sort(arr);
        }

        static void SortByParniAndSimpleElem(int[] arr) //сортує парні на початку, не парні - в кінці
        {
            int[] arrsimple = Array.FindAll(arr, (x) => { return x % 2 != 0; });
            int[] arrpair = Array.FindAll(arr, (x) => { return x % 2 == 0; });

            Array.Copy(arrpair, arr, arrpair.Length);
            Array.Copy(arrsimple, 0, arr, arrpair.Length, arrsimple.Length);
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
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

        static void ChooseNotStrilkamu() //впринципі те саме що і в мейні тільки ввід не стрілками
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();

            ActionArrVoid funcvoid = PrintArr;
            ActionArr func = null;

            Console.WriteLine(" --- Array --- ");
            int size = 0, min = 0, max = 0;

            do
            {
                try
                {
                    Console.Write("Enter size: ");
                    size = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter min element: ");
                    min = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter max element: ");
                    max = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (size <= 0 || max <= 0 || min > max);

            int[] arr = CreateArr(size);

            Console.Clear();

            FillRandArr(arr, min, max);
            funcvoid(arr);

            Console.Clear();
            string[] menu = { "\t-Works with array-\n \t   (use strilku)\n\t   -Menu №1-", "1. values calculation",
                "2. changing the array","3. print arr","4. exit" };

            bool flag = true;
            int num = 0;

            do
            {
                foreach (var item in menu)
                {
                    Console.WriteLine("  " + item);
                }

                do
                {
                    try
                    {
                        Console.Write("Enter number: ");
                        num = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (num <= 0 || num > 4);

                switch (num)
                {
                    case 1: //1.обчислення значення
                        {
                            string[] menu1 = { "\t-Works with array-\n\t\t-Menu №2-",
                                "i.Calculate the number of negative elements",
                                "ii. Determine the sum of all items", "iii. Calculate the number of primes" };

                            Console.Clear();

                            foreach (var item in menu1)
                            {
                                Console.WriteLine("  " + item);
                            }

                            string num1 = "";

                            do
                            {
                                try
                                {
                                    Console.Write("Enter your choose: ");
                                    num1 = Console.ReadLine();
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            while (num1 != "i" && num1 != "ii" && num1 != "iii");

                            switch (num1)
                            {
                                case "i": //i. Обчислити кількість негативних елементів
                                    func = new ActionArr(CountNegativeElem);
                                    break;
                                case "ii": //ii. Визначити суму всіх елементів
                                    func = new ActionArr(SumArr);
                                    break;
                                case "iii": //iii. Обрахувати кількість простих чисел
                                    func = new ActionArr(CountSimpleElem);
                                    break;
                                default:
                                    func = null;
                                    break;
                            }

                            Console.Clear();
                            Console.WriteLine("Rezalt: " + func(arr));
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 2: //2.зміна масиву
                        {
                            string[] menu2 = { "\t-Works with array-\n\t\t-Menu №2-",
                                "i. Change all negative items to 0","ii. Sort the array",
                         "iii. Pass all paired items at the beginning without adding paired actions at the end." };

                            Console.Clear();

                            foreach (var item in menu2)
                            {
                                Console.WriteLine("  " + item);
                            }

                            string num2 = "";

                            do
                            {
                                try
                                {
                                    Console.Write("Enter your choose: ");
                                    num2 = Console.ReadLine();
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            while (num2 != "i" && num2 != "ii" && num2 != "iii");

                            switch (num2)
                            {
                                case "i":  //i. Змінити всі негативні елементи на 0
                                    funcvoid = new ActionArrVoid(ChangeAllNegativeElemToNull);
                                    break;
                                case "ii":  //ii. Відсортувати масив
                                    funcvoid = new ActionArrVoid(SortArray);
                                    break;
                                case "iii": //iii. Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.
                                    funcvoid = new ActionArrVoid(SortByParniAndSimpleElem);
                                    break;
                                default:
                                    funcvoid = null;
                                    break;
                            }

                            Console.Clear();
                            funcvoid(arr);
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: //вивід масиву
                        {
                            Console.Clear();
                            funcvoid = new ActionArrVoid(PrintArr);
                            funcvoid(arr);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: // вихід
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\tHave a nice day!\t\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Thread.Sleep(4000);
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (flag);
        }
    }
}
