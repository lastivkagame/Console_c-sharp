using System;
using System.Collections.Generic;
using task_1.interfaces;

namespace task_1.Classes
{
    class TeamLeader : IWorker
    {
        public TeamLeader()
        {

        }
        public void DoWork(List<IPart> part)
        {
            //Згідно проекту, в будинку повинно бути 1 фундамент, 4 стіна, 1 двері, 4 вікна і 1 дах.
            //Отже я поділю так:
            // вікна: 4шт = 20 %, вікно одне - 5 %
            // стіни: 4шт = 20 %, одна стіна - 5 %
            // дах: 1шт = 20 %
            // двері: 1шт = 20 %
            // фундамент: 1шт = 20 %

            double percent = 0;
            int walls = 0, window = 0;
            double temppercent = 0;

            Console.Clear();
            Console.WriteLine("\t---Report about house---");

            for (int i = 0; i < part.Count; i++)
            {
                if (part[i] is Basement && part[i].IsIReady())
                {
                    Console.WriteLine("Basement is ready: + 20 % of all");
                    percent += 20;
                }
                else if (part[i] is Basement)
                {
                    temppercent = 20 * ((part[i] as Basement).MyPercentPlus / 100);
                    percent += temppercent;
                    Console.WriteLine("Basement is not ready yet, it ready only on: " + (part[i] as Basement).MyPercentPlus + " %, I in all house: " + temppercent + " % ");
                }

                else if (part[i] is Walls && part[i].IsIReady())
                {
                    Console.WriteLine(++walls + " wall is ready: + 5 % of all");
                    percent += 5;
                }
                else if (part[i] is Walls)
                {
                    temppercent = 5 * ((part[i] as Walls).MyPercentPlus / 100);
                    percent += temppercent;
                    Console.WriteLine(++walls + " wall is not ready yet, it ready only on: " + (part[i] as Walls).MyPercentPlus + " %, I in all house: " + temppercent + " % ");
                }

                else if (part[i] is Door && part[i].IsIReady())
                {
                    Console.WriteLine("Door is ready: + 20 % of all");
                    percent += 20;
                }
                else if (part[i] is Door)
                {
                    temppercent = 20 * ((part[i] as Door).MyPercentPlus / 100);
                    percent += temppercent;
                    Console.WriteLine(" Door is not ready yet, it ready only on: " + (part[i] as Door).MyPercentPlus + " %, I in all house: " + temppercent + " % ");
                }

                else if (part[i] is Window && part[i].IsIReady())
                {
                    Console.WriteLine(++window + " window is ready: + 5 %");
                    percent += 5;
                }
                else if (part[i] is Window)
                {
                    temppercent = 5 * ((part[i] as Window).MyPercentPlus / 100);
                    percent += temppercent;
                    Console.WriteLine(++window + " window is not ready yet, it ready only on: " + (part[i] as Window).MyPercentPlus + " %, I in all house: " + temppercent + " % ");
                }

                else if (part[i] is Roof && part[i].IsIReady())
                {
                    Console.WriteLine("Roof is ready: + 20 %");
                    percent += 20;
                }
                else if (part[i] is Roof)
                {
                    temppercent = 20 * ((part[i] as Roof).MyPercentPlus / 100);
                    percent += temppercent;
                    Console.WriteLine(" Roof is not ready yet, it ready only on: " + (part[i] as Roof).MyPercentPlus + " %, I in all house: " + temppercent + " % ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("Now is ready: " + percent + " % ");

            if (percent == 100)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome home ready");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        bool IWorker.CheckPart(IPart part)
        {
            if (part.IsIReady())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
