using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        public static object Directoty { get; private set; }

        static void Main(/*string[] args*/)
        {
            #region Console methods
            //Console.ForegroundColor = ConsoleColor.Red;//колір тексту
            //Console.BackgroundColor = ConsoleColor.Gray; //колір родложки
            //Console.Clear(); //очищає консоль
            //Console.WriteLine("Hello World!"); //cout  with endl
            //Console.OutputEncoding = Encoding.Unicode;
            //// Console.OutputEncoding = Encoding.UTF8; //працює проте залежить від компа
            //Console.Write("Привіт світ!\n"); //cout without endl
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Title = "My first proj via c#"; //назва на консолі

            ////розміри консолі
            //// Console.WindowHeight = 10; 
            //// Console.WindowWidth = 40;

            ////Program pr = new Program();
            ////pr.Print(); //якщо без static
            //Print();

            //cw tab tab ----snippet for Console.WriteLine() 
            #endregion

            //Ctrl k s - snippet for region and other 

            //Object(ToString(), GetHashCode(),GetType(),Equal(), ReferenceEquel())
            // | > int32, boolean, String, Data, Array, DataTime 

            //int, double, float, char, bool, decimal - найбільший, int32,int64 (at c++ long)

            #region Types
            //int number = 12;
            //Console.WriteLine("Number = " + (number + 15) + " ; Type = " + number.GetType());

            //float fnumber = 13.6f; //неявно не конвертне
            //Console.WriteLine("Float number = {0}, type = {1}", fnumber, fnumber.GetType());

            //decimal dnumber = 15.5m;
            //Console.WriteLine("Float number = {0}, type = {1}", dnumber, dnumber.GetType());

            //double dblnumber = 15.5;
            //Console.WriteLine("Float number = {0}, type = {1}", dblnumber, dblnumber.GetType());

            //char symbol = (char)65;
            //char nsymbol = 'n';
            //Console.WriteLine("Float number = {0}, type = {1}", symbol, symbol.GetType());

            //bool flag = true;
            //Console.WriteLine("Float number = {0}, type = {1}", flag, flag.GetType());

            //Console.Clear();
            //Console.WriteLine($"{ symbol} is letter = {Char.IsLetter(symbol)}" );
            //Console.WriteLine($"{ symbol} is letter = {Char.IsDigit(symbol)}" );
            //Console.WriteLine($"{ symbol} is letter = {Char.ToLower(symbol)}" );
            //Console.WriteLine($"{ symbol} is letter = {Char.ToUpper(symbol)}" );

            //if (number < fnumber)
            //{
            //    Console.WriteLine("some");
            //}

            ////Console.Clear(); 
            #endregion

            #region String and other types
            ////Console.Write("Enter some string: ");
            ////string str = Console.ReadLine();
            ////Console.WriteLine("your string: " + str);
            ////Console.WriteLine("your string: " + Console.ReadLine());

            //Console.Clear();

            //Console.WriteLine("Enter two digits: ");
            //int a = Convert.ToInt32(Console.ReadLine()); //v-1 приймає фактично все
            //try
            //{
            //    int b = Int32.Parse(Console.ReadLine());    //v -2 приймає лише рядок і приводить
            //    Console.WriteLine($"{a} + {b} = {a + b}"); //інтерфуляція рфдків
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.Clear(); 
            #endregion

            #region Switch and if
            //double num;
            //if (double.TryParse(Console.ReadLine(), out num))  // out - вихідний параметр
            //{                           //змінна, к-сть сиволів, знаки після коми
            //    Console.WriteLine("Sqrt({0,3}) = {1,-3:N3}", num, Math.Sqrt(num));
            //}

            //Console.WriteLine(ShowDay(Console.ReadLine()));
            //var temp = "hello";  //строга типізація на етапі компіляції
            //dynamic tempD = 12;  //тип визначається на етапі виконання
            //tempD = "hello"; 
            //Console.WriteLine(temp.GetType()); 
            #endregion

            #region Do while
            //do
            //{
            //    Console.Write(".");
            //} while (Console.ReadKey().Key != ConsoleKey.Escape); 
            #endregion

            #region foreach
            // string text = "To be or not to be???";
            // //foreach(var item in text)
            //foreach(char item in text) //не міняє свій елемент - read only cycle - не можна змінити item
            // {
            //     if(Char.IsUpper(item))
            //     Console.Write(Char.ToLower(item) + ".");
            //     else
            //         Console.Write(Char.ToUpper(item) + ".");
            //     //item = '!' // error
            // }
            // Console.WriteLine(); 
            #endregion

            
        }

        static double Div(double a, double b)
        {
            if (b != 0)
            {
                return a / b;
            }
            throw new ArgumentException("parametr b was 0");
        }

        private static string ShowDay(string day)
        {
            switch (day)
            {
                case "Sunday":
                case "Saturday":
                    return " Weekend";
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    return "Work day";
                default: return "not day name";
            }
        }

        static void Print()
        {
            Console.WriteLine("Date: " + DateTime.Now);
        }
    }
}
