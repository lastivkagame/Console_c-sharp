using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate02
{
    class Program
    {
        delegate void MyDelegete(string str);
        static void Hello(string s)
        {
            Console.WriteLine("Hello {0}", s);
        }

        static void GoodEvening(string s)
        {
            Console.WriteLine("GoodEvening {0}", s);
        }

        delegate int SimpleDelegate(int str);
        static void Bye(string s)
        {
            Console.WriteLine("Bye {0}", s);
        }

        static int Foo(int s)
        {
            if (s == 0)
                throw new Exception("Invalid arg");
            return 1;
        }

        static int Bar(int s)
        {
            return 2;
        }
        static void Main(string[] args)
        {
            #region Delegate
            //MyDelegete a, b, c, d;
            //a = new MyDelegete(Hello);
            //b = new MyDelegete(Bye);
            //c = a + b;

            //d = c - a;

            //Console.WriteLine("Invoke A: ");
            //a("A");
            //Console.WriteLine();

            //Console.WriteLine("Invoke B: ");
            //b("B");
            //Console.WriteLine();

            //Console.WriteLine("Invoke C: ");
            //c("C");
            //Console.WriteLine();

            //Console.WriteLine("Invoke D: ");
            //d("D");
            //Console.WriteLine(); 
            #endregion

            #region Multicast
            //Console.WriteLine();
            //// багатоадресність делегата
            //MyDelegete test = Hello;
            //test += Bye;
            //test += Bye;
            //Console.WriteLine("test: ");
            //test("test");

            //test -= Hello;
            //test -= Bye;
            //test("test");
            //test -= Bye;

            //test?.Invoke("test");
            //Console.WriteLine();
            //test += GoodEvening;
            //test += Hello;
            //test += Bye;
            //test += Hello;
            //test += Bye;
            //test -= Hello;

            //test("test"); 
            #endregion

            SimpleDelegate del = Foo;
            del += Bar;
            del += Foo;
            Console.WriteLine(del(4));
            Console.WriteLine();

            foreach (var item in del.GetInvocationList())
            {
                Console.WriteLine(item.DynamicInvoke(4));
            }
        }
    }
}
