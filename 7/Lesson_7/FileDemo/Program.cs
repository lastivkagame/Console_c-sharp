using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name of directory: ");
            string nameDir = Console.ReadLine();

            if (!Directory.Exists(nameDir))
            {
                Directory.CreateDirectory(nameDir);
                Console.WriteLine("Directory was created");

            }
            else
            {
                Console.WriteLine("Directory already exists");
            }

            Console.Write("Enter file name:");
            string fileName = Console.ReadLine();
            string fullPath = nameDir + "\\" + fileName;
            //FileInfo file = new FileInfo(fullPath);
            FileInfo file = new FileInfo(nameDir + "\\" + fileName);
            //file.Create();
            
            DisplayInfo(file);

            Console.Write("Enter text: ");
            //string text = Console.ReadLine();
            Console.OutputEncoding = Encoding.UTF8; // для букви і
            string text = "\nHello from code хороших днів" + Environment.NewLine + DateTime.Now;
            //File.WriteAllText(fullPath, text);
            File.AppendAllText(fullPath, text);
            Thread.Sleep(1000);
            Console.WriteLine("Done!");

            string readText = File.ReadAllText(fullPath);
            Console.WriteLine("\n\n\n\tread from fullpath: " + readText);

            var dir = Directory.CreateDirectory(@"D:\Test");
            if (dir.Exists)
                //File.Copy(fullPath, dir.FullName + "\\" + fileName);
                File.Copy(fullPath, dir.FullName + "\\" + Path.GetFileName(fullPath));

            //Path !!! to read, to learn, to practice!!!

            Directory.SetCurrentDirectory("../../../FileDemo"); // змінити поточну директорію
            Console.WriteLine(Directory.GetCurrentDirectory()); //отримати поточну директорію
        }

        private static void DisplayInfo(FileInfo file)
        {
            if (file.Exists)
                Console.WriteLine($"{file.Name,-15} {file.Length,-15} {file.Extension,-15} {file.CreationTime,-15}");
        }
    }
}
