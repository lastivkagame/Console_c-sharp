using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text to write up: ");
            string str = Console.ReadLine();

            FileStream fs = null;
            using(fs = new FileStream("filename", FileMode.Create, FileAccess.ReadWrite))
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    fs.Write(buffer, 0, buffer.Length);

                    Console.Write("Enter any text: ");
                    str = Console.ReadLine();

                    int offset = buffer.Length;
                    buffer = Encoding.UTF8.GetBytes(str);
                    fs.Seek(offset, SeekOrigin.Begin); //відносно початку змістилися на певне число offset
                    fs.Write(buffer, 0, buffer.Length);

                    byte[] bufferToRead = new byte[fs.Length];
                    fs.Position = 0; // перемістились на початок файлу
                    int bytes = fs.Read(bufferToRead, 0, bufferToRead.Length);

                    string resalt = Encoding.UTF8.GetString(bufferToRead);
                    Console.WriteLine(resalt);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
