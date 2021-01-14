using Homework_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class Comp
    {
        public List<Disk> disks = new List<Disk>();
        public List<IPrintInformation> printDevice = new List<IPrintInformation>();

        public void AddDevice(IPrintInformation si)  //додає до листа дисків ще один новий
        {
            printDevice.Add(si);
        }

        public void AddDisk(Disk disk)  //додає до листа прстроїв для друку ще один новий
        {
            disks.Add(disk);
        }

        public bool CheckDisk(string device) // перевіряє чи вставлений диск
        {

            if (FindDisk(device) != -1)
            {
                if ((device[0] != 'H') || (device[1] != 'D') || (device[2] != 'D'))
                {
                    return (disks[FindDisk(device)] as IRemoveableDisk).HasDisk;
                }
                else
                {
                    Console.WriteLine("This is HDD!!!");
                }
            }
            else
            {
                Console.WriteLine("This device is not found!");
            }

            return false;

        }

        public void InsertReject(string device, bool b)  // вставляє\виймає переданий диск
        {
            if (FindDisk(device) != -1)
            {
                if ((device[0] != 'H') || (device[1] != 'D') || (device[2] != 'D'))
                {
                    if (b)
                    {
                        (disks[FindDisk(device)] as IRemoveableDisk).Insert();
                    }
                    else
                    {
                        (disks[FindDisk(device)] as IRemoveableDisk).Reject();
                    }
                }
                else
                {
                    Console.WriteLine("Operation is not possible");
                }
            }
            else
            {
                Console.WriteLine("Operation is not possible");
            }
        }

        public bool PrintInfo(string text, string showDevice)  // друкує вказаний диск на вказаному пристрої
        {
            bool flag = true;
            
            if (FindDisk(text) != -1 && FindPrintDevice(showDevice) != -1)
            {
                string name = disks[FindDisk(text)].GetName();

                if ((name[0] != 'H') || (name[1] != 'D') || (name[2] != 'D'))
                {
                    if (!(disks[FindDisk(text)] as IRemoveableDisk).HasDisk)
                    {
                        flag = false;
                        Console.WriteLine("Disk not found!");
                    }
                }

                if (flag)
                {
                    printDevice[FindPrintDevice(showDevice)].Print(disks[FindDisk(text)].Memory);
                }
                else
                {
                    Console.WriteLine("Disk is not found!");
                }
                return true;
            }
            else
            {
                Console.WriteLine("Inccorect some devices!");
                return false;
            }
        }

        public string ReadInfo(string device)  // повертає все що є на диску у Memory(properties)
        {
            bool flag = true;
            
            if (FindDisk(device) != -1)
            {
                string name = disks[FindDisk(device)].GetName();

                if ((name[0] != 'H') || (name[1] != 'D') || (name[2] != 'D'))
                {
                    if (!(disks[FindDisk(device)] as IRemoveableDisk).HasDisk)
                    {
                        flag = false;
                        Console.WriteLine("Disk not found!");
                    }
                }

                if (flag)
                {
                    return disks[FindDisk(device)].Memory;
                }
            }

            throw new Exception("Inccorect Device!");
        }

        public void ShowDisk()  //друкує всі диски з листа дисків
        {
            int hdd = 0, flash = 0, dvd = 0, cd = 0;

            Console.WriteLine("\t -Print Disk-");
            for (int i = 0; i < disks.Count; i++)
            {
                Console.Write(" - " + disks[i].GetName());

                if (disks[i].GetName() == "HDD")
                {
                    Console.WriteLine(" " + hdd++);
                }
                else if (disks[i].GetName() == "CD")
                {
                    Console.WriteLine(" " + cd++);
                }
                else if (disks[i].GetName() == "DVD")
                {
                    Console.WriteLine(" " + dvd++);
                }
                else
                {
                    Console.WriteLine(" " + flash++);
                }
            }
        }

        public void ShowPrintDevice() //друкує всі пристрої для виводу з листа пристроїв
        {
            int printer = 0, monitor = 0;

            Console.WriteLine("\t -Print Device-");
            for (int i = 0; i < printDevice.Count; i++)
            {
                Console.Write(" - " + printDevice[i].GetName());

                if (printDevice[i].GetName() == "Printer")
                {
                    Console.WriteLine(" " + printer++);
                }
                else
                {
                    Console.WriteLine(" " + monitor++);
                }
            }
        }

        public bool WriteInfo(string text, string device) // записує переданий текст у вказаний диск
        {
            bool flag = true;

            if (FindDisk(device) != -1)
            {
                string name = disks[FindDisk(device)].GetName();

                if ((name[0] != 'H') || (name[1] != 'D') || (name[2] != 'D'))
                {
                    if (!(disks[FindDisk(device)] as IRemoveableDisk).HasDisk)
                    {
                        flag = false;
                        Console.WriteLine("Disk not found!");
                    }
                }

                if (flag)
                {
                    disks[FindDisk(device)].Write(text);
                    return true;
                }
            }

            return false;
        }

        int FindDisk(string device) // шукає по переданій назві диску цей диск у лісті і повертає його індекс
        {
            int hdd = 0, flash = 0, dvd = 0, cd = 0;
            string name;

            for (int i = 0; i < disks.Count; i++)
            {
                name = disks[i].GetName() + " ";

                if (disks[i].GetName() == "HDD")
                {
                    name += hdd++;
                }
                else if (disks[i].GetName() == "CD")
                {
                    name += cd++;
                }
                else if (disks[i].GetName() == "DVD")
                {
                    name += dvd++;
                }
                else
                {
                    name += flash++;
                }

                if (name == device)
                {
                    return i;
                }
            }

            return -1;
        }

        int FindPrintDevice(string device)// шукає по переданій назві пристрою для виводу цей пристрій у 
        {                                    //лісті і повертає його індекс
            int printer = 0, monitor = 0;
            string name;

            for (int i = 0; i < printDevice.Count; i++)
            {
                name = printDevice[i].GetName() + " ";

                if (printDevice[i].GetName() == "Printer")
                {
                    name += printer++;
                }
                else
                {
                    name += monitor++;
                }

                if (name == device)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
