using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ - Lanquage integrated query
            //objects
            //array
            //data bases
            //xml
            //Entity
            //dbset

            string[] games = new[] { "FIFA", "GTAS", "FallOut", "Call of Duty", "World of Tanks", "FIFA", "NFS", "FIFA", "CS:GO" };
            PrintArray(games);

            var test = from game in games   //з масиву games 
                       where game.Length > 5  // якщо для деякого поточного game виконується умова(довжина більша за 5)
                       //orderby game //сортує по зрозстанню в алфавітному порядку 
                       //orderby game ascending     // сортує по зрозстанню в алфавітному порядку
                       orderby game descending     // сортує по спаданню в алфавітному порядку
                       select game;          //(завжди закінчується ним) то вибери даний елемент і додай у вихідну колекцію

            Console.WriteLine();
            Console.WriteLine();

            PrintArray(test);

            List<string> startWithF = (from s in games
                                       where s.StartsWith("F") // починається з ....
                                       select s).Distinct().ToList(); // без повтоень

            Console.WriteLine();
            Console.WriteLine();

            PrintArray(startWithF);

            string FirstGame = (from g in games
                                where g.Length > 15
                                select g).FirstOrDefault(); // FirstOrDefault якщо немає - повертає значенння за замовчуванням
                                                            //select g).First() - //First повертає помилку
                                                            // якщо елементів у ослідовності немає


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(FirstGame);

            string first = games.Where(x => x.Length > 5).FirstOrDefault();
            Console.WriteLine(first);
        }

        private static void PrintArray(IEnumerable<string> games)
        {
            foreach (var item in games)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
