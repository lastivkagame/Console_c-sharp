using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string - reference type
            //char[]
            //незмінюванний

            string line = new string('_', 80);
            Console.WriteLine(line);

            string first = "\n first line" + "\n second line \n";
            Console.WriteLine(first);

            char symbol = '*';
            //first[1] = symbol; - error! string read only!

            string code = @"C: \Program Files\MS visual"; //raw lines
            Console.WriteLine(code);

            string str;
            decimal number = 111123.45M;
            str = String.Format("This is decimal number {0:N4}", number);
            Console.WriteLine(str);
            str = $"Interpolation string{number}";
            Console.WriteLine(str);
            char[] symbols = code.ToCharArray();
            symbols[0] = 'D';
            code = new string(symbols);
            Console.WriteLine(code);

            string substr = new string(code.ToCharArray(), 3, 13);
            Console.WriteLine(substr);

            string one = "abc абв", two = "ABC АБВ";
            Console.WriteLine("{0} == {1}: {2}", one, two, one == two);
            Console.WriteLine("{0} ? {1}: {2}", one, two, one.CompareTo(two)); //порівняння методом від обєктів
            Console.WriteLine("{0} ? {1}: {2}", one, two, string.Compare(one, two, true)); // порівнняня без врахування регістру 
            Console.WriteLine("{0} ? {1}: {2}", one, two, String.CompareOrdinal(one, two)); //порівняння по коду символа

            Console.Clear();

            string text = "Доброго Дня!";
            int firstIndex = text.IndexOf('о');
            int lastIndex = text.LastIndexOf('о');

            Console.WriteLine("FirstIndex {0}", firstIndex);
            Console.WriteLine("LastIndex {0}", lastIndex);

            firstIndex = text.IndexOfAny("дб".ToCharArray());
            Console.WriteLine("firstOccurs {0}", firstIndex);
            Console.WriteLine(line);
            Console.WriteLine(text = text.ToUpper());
            Console.WriteLine(text);

            text = text.Replace("О", "!");
            Console.WriteLine(text);

            text = text.Replace("!", "");
            Console.WriteLine(text);

            Console.WriteLine(text.Remove(2, 2));
            Console.WriteLine(text.Remove(4));

            string info = @"Тут наведено перелік операторів що використовуються у мовах програмування C та C++. Усі наведені оператори присутні у C++. Якщо оператор також використовується у мові С, ";

            char[] separators = new[] { '.', ' ', '|' };
            string[] words = info.Split(/*separator*/".,|?-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Count = " + words.Length);

            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
