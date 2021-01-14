using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Interfaces
{
    interface IRemoveableDisk
    {
        bool HasDisk { get; } // для перевірки чи вставлений диск
        void Insert(); // вставити диск
        void Reject(); // вийняти диск
    }
}
