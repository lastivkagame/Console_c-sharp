using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events01
{
    class Program
    {
        class Account
        {
            public delegate void AccountHandler(string message);

            public event AccountHandler acc; // захищений делегат

            public int suma;
            //string owner;

            public Account()
            {
                suma = 1000;
            }
            public int Suma
            {
                get
                {
                    return suma;
                }
                set
                {
                    suma = value;
                }
            }
            public void Put(int money)
            {
                Suma += money;
                acc?.Invoke("DO Sumu add + " + money + "$");
            }

            public void Take(int money)
            {
                if (money > Suma)
                    acc?.Invoke("Nedostatno money on rahynok; Rahynok: " + suma + ", But you want take " + money);
                else
                {
                    Suma -= money;
                    acc?.Invoke("Action " + Suma);
                }
            }

            public override string ToString()
            {
                return Suma.ToString();
            }
        }
        static void Main(string[] args)
        {
            Account account = new Account();
            account.acc += Info;
            //account.acc = InfoToFile;
            account.Put(1000);
            Console.WriteLine("Suma = " + account);
            account.Take(3000);
            Console.WriteLine("Suma = " + account);

            Account account2 = new Account();
            account2.acc += InfoToFile;
            account2.acc += Info;
            account2.acc += (string message) => Console.WriteLine("Bye");
            account2.Put(1000);

            Console.WriteLine("Suma = " + account2);
            account2.Take(3000);
            Console.WriteLine("Suma = " + account2);
        }

        static void Info(string message)
        {
            Console.WriteLine(message);
        }

        static void InfoToFile(string message)
        {
            File.AppendAllText("acc.txt", message + "\n");
        }
    }
}
