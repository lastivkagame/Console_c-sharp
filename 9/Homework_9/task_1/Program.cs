/*програма дослідження статистики Covid19
Використати api https://api.covid19api.com/summary
Десеріалізувати  json (так як на парі)
При виборі конкретної країни (наприклад, коли вводимо назву країни)- показати більш детальну статистику*/

using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClassCovid19 covid19 = null;

                using (WebClient web = new WebClient())
                {
                    string json = web.DownloadString("https://api.covid19api.com/summary");
                    covid19 = JsonConvert.DeserializeObject<ClassCovid19>(json);
                }

                string name = "";

                do
                {
                    Console.WriteLine("Weclome! Information about Covid19!");
                    Console.Write(@"For this enter country: ");
                    name = Console.ReadLine();

                    if (name != "exit")
                    {
                        Console.WriteLine("\n");

                        for (int i = 3; i > 0; i--)
                        {
                            Console.Write(i + " ... ");
                            Thread.Sleep(500);
                        }

                        Console.WriteLine("\n Found this: \n");

                        foreach (var item in covid19.Countries)
                        {
                            if (item.Country.Contains(name))
                            {
                                Console.WriteLine("Country: " + item.Country);
                                Console.WriteLine("CountryCode: " + item.CountryCode);
                                Console.WriteLine("Date: " + item.Date);
                                Console.WriteLine("TotalRecovered: " + item.TotalRecovered);
                                Console.WriteLine("TotalDeaths: " + item.TotalDeaths);
                                Console.WriteLine("TotalConfirmed: " + item.TotalConfirmed);
                                Console.WriteLine("Slug: " + item.Slug);
                                Console.WriteLine("NewRecovered: " + item.NewRecovered);
                                Console.WriteLine("NewDeaths: " + item.NewDeaths);
                                Console.WriteLine("NewConfirmed: " + item.NewConfirmed);
                                Console.WriteLine();
                            }
                        }

                        Console.WriteLine("\n\nIf you want exit entert 'exit'");
                        Console.WriteLine("\n Press something ...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\n       ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t Have a nice day! \t");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }

                } while (name != "exit");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("\n\n       ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t Have a nice day! \t");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
