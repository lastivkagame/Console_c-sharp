using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameDir = @"../../../"; //Solution

            //DisplayInfoAboutDir();

            //ModifyDirectory(".");

            DirectoryDemo(nameDir);
        }

        private static void DirectoryDemo(string nameDir)
        {
            string current = Directory.GetCurrentDirectory();
            Console.WriteLine(current);

            //foreach (var item in Directory.EnumerateDirectories(nameDir))

            foreach (var item in Directory.EnumerateDirectories(nameDir/*,"*.cs",SearchOption.AllDirectories*/))
            {
                Console.WriteLine(item);
                foreach (var entry in Directory.EnumerateFileSystemEntries(item))
                {
                    Console.WriteLine("\t\t->{0}", entry);
                }
            }
        }

        private static void ModifyDirectory(String v)
        {
            DirectoryInfo dir = new DirectoryInfo(v);
            DirectoryInfo first = dir.CreateSubdirectory("first");
            DirectoryInfo sub = dir.CreateSubdirectory(@"Second\Third");
            Console.WriteLine("new folder: " + sub);
            //DirectoryInfo first = new DirectoryInfo("First");

            try
            {
                first.Delete();
                sub.Parent.Delete(true); // true - видаляємо рекурсивно(підпапки теж)
                if (Directory.Exists("D:\\test"))
                    Directory.Delete("D:\\test", true);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayInfoAboutDir()
        {
            //string nameDir = @"C:\Windows";
            string nameDir = @"../../../"; //is right
            DirectoryInfo dir = new DirectoryInfo(nameDir);

            if (dir.Exists)
            {
                Console.WriteLine("FullName {0}", dir.FullName);
                Console.WriteLine("Parent {0}", dir.Parent);
                Console.WriteLine("CreationTime {0}", dir.CreationTime);
                Console.WriteLine("LastAccessTime {0}", dir.LastAccessTime);
                Console.WriteLine("LastWriteTime {0}", dir.LastWriteTime);
                Console.WriteLine("Attributes {0}", dir.Attributes);

                //FileAttributes -- enum
                //0 1 2 3 4 5 6 
                //FileAttributes.Archive | FileAttributes.Hidden | FileAttributes.System
                //00000001 00000010 00000011

                FileInfo[] files = dir.GetFiles("*.exe", SearchOption.AllDirectories);//AllDirectories- шукаємо рекурсивно в підкаталогах

                //FileInfo[] files = dir.GetFiles("*.*");

                foreach (var item in files)
                {

                    if (item.Exists && item != null)
                    {
                        Console.WriteLine($"{item.Name,-25} { item.LastWriteTime.ToShortTimeString(),-20} {item.Length,-15 } {item.Attributes,-15}");
                    }
                }
            }
        }
    }
}
