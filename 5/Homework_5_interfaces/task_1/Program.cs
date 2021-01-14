/*Завдання 1
 Реалізувати класи House, Basement, Walls, Door, Window, Roof, Worker, TeamLeader, Team та інтерфейси IWorker, IPart.
 Всі частини будинку повинні бути класами та реалізувати інтерфейс IPart,
 для робочих і бригадира надається базовий інтерфейс IWorker.
 Бригада  будівельників  (Team)  будує  будинок  (House).
 Будинок  складається  з  фундаменту (Basement), стін (Wall), вікон (Window),дверей (Door), даху (Roof).
 Згідно проекту, в будинку повинно бути 1 фундамент, 4 стіна, 1 двері, 4 вікна і 1 дах. 
 Врахуйте також, що двері бувають різні: скляні, металеві, дерев’яні, профільні тощо.
 Фундамент також буває різного виду: стрічковий, збірний, стовпчастий, суцільний, зварний тощо.
 Реалізувати це за допомогою перелічувальної константи (enum). 
 Бригада починає роботу, і будівельники послідовно будують будинок, починаючи з фундаменту. 
 Кожен будівельник не знає наперед, на чому завершився попередній етап будівництва, тому він "перевіряє", 
 що вже побудовано і продовжує роботу. 
 Якщо в гру вступає бригадир (TeamLeader), він не будує, а формує звіт, що вже побудовано і яка частина
 роботи виконана. 
 В кінцевому рахунку на консоль виводиться повідомлення, що будівництво будинку завершено 
 і відображається "малюнок будинку”.*/
