using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonCurrency
{
    class Program
    {
        //class Currency
        //{
        //    public string ccy { get; set; }
        //    public string base_ccy { get; set; }
        //    public double buy { get; set; }
        //    public double sale { get; set; }
        //}
        static void Main(string[] args)
        {
            //List<Currency> currencies = null;

            //using(WebClient web = new WebClient())
            //{
            //    string json = web.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            //    currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
            //}

            //foreach (var item in currencies)
            //{
            //    Console.WriteLine($"{item.ccy} ---- {item.base_ccy}");
            //    Console.WriteLine($"{item.buy} ---- {item.sale}");
            //}

            List<Hero> heros = null;

            using (WebClient web = new WebClient())
            {
                string json = web.DownloadString("http://hp-api.herokuapp.com/api/characters");
                heros = JsonConvert.DeserializeObject<List<Hero>>(json);
            }

            string nameHero = "";
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ConsoleColor currentBackground = ConsoleColor.White;

            do
            {

                Console.WriteLine("Weclome! You can find any hero from film 'Harry Potter'!");
                Console.Write(@"For this enter his/her naeme: ");
                nameHero = Console.ReadLine();

                Console.WriteLine("\n");

                for (int i = 3; i > 0; i--)
                {
                    Console.Write(i + " ... ");
                    Thread.Sleep(500);
                }

                Console.WriteLine("\nFound this: \n");

                foreach (var item in heros)
                {
                    if (item.name.Contains(nameHero))
                    {
                        Console.WriteLine("Actor: " + item.actor);
                        Console.WriteLine("Name: " + item.name);
                        Console.WriteLine("Gender: " + item.gender);
                        Console.WriteLine("DateOfBirth: " + item.dateOfBirth);
                        Console.WriteLine("Wand: " + item.wand.ToString());

                        string coloreye = item.eyeColour[0].ToString();
                        coloreye = coloreye.ToUpper();
                        
                        for (int i = 1; i < item.eyeColour.Length; i++)
                        {
                            coloreye += item.eyeColour[i];
                        }

                        foreach (var color in colors)
                        {
                            if (color.ToString().Contains(coloreye))
                            {
                                currentBackground = color;
                                break;
                            }
                        }

                        Console.Write("EyeColour: ");
                        Console.ForegroundColor = currentBackground;
                        Console.WriteLine(item.eyeColour);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }

                Console.WriteLine("\n\nIf you want exit entert 'exit'");
                Console.WriteLine("\n Press something ...");
                Console.ReadKey();

                Console.Clear();

            } while (nameHero != "exit");
        }
    }
}
