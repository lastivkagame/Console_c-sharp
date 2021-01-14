using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class Program
    {
        //Collections: узагальнені - Generics , неузагальнені
        static void Main(string[] args)
        {
            SortedList sl = new SortedList();  // може містити ключ/ значення

            sl.Add(5, "c++");
            sl.Add(2, "c#");
            sl.Add(3, "Java");
            sl.Add(1, "Python");

            sl[6] = "PHP";
            sl[8] = "SQL";
            sl[6] = "JS";

            PrintKeys(sl);
            PrintValues(sl);
            PrintAll(sl);

            Console.WriteLine("Contains key 8: " + sl.ContainsKey(8));
            Console.WriteLine("Contains value Python: " + sl.ContainsValue("Python"));

            int indexKey = sl.IndexOfKey(6);
            int indexValue = sl.IndexOfValue("C#");
            Console.WriteLine("index of key 6: {0}", indexKey);
            Console.WriteLine("index of value 6: {0}", indexValue);

            sl.RemoveAt(indexKey);
            PrintAll(sl);

            Console.WriteLine();
            Console.WriteLine();

            //DictionaryEntry - пара (ключ, значення)
            foreach (DictionaryEntry item in sl)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
        }

        private static void PrintAll(SortedList sl)
        {
            Console.WriteLine(" -SortedList-");
            for (int i = 0; i < sl.Count; i++)
            {
                Console.WriteLine("{0} ----- {1}", sl.GetKey(i), sl[sl.GetKey(i)]);
            }
        }

        private static void PrintValues(SortedList sl)
        {
            foreach (var item in sl.GetValueList())
            {
                Console.Write("{0}\t", item);
            }
            Console.WriteLine();
        }

        private static void PrintKeys(SortedList sl)
        {
            foreach (var item in sl.GetKeyList())
            {
                Console.Write("{0}\t", item);
            }
            Console.WriteLine();
        }
    }
}
