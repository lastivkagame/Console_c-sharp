using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder(100);
            Console.WriteLine("sb: {0}, capasity = {1}", stringBuilder, stringBuilder.Capacity);
            StringBuilder sb = new StringBuilder("text");
            Console.WriteLine("sb: {0}, capacity = {1}, length = {2}", sb, sb.Capacity, sb.Length);
            sb.Append("__________");
            Console.WriteLine(sb);
            sb.Insert(5, "Insert info");
            Console.WriteLine(sb);
            sb.Replace("e", "E");
            Console.WriteLine(sb.ToString());
            sb.Remove(5, 5);
            Console.WriteLine(sb);
        }
    }
}
