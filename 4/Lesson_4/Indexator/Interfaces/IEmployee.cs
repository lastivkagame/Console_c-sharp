using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator.Interfaces
{
    interface IEmployee
    {
        void DoWork();

        uint Salry { get; set; }
    }

    interface ICanRun
    {
        void Run();

        void Walk();
    }
}
