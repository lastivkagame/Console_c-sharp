using Homework_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return "Monitor";
        }

        public void Print(string str)
        {
            Console.WriteLine(" " + GetName() + " works...\n");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine(str);
        }
    }
}
