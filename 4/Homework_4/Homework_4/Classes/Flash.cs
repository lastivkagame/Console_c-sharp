using Homework_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Classes
{
    class Flash : Disk, IRemoveableDisk
    {
        protected bool hasDisk = true; // для перевірки чи є диск

        bool IRemoveableDisk.HasDisk => hasDisk; // для перевірки чи є диск

        public void Insert() // вставити диск
        {
            if (hasDisk == false)
            {
                hasDisk = true;
                Console.WriteLine("Disk was insert");
            }
            else
            {
                Console.WriteLine("Error! No insert, becouse already disk was inset!");
            }
        }

        public void Reject() // вийняти диск
        {
            if (hasDisk)
            {
                hasDisk = false;
                Console.WriteLine("Disk was reject");
            }
            else
            {
                Console.WriteLine("Error!No reject, becouse already disk was reject");
            }
        }

        public string GetName()
        {
            return "Flash";
        }

        public Flash() { }

        public Flash(string memory, int memSize) : base(memory, memSize) { }
    }
}
