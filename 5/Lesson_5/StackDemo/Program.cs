using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable, ICLonaable, IDictionary, ICollection
            Stack stack = new Stack(new int[] { 11, 12, 2 });
            Queue queue = new Queue(stack);

            Print(stack);

            stack.Push("one");
            stack.Push("two");
            stack.Push(12.5);
            Print(stack);

            Console.WriteLine("-do delete-");
            while (stack.Count > 0)
            {
                Console.WriteLine("{0}", stack.Peek());
                stack.Pop();
            }

            Print(stack);
        }

        private static void Print(ICollection stack)
        {
            if (stack.Count < 0)
            {
                Console.WriteLine("-collection-");
                foreach (var item in stack)
                {
                    Console.Write("  " + item);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Collection is empty!");
            }
        }
    }
}
