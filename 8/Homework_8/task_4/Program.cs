/*Розробити клас «Рахунок для оплати». У класі передбачити наступні поля:
- оплата за день;
- кількість днів;
- штраф за один день затримки оплати;
- кількість днів затримки оплати;
- сума до оплати без штрафу (обчислюване поле);
- штраф (обчислюване поле);
- загальна сума до оплати (обчислюване поле).
Розробити додаток, в якому необхідно продемонструвати використання цього класу, результати
повинні записуватися та зчитуватися з файлу.*/

using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace task_4
{
    [Serializable]
    public class InvoiceForPayment
    {
        [XmlIgnore]
        public double SalaryForDay { get; set; } //оплата за день

        [XmlIgnore]
        public int CountDay { get; set; } //кількість днів

        [XmlIgnore]
        public int FineOneDayDelayPayment { get; set; } // штраф за один день затримки оплати

        [XmlIgnore]
        public int CountDayDelayPayment { get; set; } //кількість днів затримки оплати;

        [XmlElement("SumBePaidWithoutFine")]
        public double SumBePaidWithoutFine { get; set; } // сума до оплати без штрафу (обчислюване поле)

        [XmlElement("Fine")]
        public double Fine { get; set; }  // штраф (обчислюване поле)

        [XmlElement("TotalAmountBePaid")]
        public double TotalAmountBePaid { get; set; } // загальна сума до оплати (обчислюване поле).

        public InvoiceForPayment()
        {

        }

        public InvoiceForPayment(double salaryForDay, int countDay, int fineOneDayDelayPayment, int countDayDelayPayment)
        {
            SalaryForDay = salaryForDay;
            CountDay = countDay;
            FineOneDayDelayPayment = fineOneDayDelayPayment;
            CountDayDelayPayment = countDayDelayPayment;

            SumBePaidWithoutFine = SalaryForDay * CountDay;
            Fine = FineOneDayDelayPayment * CountDayDelayPayment;
            TotalAmountBePaid = SumBePaidWithoutFine + Fine;
        }

        public override string ToString()
        {
            return $" SumBePaidWithoutFine = {SumBePaidWithoutFine}; \t Fine = {Fine}; \t TotalAmountBePaid = {TotalAmountBePaid}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InvoiceForPayment payment;
            InvoiceForPayment read_payment;
            XmlSerializer xml = new XmlSerializer(typeof(InvoiceForPayment));

            string name;
            double salaryForDay;
            int countDay, fineOneDayDelayPayment, countDayDelayPayment;
            int choose = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("\t -InvoiceForPayment-");
                Console.WriteLine("1. You want read info from file");
                Console.WriteLine("2. You want create and write into file");
                Console.WriteLine("3. Exit");

                try
                {
                    Console.Write("Enter number: ");
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Write("Inccorect direction! ");
                    Console.WriteLine(ex.Message);
                }

                switch (choose)
                {
                    case 1:
                        Console.Write("Enter name of file: ");
                        name = Console.ReadLine();
                        Console.Clear();

                        try
                        {
                            read_payment = (InvoiceForPayment)xml.Deserialize(new FileStream(name, FileMode.Open));
                            Console.WriteLine(read_payment);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("\n Press something ...");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Write("Enter name of file: ");
                        name = Console.ReadLine();

                        Console.Write("Enter salary for day: ");
                        salaryForDay = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter count day: ");
                        countDay = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter fine one day delay payment: ");
                        fineOneDayDelayPayment = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter count day delay payment: ");
                        countDayDelayPayment = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            payment = new InvoiceForPayment(salaryForDay, countDay, fineOneDayDelayPayment, countDayDelayPayment);
                            Console.WriteLine(payment);

                            using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                            {
                                XmlSerializer xml2 = new XmlSerializer(typeof(InvoiceForPayment));

                                try
                                {
                                    xml2.Serialize(fs, payment);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("\n Press something ...");
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\tHave a nice day!\t\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(4000);
                        break;
                    default:
                        break;
                }

            } while (choose != 3);

        }
    }
}
