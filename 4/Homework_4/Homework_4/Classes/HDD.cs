using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class HDD : Disk
    {
        public HDD() { }

        public HDD(string memory, int memSize) : base(memory, memSize) { }
        public string GetName()
        {
            return "HDD";
        }
    }
}
