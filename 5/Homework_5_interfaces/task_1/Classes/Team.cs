using System;
using System.Collections.Generic;
using task_1.interfaces;

namespace task_1.Classes
{
    class Team
    {
        List<IWorker> team = new List<IWorker>();

        public Team(int countWorkerWithoutTeamLeader)
        {
            if (countWorkerWithoutTeamLeader < 1)
            {
                countWorkerWithoutTeamLeader = 3;
            }

            team.Add(new TeamLeader());

            for (int i = 1; i < countWorkerWithoutTeamLeader; i++)
            {
                team.Add(new Worker());
            }
        }

        public void BuildHouse(List<IPart> part)
        {
            int j = 1;

            Console.Clear();
            (team[0] as TeamLeader).DoWork(part);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i < part.Count; i++)
            {
                while (part[i].IsIReady() == false)
                {
                    if (j >= team.Count)
                    {
                        j = 1;
                    }

                    (team[j++] as Worker).DoWork(part[i], j, 30);

                    if (i == 2)
                    {
                        Console.WriteLine("\n Press something ...");
                        Console.ReadKey();
                        Console.Clear();
                        (team[0] as TeamLeader).DoWork(part);
                        Console.WriteLine("\n Press something ...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                Console.WriteLine();

                if (i == 4)
                {
                    Console.WriteLine("\n Press something ...");
                    Console.ReadKey();
                    Console.Clear();
                    (team[0] as TeamLeader).DoWork(part);
                    Console.WriteLine("\n Press something ...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Clear();
            (team[0] as TeamLeader).DoWork(part);
            Console.WriteLine("\n Press something ...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
