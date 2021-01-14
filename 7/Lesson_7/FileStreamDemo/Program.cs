using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stream
            //1) create stream
            //2) bind to file
            //3) mode
            //4)close

            #region Write
            //byte[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 34, 45 };
            //using (FileStream fs = new FileStream("byte.txt", FileMode.Create))
            //{
            //    fs.Write(arr, 0, arr.Length);
            //} 
            #endregion

            #region Read
            //using (FileStream fs = new FileStream("byte.txt", FileMode.Open, FileAccess.Read))
            //{
            //    byte[] readBytes = new byte[fs.Length];
            //    int bytes = fs.Read(readBytes, 0, readBytes.Length);
            //    Console.WriteLine("Read {0} byte", bytes);

            //    foreach (var item in readBytes)
            //    {
            //        Console.Write(item + "\t");
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            //string text = Console.ReadLine();
            //using(FileStream fs = new FileStream("text.dat", FileMode.Create))
            //{
            //    byte[] buffer = Encoding.UTF8.GetBytes(text);
            //    fs.Write(buffer, 0, buffer.Length);
            //}

            using(FileStream fs = new FileStream("text.dat", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                string str = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(str);
            }
        }
    }
}
