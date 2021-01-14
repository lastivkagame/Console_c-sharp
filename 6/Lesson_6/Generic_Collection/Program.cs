using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string[] words = { "car", "train", "bus", "plane" };
            list.AddRange(words);

            foreach (var item in words)
            {
                list.Add(item);
            }

            string[] array = list.ToArray();
            //list.Clear(); //clean all list
            Console.WriteLine("Capasity: " + list.Capacity);

            if (list.Contains("train"))
            {
                list.Remove("train");
            }

            Print(list);
            string el = list.Find(x => x.StartsWith("b"));
            Console.WriteLine("found el: "+ el);
        }

        //private static void Print(ICollection<string> list)
        private static void Print(List<string> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
