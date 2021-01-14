using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class Menu
    {
        public static void START()
        {
            Comp comp = new Comp();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("  ----- Welcome -----");
            Console.WriteLine("      Let`s start!   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);

            bool flag = true;
            string[] menu = { "-Menu-", "AddDevice", "AddDisk", "CheckDisk", "InsertSomeDisk",
                "RejectSomeDisk", "PrintInfo", "ReadInfo", "ShowDisk", "ShowPrintDevice", "WriteInfo","Exit" };

            do
            {
                Console.Clear();
                Console.WriteLine("\t ---Comp---");

                foreach (string t in menu) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num = keys(menu); //виклик менюшки 
                switch (num)
                {
                    case 1: // AddDevice - додати пристрій для виводу/друку
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");

                            string[] temp1 = { "\n - > Section #1: AddDevice < -\n Choose what you want add ... ", "\tPrinter", "\tMonitor" };

                            foreach (string t in temp1) // вивід менюшки
                            {
                                Console.WriteLine("  " + t);
                            }

                            int num2 = keys(temp1);

                            if (num2 == 1)
                            {
                                comp.AddDevice(new Printer());
                            }
                            else
                            {
                                comp.AddDevice(new Monitor());
                            }

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Device was add success");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 2: // AddDisk - додає диск
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");

                            string[] temp1 = { "\n - > Section #2: AddDisk < -\n Choose what you want add ... ", "HDD", "Flash", "DVD", "CD" };

                            foreach (string t in temp1) // вивід менюшки
                            {
                                Console.WriteLine("  " + t);
                            }

                            int num2 = keys(temp1);

                            char chooseInfo;
                            int memSize = 0;
                            string memory = " ";
                            bool flag2 = true;

                            Console.WriteLine("Do you want enter memSize and some information?");
                            Console.WriteLine("                   y/n");
                            Console.Write("Answer: ");
                            chooseInfo = Convert.ToChar(Console.ReadLine());

                            if (chooseInfo == 'y')
                            {
                                Console.Write("Enter memSize: ");
                                memSize = Convert.ToInt32(Console.ReadLine());

                                if (memSize <= 0)
                                {
                                    flag2 = false;
                                    Console.WriteLine("Inccorect! Will be default settings");
                                }
                                else
                                {
                                    Console.Write("Enter some information: ");
                                    memory = Console.ReadLine();

                                    if (memSize < memory.Length)
                                    {
                                        flag2 = false;
                                        Console.WriteLine("Inccorect! Will be default settings");
                                    }
                                }
                            }
                            else
                            {
                                flag2 = false;
                                Console.WriteLine("ok, will be default settings");
                            }

                            switch (num2)
                            {
                                case 1:
                                    if (flag2)
                                    {
                                        comp.AddDisk(new HDD(memory, memSize));
                                    }
                                    else
                                    {
                                        comp.AddDisk(new HDD());
                                    }
                                    break;
                                case 2:
                                    if (flag2)
                                    {
                                        comp.AddDisk(new Flash(memory, memSize));
                                    }
                                    else
                                    {
                                        comp.AddDisk(new Flash());
                                    }
                                    break;
                                case 3:
                                    if (flag2)
                                    {
                                        comp.AddDisk(new DVD(memory, memSize));
                                    }
                                    else
                                    {
                                        comp.AddDisk(new DVD());
                                    }
                                    break;
                                case 4:
                                    if (flag2)
                                    {
                                        comp.AddDisk(new CD(memory, memSize));
                                    }
                                    else
                                    {
                                        comp.AddDisk(new CD());
                                    }
                                    break;
                                default:
                                    break;
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Device was add success");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 3: // CheckDisk - перевіряє чи вставлений чи винятий диск
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #3: CheckDisk < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of device which you want check: ");
                            string choose = Console.ReadLine();

                            if (comp.CheckDisk(choose))
                            {
                                Console.WriteLine("Disk is found");
                            }
                            else
                            {
                                Console.WriteLine("No disk");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 4: // InsertSomeDisk - вставляє диск
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #4: InsertSomeDisk < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of device: ");
                            string choose = Console.ReadLine();

                            comp.InsertReject(choose, true);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 5: // RejectSomeDisk - виймає диск
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #5: RejectSomeDisk < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of device: ");
                            string choose = Console.ReadLine();

                            comp.InsertReject(choose, false);

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 6: // PrintInfo - друкує вказаний диск на вказаному пристрої
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #6: PrintInfo < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of disk: ");
                            string chooseDisk6 = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine();

                            comp.ShowPrintDevice();

                            Console.WriteLine();

                            Console.Write("Enter name of print device: ");
                            string choosePrintDevice = Console.ReadLine();

                            if (comp.PrintInfo(chooseDisk6, choosePrintDevice))
                            {
                                Console.WriteLine("___________________________");
                                Console.WriteLine("End operation! All was not so bad");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong!");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 7: // ReadInfo -  повертає все що є на диску у Memory(properties)
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #7: ReadInfo < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of device: ");
                            string chooseDisk7 = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine("I read and I found ...\n");
                            Console.WriteLine("_______________________");

                            try
                            {
                                Console.WriteLine(comp.ReadInfo(chooseDisk7));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception!" + ex.Message);
                            }

                            Console.WriteLine("_______________________");
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 8: // ShowDisk - показує всі диски
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #8: ShowDisk < -");

                            comp.ShowDisk();

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 9: // ShowPrintDevice - показує всі пристрої для виводу/друку
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #9: ShowPrintDevice < -");

                            comp.ShowPrintDevice();

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 10: // WriteInfo - записує введену інформацію у вибраний диск
                        {
                            Console.Clear();
                            Console.WriteLine("\t ---Comp---");
                            Console.WriteLine("\n - > Section #10: WriteInfo < -");

                            comp.ShowDisk();

                            Console.WriteLine();

                            Console.Write("Enter name of device which you want write: ");
                            string chooseDisk10 = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine();

                            Console.Write("Enter information: ");
                            string text = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine();

                            if (comp.WriteInfo(text, chooseDisk10))
                            {
                                Console.WriteLine("Operation was success!");
                            }
                            else
                            {
                                Console.WriteLine("Some inccorect! Operation is not success!");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                        }
                        break;
                    case 11: // exit - вихід 
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
                }
                Console.Clear();
            } while (flag == true);
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t ---Comp---");
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
