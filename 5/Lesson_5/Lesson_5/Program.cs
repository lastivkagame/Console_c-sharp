using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extensions Methods - статичні методи деякого статичного класу. Викликаються через екземпляр класу
            //Використовують, коли неможливо наслідувати але необхідно додати функціонал класу

            string test = "1 have 2 cats and 3 dogs with parrots";
            Console.WriteLine("CountDigits: " + test.CountDigits());

            int[] arr = { 45, 23, 12, 8, -4, 6 };
            arr.Print();
            Console.WriteLine("Pair digits: " + arr.CountPairDigits());
            Console.WriteLine("CountIf: " + arr.CountIf(true));
        }
    }
}
