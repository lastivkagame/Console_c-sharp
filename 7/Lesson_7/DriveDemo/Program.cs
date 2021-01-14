using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // System.IO - для роботи з файлами

namespace DriveDemo
{
    class Program
    {
        //System.IO
        //Stream: FileStream, MemoryStream
        // StreamReader, StreamWriter, BinaryReader/Writer..
        //File, FileInfo, Directory, DirectoryInfo, DriveInfo
        static void Main(string[] args)
        {
            DriveInfo[] mydevices = DriveInfo.GetDrives();

            foreach (var item in mydevices)
            {
                if (item.IsReady)
                {
                    Console.WriteLine("Name: " + item.Name);
                    Console.WriteLine("TotalFreeSpace: {0:N2} gb", item.TotalFreeSpace / Math.Pow(2, 30));
                    Console.WriteLine("DriveFormat:" + item.DriveFormat);
                    Console.WriteLine("VolumeLabel: " + item.VolumeLabel);
                    Console.WriteLine("TotalSize: {0:N2}", item.TotalSize / Math.Pow(2, 30));
                    Console.WriteLine();
                }
            }
        }

        private static void PrintArray(DriveInfo[] games)
        {
            foreach (var item in games)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
