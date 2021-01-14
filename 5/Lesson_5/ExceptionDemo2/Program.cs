using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////try
            ////{
            //    int a = 0;
            //    int res = 5 / a;
            //    Console.WriteLine(res); //non print becouse after error
            ////}
            ////catch(Exception ex){ }

            //Console.WriteLine("after divide");

            try
            {
                Console.WriteLine("Before some method ...");
                SomeMethod();
                Console.WriteLine("After SomeMethod()...");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message: = {0}", ex.Message);
                Console.WriteLine("Source: = {0}", ex.Source);
                Console.WriteLine("StackTrace: = {0}", ex.StackTrace);
                Console.WriteLine("TargetSite: = {0}", ex.TargetSite);
                Console.WriteLine("HelpLink: = {0}", ex.HelpLink);
                Console.WriteLine("Data[Time]: = {0}", ex.Data["Time"]);
                Console.WriteLine("Data[Number]: = {0}", ex.Data["Number"]);
            }
        }

        static void SomeMethod()
        {
            AnotherMethod();
        }

        private static void AnotherMethod()
        {
            Random rand = new Random();
            int value;
            if ((value = rand.Next(0, 4)) == 0) 
            {
                Exception ex = new Exception("this my custom exception");
                ex.HelpLink = "https://google.com";
                ex.Data["Time"] = DateTime.Now;
                ex.Data["Number"] = value;
                throw ex;
            }
            Console.WriteLine("Method works, number = {0}", value);
        }
    }
}
