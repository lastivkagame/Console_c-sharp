/*Створити програму для роботи з папками та файлами.
Програма повинна працювати  подібно "командному рядку". Тобто очікувати введення команди і виконувати вірну команду.

Передбачити наступні команди:
- md Ім'я_папки(створення папки)
- rd Ім'я_папки(видалення папки)
- cd Ім'я_папки(зміна поточної папки - SetCurrrentDirectory)
- dir патерн (вивід списку файлів та папок поточної папки за вказаним шаблоном чи без)
- create Ім'я_файлу( створення текстового файлу з записом тексту в нього)  (або copy con Ім'я_файлу)
- type  Ім'я_файлу(перегляд вмісту файлу)
- copy   Ім'я_файлу1  Ім'я_файлу2 (копіювання файлу)
- del  Ім'я_файлу(видалення файлу)*/

using System;
using System.IO;
using System.Threading;

namespace Homework_7
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string current = Directory.GetCurrentDirectory();
                DirectoryInfo doc = new DirectoryInfo(Directory.GetCurrentDirectory());
                Console.Write(current + "> ");
                string comand = Console.ReadLine();
                string dir = current + "\\", comand_name = "";

                for (int i = 0; i < comand.Length; i++)
                {
                    if (comand[i] == ' ')
                    {
                        break;
                    }
                    comand_name += comand[i];
                }

                for (int i = comand_name.Length + 1; i < comand.Length; i++)
                {
                    dir += comand[i];
                }

                string dir_need = "";

                for (int i = comand_name.Length + 1; i < comand.Length; i++)
                {
                    dir_need += comand[i];
                }

                Console.Write(" ->");

                switch (comand_name)
                {
                    case "help": // спрвка
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine(" - md folder_name             ->  create folder\n" +
                                              " - rd folder_name             ->  delete folder\n" +
                                              " - cd folder_name             -> change the streaming folder\n" +
                                              " - dir patern                 -> browse lists of files and folders of the streaming folder for the specified \n\t\t\t\t template or without\n" +
                                              " - create file_name           -> create a text file with a text entry in your own or copy file_name\n" +
                                              " - type file_name             -> view file change\n" +
                                              " - del file_name              -> deleting file\n" +
                                              " - copy file_name1 file_name2 -> copy file(for exeple you write first already exist file next you can enter some name\n\t\t\t\t and be created new identic file but that have another name)\n" +
                                              " - edit file_name             -> you can add some to text file\n" +
                                              " - cls                        -> clear console\n"
                                              );
                            Console.WriteLine("\n\n");
                        }
                        break;
                    case "md": // створити нову папку
                        {
                            if (!Directory.Exists(dir))
                            {
                                try
                                {
                                    Directory.CreateDirectory(dir);
                                    Console.WriteLine("Directory was success created");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Directory already exists");
                            }
                        }
                        break;
                    case "rd": // видалити папку
                        {
                            if (Directory.Exists(dir))
                            {
                                try
                                {
                                    Directory.Delete(dir, true);
                                    Console.WriteLine("Directory was success remove");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Directory is not exist!");
                            }
                        }
                        break;
                    case "cd": // перейти до ...
                        {
                            try
                            {
                                Directory.SetCurrentDirectory(dir_need);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "dir": // вивід списку файлів та папок поточної папки
                        {
                            FileInfo[] files;

                            if (dir_need == "" || dir_need == " " || dir_need == null)
                            {
                                files = doc.GetFiles("*.*");
                            }
                            else
                            {
                                try
                                {
                                    files = doc.GetFiles(dir_need, SearchOption.AllDirectories);//AllDirectories- шукаємо рекурсивно в підкаталогах
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine("Thanfore be show all directories and files at current folder");
                                    files = doc.GetFiles("*.*");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine();

                            try
                            {
                                foreach (var item in Directory.EnumerateDirectories(dir))
                                {
                                    Console.WriteLine(item);
                                    foreach (var entry in Directory.EnumerateFileSystemEntries(item))
                                    {
                                        Console.WriteLine("\t\t->{0}", entry);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.WriteLine();
                            Console.WriteLine();

                            foreach (var item in files)
                            {

                                if (item.Exists && item != null)
                                {
                                    Console.WriteLine($"{item.Name,-25} { item.LastWriteTime.ToShortTimeString(),-20} {item.Length,-15 } {item.Attributes,-15}");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        break;
                    case "create": // створити і заповнити новий текстовий файл 
                        {
                            if (dir.Length > 5)
                            {
                                if (!(dir[dir.Length - 1] == 't' && dir[dir.Length - 2] == 'x' && dir[dir.Length - 3] == 't' && dir[dir.Length - 4] == '.'))
                                {
                                    dir += ".txt";
                                }

                                FileInfo file = new FileInfo(dir);
                                if (File.Exists(dir))
                                {
                                    Console.WriteLine("File already exist!");
                                }
                                else
                                {
                                    Console.WriteLine("File was success created!");
                                }
                                Console.WriteLine("Do you want copy some file or enter some information? 1//2");
                                Console.WriteLine("___");
                                int answer = 2;

                                try
                                {
                                    answer = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                if (answer == 1)
                                {
                                    Console.Write("Enter file name to text file: ");
                                    string text = current + "\\";
                                    text += Console.ReadLine();

                                    try
                                    {
                                        File.Copy(text, dir);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Console.Write("Enter information that you want write to text file: ");
                                        string text = Console.ReadLine();

                                        Console.WriteLine("\n" + dir + "\n");

                                        File.AppendAllText(dir, text);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }

                                Thread.Sleep(1000);
                                Console.WriteLine("Done!");
                            }
                        }
                        break;
                    case "type": // переглянути файл
                        {
                            if (File.Exists(dir))
                            {
                                try
                                {
                                    string readText = File.ReadAllText(dir);
                                    Console.WriteLine("\n\tRead from " + dir_need + ": \n\t" + readText);
                                    Console.WriteLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("File is not exists!");
                            }
                        }
                        break;
                    case "copy": // створити копію
                        {
                            string doc1 = current + "\\", doc2 = current + "\\";
                            bool flag = true;

                            for (int i = 0; i < dir_need.Length; i++)
                            {
                                if (dir_need[i] == ' ')
                                {
                                    flag = false;
                                }
                                else if (flag == true)
                                {
                                    doc1 += dir_need[i];
                                }
                                else if (flag == false)
                                {
                                    doc2 += dir_need[i];
                                }
                            }

                            try
                            {
                                File.Copy(doc1, doc2);
                                Console.WriteLine("Successfull coping!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "del": //видалення файлу
                        {
                            if (File.Exists(dir))
                            {
                                try
                                {
                                    File.Delete(dir);
                                    Console.WriteLine("File was success delete");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("File is not");
                            }
                        }
                        break;
                    case "edit": // редагувати файл
                        {
                            Console.Write("Enter text that you want add: ");
                            string text = Console.ReadLine();

                            try
                            {
                                File.AppendAllText(dir, text);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "cls": // очистити екран
                        {
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine("Inccorect command!");
                        break;
                }

            } while (true);
        }
    }
}