using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Interfaces
{
    interface IPrintInformation
    {
        string GetName(); // повертає імя присторю
        void Print(string str); // друкує те що передадуть
    }
}
