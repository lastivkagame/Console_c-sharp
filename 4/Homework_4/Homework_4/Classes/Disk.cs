using Homework_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class Disk : IDisk
    {
        private string memory;
        private int memSize;

        public int MemSize
        {
            get { return memSize; }
            set { if (value > 0) { memSize = value; } }
        }

        public string Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public Disk()
        {
            Memory = "-_-";
            MemSize = 10;
        }
        public Disk(string memory, int memSize)
        {
            this.memory = memory;
            this.memSize = memSize;
        }

        public virtual string GetName()
        {
            return GetType().Name;
        }

        public string Read() // "зчитати з диску"
        {
            return Memory;
        }

        public void Write(string text)  // "записати на диск"
        {
            if (text.Length + Memory.Length > MemSize)
            {
                Console.WriteLine("Error! On this disk is not enough memory to write!");
            }
            else
            {
                Memory += text;
            }
        }
    }
}