using System;
using task_1.Classes;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] basement = { "-Basement-", "Tape", "Precast", "Columnar", "Solid", "Welded" };
            string[] door = { "-Door-", "Glass", "Metal", "Wooden", "Profile" };
            string[] roof = {"-Roof-", "Gable", "Hip", "Dutch", "Mansard", "Flat", "Shed", "Butterfly",
                "Gambrel", "Dormer", "M_Shaped" };
            string[] window = { "-Window-","Cross", "Eyebrow", "Fixed", "SingleHungSash", "DoubleHungSash",
                "FoldUp", "Casement", "Pivot", "Hopper" };
            string[] walls = {"-Walls-", "PrecastConcrete", "Retaining", "Masonry", "PrePanelizedLoadBearingMetalStud",
                "EngineeringBrick", "Stone" };

            TypeBasement typeBasement = 0;
            TypeDoor typeDoor = 0;
            TypeRoof typeRoof = 0;
            TypeWalls[] typeWalls = new TypeWalls[4];
            TypeWindow[] typeWindow = new TypeWindow[4];

            #region Basement
            Console.Clear();
            Console.WriteLine("\t ---Basement---");

            foreach (string t in basement) // вивід менюшки
            {
                Console.WriteLine("  " + t);
            }

            int num = keys(basement); //виклик менюшки 

            switch (num)
            {
                case 1:
                    typeBasement = TypeBasement.Tape;
                    break;
                case 2:
                    typeBasement = TypeBasement.Precast;
                    break;
                case 3:
                    typeBasement = TypeBasement.Columnar;
                    break;
                case 4:
                    typeBasement = TypeBasement.Solid;
                    break;
                case 5:
                    typeBasement = TypeBasement.Welded;
                    break;
                default:
                    Console.WriteLine("Inccorect!");
                    break;
            }
            #endregion

            #region Door
            Console.Clear();
            Console.WriteLine("\t ---Door---");

            foreach (string t in door) // вивід менюшки
            {
                Console.WriteLine("  " + t);
            }

            int num2 = keys(door); //виклик менюшки 

            switch (num2)
            {
                case 1:
                    typeDoor = TypeDoor.Glass;
                    break;
                case 2:
                    typeDoor = TypeDoor.Metal;
                    break;
                case 3:
                    typeDoor = TypeDoor.Wooden;
                    break;
                case 4:
                    typeDoor = TypeDoor.Profile;
                    break;
                default:
                    Console.WriteLine("Inccorect!");
                    break;
            }
            #endregion

            #region Roof
            Console.Clear();
            Console.WriteLine("\t ---Roof---");

            foreach (string t in roof) // вивід менюшки
            {
                Console.WriteLine("  " + t);
            }

            int num3 = keys(roof); //виклик менюшки 

            switch (num3)
            {
                case 1:
                    typeRoof = TypeRoof.Gable;
                    break;
                case 2:
                    typeRoof = TypeRoof.Hip;
                    break;
                case 3:
                    typeRoof = TypeRoof.Dutch;
                    break;
                case 4:
                    typeRoof = TypeRoof.Mansard;
                    break;
                case 5:
                    typeRoof = TypeRoof.Flat;
                    break;
                case 6:
                    typeRoof = TypeRoof.Shed;
                    break;
                case 7:
                    typeRoof = TypeRoof.Butterfly;
                    break;
                case 8:
                    typeRoof = TypeRoof.Gambrel;
                    break;
                case 9:
                    typeRoof = TypeRoof.Dormer;
                    break;
                case 10:
                    typeRoof = TypeRoof.M_Shaped;
                    break;
                default:
                    Console.WriteLine("Inccorect");
                    break;
            }
            #endregion

            #region Window

            for (int i = 0; i < 4; i++)
            {
                Console.Clear();
                Console.WriteLine("\t ---Window #" + i + "---");

                foreach (string t in window) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num4 = keys(window); //виклик менюшки 

                switch (num4)
                {
                    case 1:
                        typeWindow[i] = TypeWindow.Cross;
                        break;
                    case 2:
                        typeWindow[i] = TypeWindow.Eyebrow;
                        break;
                    case 3:
                        typeWindow[i] = TypeWindow.Fixed;
                        break;
                    case 4:
                        typeWindow[i] = TypeWindow.SingleHungSash;
                        break;
                    case 5:
                        typeWindow[i] = TypeWindow.DoubleHungSash;
                        break;
                    case 6:
                        typeWindow[i] = TypeWindow.FoldUp;
                        break;
                    case 7:
                        typeWindow[i] = TypeWindow.Casement;
                        break;
                    case 8:
                        typeWindow[i] = TypeWindow.Pivot;
                        break;
                    case 9:
                        typeWindow[i] = TypeWindow.Hopper;
                        break;
                    default:
                        Console.WriteLine("Inccorect!");
                        break;
                }
            }
            #endregion

            #region Walls

            for (int i = 0; i < 4; i++)
            {
                Console.Clear();
                Console.WriteLine("\t ---Wall #" + i + "---");

                foreach (string t in walls) // вивід менюшки
                {
                    Console.WriteLine("  " + t);
                }

                int num5 = keys(walls); //виклик менюшки 

                switch (num5)
                {
                    case 1:
                        typeWalls[i] = TypeWalls.PrecastConcrete;
                        break;
                    case 2:
                        typeWalls[i] = TypeWalls.Retaining;
                        break;
                    case 3:
                        typeWalls[i] = TypeWalls.Masonry;
                        break;
                    case 4:
                        typeWalls[i] = TypeWalls.PrePanelizedLoadBearingMetalStud;
                        break;
                    case 5:
                        typeWalls[i] = TypeWalls.EngineeringBrick;
                        break;
                    case 6:
                        typeWalls[i] = TypeWalls.Stone;
                        break;
                    default:
                        Console.WriteLine("Inccorect");
                        break;
                }
            }
            #endregion

            Console.Clear();
            Console.Write("Enter count of workers: ");
            int worker = Convert.ToInt32(Console.ReadLine());

            if (worker <= 0)
            {
                worker = 10;
            }

            Team team = new Team(worker);
            House house = new House(team, typeBasement, typeWalls[0], typeWalls[1], typeWalls[2],
                typeWalls[3], typeRoof, typeDoor, typeWindow[0], typeWindow[1], typeWindow[2], typeWindow[3]);
        }

        static void Text(int i, string[] texts) //заміна кольору менюшки
        {
            Console.Clear();
            Console.WriteLine("\t ---House---");
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
