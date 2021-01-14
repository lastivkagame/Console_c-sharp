using Indexator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator.Classes
{
    class Bee: ICanWork, ICanFly  // реалізує два інтеріейси: ICanWork, ICanFly
    {
        Guid id;  // унікальний іденитифікатор 128 біт{1323-erer-12d -233ed}
        public Bee()
        {
            id = Guid.NewGuid();
        }

        public void DoWork()
        {
            Console.WriteLine("I work as Bee. I gather honey");
        }

        public void Fly()
        {
            Console.WriteLine("I can fly, becouse i'm BEE!");
        }
    }
}
