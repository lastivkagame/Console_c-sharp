using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReaderWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            #region write in file using streamwriter
            //Console.Write("Enter some string: ");
            //string str = Console.ReadLine();

            //using (StreamWriter sw = new StreamWriter("streamfile"))
            //{
            //    sw.WriteLine("It was written by streamWriter: {0}", str);
            //    sw.Write("After replace: {0}", str.Replace('h', 'H')); 
            //}
            #endregion

            using (StreamReader sr = new StreamReader("streamfile"))
            {
                Console.WriteLine("File conteins: ");
                //Console.WriteLine(sr.ReadToEnd());

                int code;
                do
                {
                    code = sr.Read();

                    if (code != -1)
                    {
                        Console.Write((char)code);
                    }
                    //}while(sr.Peek() != -1);
                } while (!sr.EndOfStream);

                Console.WriteLine();
            }

            Console.Clear();

            using (StreamReader sr = new StreamReader("streamfile"))
            {
                Console.WriteLine("File conteins: ");

                int code;
                while (sr.Peek() != -1)
                //while ((code = sr.Read()) != -1)
                {
                    //Console.WriteLine((char)code);
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}
