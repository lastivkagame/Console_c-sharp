using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWriterReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("binaryFile", FileMode.Create)))
            {
                bw.Write("Written by binary writter");
                bw.Write(1 == 1);
                bw.Write(34.67);
                bw.Write(671);
            }

            string str;
            bool flag;
            double value;
            int number;

            using (FileStream fs = new FileStream("binaryfile", FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    str = br.ReadString();
                    flag = br.ReadBoolean();
                    value = br.ReadDouble();
                    number = br.ReadInt32();
                }
            }

            Console.WriteLine("Read from binary file: ");
            Console.WriteLine(" String: {0} \n Boolean: {1} \n Double: {2} \n Int: {3} \n", str, flag, value, number);
        }
    }
}
