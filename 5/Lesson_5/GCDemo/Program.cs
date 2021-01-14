using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //GC ----  Garbage Collector

            Test();

            Owner o;
            using (o = new Owner())
            {

                for (int i = 0; i < 5; i++)
                {
                    o = new Owner();
                }
            }
            o.Dispose();
            Test();
        }

        private static void Test()
        {
            Owner o = new Owner();

            for (int i = 0; i < 5; i++)
            {
                o = new Owner();
            }
        }

        public class Owner:IDisposable
        {
            static int staticNumber;
            int number;
            FileStream fs = new FileStream("file", FileMode.Create);

            static Owner()
            {
                staticNumber = 0;
            }

            public Owner()
            {
                staticNumber++;
                number = staticNumber;
            }

            ~Owner()  // фіналізатор, виклик автоматично GC перед вивільненням памяті
            {
                //звальняємо некеровані ресурси
                Console.WriteLine("~Owner finalizer for" + number);
                Console.WriteLine();
                Dispose();
            }

            public void Dispose()
            {
                fs.Dispose();
            }
        }
    }
}
