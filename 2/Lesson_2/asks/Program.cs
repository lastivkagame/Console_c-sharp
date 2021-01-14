using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task_3();
        }

        static void Task_3()
        {
            bool isNeed = false;
            Console.Write("Enter something: ");
            string symbol = Console.ReadLine();
            //string resalt = "";

            for (int i = 0; i < symbol.Length; i++)
            {
                var symbolChar = Convert.ToInt32(symbol[i]);

                if (symbol[i] >= 65 && symbol[i] <= 90)
                {
                    symbolChar += 32;
                    isNeed = true;
                }
                else if (symbol[i] >= 97 && symbol[i] <= 122)
                {
                    symbolChar -= 32;
                    isNeed = true;
                }


                if (isNeed == true)
                {                                                             //спитати чому так не працює
                    symbol = symbol.Replace(symbol[i], Convert.ToChar(symbolChar));
                    isNeed = false;
                }
            }

            Console.WriteLine("Rezalt: " + symbol);
     
        }
    }
}
