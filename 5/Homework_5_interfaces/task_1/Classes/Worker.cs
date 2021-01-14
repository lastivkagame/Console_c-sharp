using System;
using System.Threading;
using task_1.interfaces;

namespace task_1.Classes
{
    class Worker : IWorker
    {
        public static int count;

        static Worker()
        {
            count = 0;
        }

        public bool CheckPart(IPart part)
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

        public void DoWork(IPart part, int id, int kkd)
        {
            if (part.IsIReady() == false)
            {
                Console.Write("I worker " + id + " begin work on " + part.GetName() + " ");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(".");
                    part.AddToMyPercent(kkd);
                    Thread.Sleep(100);

                    if (part.IsIReady())
                    {
                        break;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
