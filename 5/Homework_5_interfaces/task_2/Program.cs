/* Завдання 2.
Визначити клас Напій(Drink) з полями  
    o назва напою,
    o тип напою(власного перелічувального типу)  
    o виробник 
    o кількість ккал 
    o ціна методами 
    o конструктори 
    o перевизначити метод ToString() 
    o реалізувати інтерфейс  IComparable(як метод класу int CompareTo(object)) : 
            порівнювати напої за типом
    o реалізувати інтерфейс  IComparable< >(як метод класу int CompareTo(Drink)) :
            порівнювати за назвою напою 
 Визначити 3 класи   компараторів, які реалізують інтерфейс IComparer,
 тобто метод int Compare(object,  object)для   
    o порівняння  напоїв  за ціною(за зростанням)
    o порівняння  напоїв  за  енергетичною  цінністю, ккал(спаданням) 
    o порівняння за  виробником(за зростанням)
 Визначити 3 класи   компараторів, які реалізують інтерфейс IComparer<Drink>,
 тобто метод int Compare(Drink, Drink)для  
    o порівняння за ціною(за спаданням) 
    o порівняння за ккал(зростанням) 
    o порівняння за  виробником(зростання) 
Реалізувати інтерфейс  IEquatable<> Перевірити роботу класу. 
Підготувати 2 колекції:  ArrayList,  List<Drink>. 
Перевірити  роботу  реалізованих  інтерфейсів  за  допомогою  сортування  колекцій(Sort),пошуку(IndexOf).*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrlist = new ArrayList();
            List<Drink> drinks = new List<Drink>();

            int countarrlist = 0, countdrinks = 0;

            string[] type = { "-TypeDrinks-", "NonСarbonatedDrink", "СarbonatedDrink", "HotDrink", "MilkDrink", "AlcoholDrink" };

            do
            {
                try
                {
                    Console.Write("Enter size of arrlist(must be more than 0): ");
                    countarrlist = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter size of list(must be more than 0):");
                    countdrinks = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (countarrlist <= 0 || countarrlist <= 0);

            string name, producer;
            double price = 0, numberCal = 0;
            TypeDrink types = 0;

            #region FillSomeUnknownValues
            //drinks.Add(new Drink("C", TypeDrink.СarbonatedDrink, "W1", 5, 70));
            //drinks.Add(new Drink("A", TypeDrink.AlcoholDrink, "W2", 10, 200));
            //drinks.Add(new Drink("B", TypeDrink.HotDrink, "D", 11, 50));

            //arrlist.Add(new Drink("X", TypeDrink.NonСarbonatedDrink, "D1", 2, 20));
            //arrlist.Add(new Drink("Y", TypeDrink.MilkDrink, "F1", 1, 400));
            //arrlist.Add(new Drink("C", TypeDrink.СarbonatedDrink, "W1", 5, 70));
            #endregion

            #region FillArrList
            Console.Clear();
            Console.WriteLine("\t ---ArrList---");
            for (int i = 0; i < countarrlist; i++)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();

                Console.Write("Enter producer: ");
                producer = Console.ReadLine();

                foreach (string t in type) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(type); //виклик менюшки 

                switch (num)
                {
                    case 1:
                        types = TypeDrink.NonСarbonatedDrink;
                        break;
                    case 2:
                        types = TypeDrink.СarbonatedDrink;
                        break;
                    case 3:
                        types = TypeDrink.HotDrink;
                        break;
                    case 4:
                        types = TypeDrink.MilkDrink;
                        break;
                    case 5:
                        types = TypeDrink.AlcoholDrink;
                        break;
                    default:
                        break;
                }

                do
                {
                    try
                    {
                        Console.Write("Enter price(must be more than 0): ");
                        price = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter number of cal(must be more than 0):");
                        numberCal = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (price <= 0 || numberCal < 0);

                arrlist.Add(new Drink(name, types, producer, numberCal, price));

                Console.Clear();
            }

            #endregion

            #region FillList
            Console.Clear();
            Console.WriteLine("\t ---List---");

            for (int i = 0; i < countdrinks; i++)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();

                Console.Write("Enter producer: ");
                producer = Console.ReadLine();

                foreach (string t in type) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(type); //виклик менюшки 

                switch (num)
                {
                    case 1:
                        types = TypeDrink.NonСarbonatedDrink;
                        break;
                    case 2:
                        types = TypeDrink.СarbonatedDrink;
                        break;
                    case 3:
                        types = TypeDrink.HotDrink;
                        break;
                    case 4:
                        types = TypeDrink.MilkDrink;
                        break;
                    case 5:
                        types = TypeDrink.AlcoholDrink;
                        break;
                    default:
                        break;
                }

                do
                {
                    try
                    {
                        Console.Write("Enter price(must be more than 0): ");
                        price = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter number of cal(must be more than 0):");
                        numberCal = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (price <= 0 || numberCal < 0);

                drinks.Add(new Drink(name, types, producer, numberCal, price));

                Console.Clear();
            }

            #endregion

            Print(drinks);
            Print(arrlist);

            #region SortByNameType 
            Console.WriteLine("\n \t -After sort by name/type-");
            Console.WriteLine();
            drinks.Sort(); //сортує по імені 
            arrlist.Sort(); // сортує по типу
            Print(drinks);
            Print(arrlist);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region SortByProducer 
            Console.WriteLine("\n \t -After sort by Producer-");
            Console.WriteLine();
            drinks.Sort(new CompareByProducerDrink()); // за виробником за зростанням
            arrlist.Sort(new CompareByProducer()); // за виробником за зростанням
            Print(drinks);
            Print(arrlist);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            #endregion

            #region SortByPrice  
            Console.WriteLine("\n \t -After sort by Price-");
            Console.WriteLine();
            drinks.Sort(new CompareByPriceDrink()); //сортує за ціною  за спаданням
            arrlist.Sort(new CompareByPrice()); //сортує за ціною  за зростанням
            Print(drinks);
            Print(arrlist);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region SortByNumberOfCal 
            Console.WriteLine("\n \t -After sort by Cal-");
            Console.WriteLine();
            drinks.Sort(new CompareByNumberOfcalDrink()); //сортує за калоріями за зростання
            arrlist.Sort(new CompareByNumberOfcal());  //сортує за калоріями за спаданням
            Print(drinks);
            Print(arrlist);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            #endregion

            Console.WriteLine();

            Console.WriteLine("index elem that is in drinks and arrlist: " + drinks.IndexOf(arrlist[0] as Drink));
            Console.WriteLine("index elem with type CarbonatedDrink: " + drinks.IndexOf(new Drink("H", TypeDrink.СarbonatedDrink)));
        }

        private static void Print(ArrayList arrlist)
        {
            Console.WriteLine("\t -ArrList-");
            for (int i = 0; i < arrlist.Count; i++)
            {
                Console.WriteLine(arrlist[i]);
            }
            Console.WriteLine();
        }

        private static void Print(List<Drink> drinks)
        {
            Console.WriteLine("\t -List-");
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine(drinks[i]);
            }
            Console.WriteLine();
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t --- Choose ... ---");
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
