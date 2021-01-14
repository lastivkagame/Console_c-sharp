/*Задание 2
Создать приложение «Викторина».
Основная задача проекта: предоставить пользователю возможность проверить
свои знания в разных областях.
Интерфейс приложения должен предоставлять такие возможности:
■ При старте приложения пользователь вводит логин и пароль для входа.
Если пользователь не зарегистрирован, он должен пройти процесс регистрации.
■ При регистрации нужно указать:
• логин (нельзя зарегистрировать уже существующий логин);
• пароль;
• дату рождения.
■ После входа в систему пользователь может:
• стартовать новую викторину;
• посмотреть результаты своих прошлых викторин;
• посмотреть Топ-20 по конкретной викторине;
• изменить настройки. Можно менять пароль и дату рождения;
• выход.
■ Для старта новой викторины пользователь должен выбрать раздел знаний
викторины. Например: «История», “География», «Биология» и т. д. Также
нужно предусмотреть смешанную викторину, когда вопросы будут выбираться из разных викторин по случайному принципу.
■ Конкретная викторина состоит из двадцати вопросов. У каждого вопроса
может быть один или несколько правильных вариантов ответа. Если вопрос предполагает несколько правильных ответов,
а пользователь указал не все, вопрос не засчитывается.
■ По завершении викторины пользователь получает количество правильно
отвеченных вопросов, а также свое место в таблице результатов игроков
викторины.
Необходимо также разработать утилиту для создания и редактирования
викторин и их вопросов. Это приложение должно предусматривать вход по логину и паролю. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to QUIZ! AT first please authorization ...");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;

                string[] authorizate = { "", "Login", "Sign up" };

                foreach (string t in authorizate) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }
                Console.WriteLine();

                int num = keys(authorizate); //виклик менюшки 

                string log = "", psw = "", date = "";


                if (num == 1)
                {
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Welcome to QUIZ! AT first please authorization ...");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("If you want to back simle write at login - 'back'");

                            Console.Write("Login: ");
                            log = Console.ReadLine();

                            if (log == "back")
                            {
                                break;
                            }

                            Console.Write("Password: ");
                            psw = Console.ReadLine();

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        flag = Authorizations.UserLogin(log, psw);

                    } while (!flag);
                }
                else
                {
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Welcome to QUIZ! AT first please authorization ...");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("If you want to back simle write at login - 'back'");

                            Console.Write("Login: ");
                            log = Console.ReadLine();

                            if (log == "back")
                            {
                                break;
                            }

                            Console.Write("Password: ");
                            psw = Console.ReadLine();
                            Console.Write("Date: ");
                            date = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        flag = Authorizations.UserSignUp(log, psw, date);

                    } while (!flag);
                }

                Console.Clear();
            } while (flag != true);

            Console.WriteLine("Success! You authorize!");

            Thread.Sleep(1000);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            int num2 = 0;

            do
            {
                string[] menu = { "\t --- App QUIZ! --- \n        Menu ", " start new QUIZ", " rezalt past QuiZ", " leader board", " change password", " change date", " Add new Quiz", " exit" };

                foreach (string t in menu) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }
                Console.Clear();

                num2 = keys(menu); //виклик менюшки 

                string[] menu0 = { "Please choose one ... ", "Math", "Geography", "English", "History", "Mixed" };
                TypeQUIZ type = TypeQUIZ.Math;

                if (num2 < 4)
                {
                    foreach (string t in menu0) // вивід менюшки
                    {
                        Console.WriteLine("  " + t);
                    }

                    int num1 = keys(menu0); //виклик менюшки 

                    switch (num1)
                    {
                        case 1:
                            type = TypeQUIZ.Math;
                            break;
                        case 2:
                            type = TypeQUIZ.Geography;
                            break;
                        case 3:
                            type = TypeQUIZ.English;
                            break;
                        case 4:
                            type = TypeQUIZ.History;
                            break;
                        case 5:
                            type = TypeQUIZ.Mixed;
                            break;
                        default:
                            type = TypeQUIZ.Math;
                            break;
                    }
                }

                Console.Clear();

                switch (num2)
                {
                    case 1:
                        {
                            Console.Clear();
                            Quiz.StartQuiz(Authorizations.Login, type);
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Your rezalts!");
                            foreach (var item in Quiz.YourRezalts(Authorizations.Login, type))
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Leader Board!");
                            foreach (var item in Quiz.Top20Leaders(type))
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine(" --- Change options ---");
                            Console.Write("Enter old password: ");
                            string oldpsw = Console.ReadLine();
                            Console.Write("Enter new password: ");
                            string newpassword = Console.ReadLine();
                            Console.Write("Repeat new password: ");
                            string newpasswordcopy = Console.ReadLine();

                            if (newpassword != newpasswordcopy)
                            {
                                Console.WriteLine("Inccorect you entered different passwords. Must be One!");
                            }
                            else
                            {
                                if (Authorizations.ChangePassword(Authorizations.Login, oldpsw, newpassword))
                                {
                                    Console.WriteLine("Success!");
                                }
                                else
                                {
                                    Console.WriteLine("Some went inccorect!");
                                }
                            }
                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine(" --- Change options ---");
                           
                            Console.Write("Enter password: ");
                            string psw = Console.ReadLine();

                            Console.Write("Enter date: ");
                            string date = Console.ReadLine();

                            if (Authorizations.ChangeDate(Authorizations.Login, psw, date)) 
                            {
                                Console.WriteLine("Success!");
                            }
                            else
                            {
                                Console.WriteLine("Some went inccorect!");
                            }

                            Console.WriteLine("\n Press something ...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 6:
                        {
                            Quiz.AddQuestionToQuiz(type);
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Have a nice day!");
                        break;
                    default:
                        {
                            Console.WriteLine("Inccorect!");
                        }
                        break;
                }
            } while (num2 != 7);

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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
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
