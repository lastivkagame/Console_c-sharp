/*________________________________Події___________________________________________________

    Клас "Теплиця" (Hothouse) має властивість "Температура", а також знає мінімальну та максимально
припустимі температури.

    Коли температура стає більшою за максимальну клас Теплиця виводить повідомлення та ініціює подію
"надто гаряче" (TooHot)

Коли температура стає меншою за мінімальну клас Теплиця виводить повідомлення та ініціює 
подію "надто холодно" (TooCold)
Коли температура повертається у межі норми клас Теплиця виводить повідомлення та ініціює подію "Все добре" (Well)

Події теплиці несуть у собі посилання на об'єкт теплиці (delegate void HotHouseDeleg(HotHouse house))

    Клас "Нагрівач" (Heater) має  метод гріти (Warm) котрий збільшує температуру у теплиці на 5 градусів.
Warm(HotHouse house)

    Клас "Охолоджувач" (Cooler) має  метод охолоджувати (Cool) котрий зменшує температуру у теплиці на 5 градусів.

    Ці методи виводять повідомлення у консоль про те хто і що робить.

Main() створює екземпляр теплиці та по екземпляру нагрівача та охолоджувача і підписує їх на події теплиці,
так щоби вони вмикалися і вимикалися у відповідь на події теплиці.

Сама Main() імітує вплив погоди на теплицю, збільшуючи чи зменшуючи температуру в ній на випадкове значення 
від -2 до +2 градусів. Це все відбувається у циклі, щоразу очікуючи натискання пропуску (чи довільного символу,
Console.ReadKey()).У консолі маємо бачити як змінюється температура у теплиці, як вмикаються та 
вимикаються пристрої.*/

using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Hothouse ---");

            double min = 0;
            double max = 0;
            double temperature = 0;
            bool flag = false;

            do
            {
                try
                {
                    flag = false;
                    Console.Write("Enter tempaerature at hothouse: ");
                    temperature = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    flag = true;
                    Console.WriteLine(ex.Message);
                }
            } while (flag);


            do
            {
                try
                {
                    Console.Write("Enter min temperature(must be low than max on 5+ degree minimum): ");

                    min = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter max temperature(must be more than min on 5+ degree minumum): ");

                    max = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (max <= min || max - min <= 5 || temperature < min);

            Hothouse hothouse = new Hothouse(min, max, temperature);
            Cooler cooler = new Cooler();
            Heater heater = new Heater();

            hothouse.toohot += cooler.Cool;
            hothouse.toocold += heater.Warm;
            hothouse.well += WellTemperarure;

            flag = true;
            Random rand = new Random();
            char exit = 'y';

            do
            {
                Console.WriteLine("now temperature: " + hothouse.Temperature);

                if (rand.Next(2) == 0)
                {
                    Console.WriteLine("Temperature in hothouse rose by 2 degreees due to the weather");
                    hothouse.Temperature += 2;
                }
                else
                {
                    Console.WriteLine("Temperature in hothouse dropped by 2 degreees due to the weather");
                    hothouse.Temperature -= 2;
                }

                Console.WriteLine("now temperature: " + hothouse.Temperature);

                Console.WriteLine("\n\nIf you want exit ener 'n' else enter some else");
                Console.Write("\n Press something ...  ");

                try
                {
                    exit = Convert.ToChar(Console.ReadKey());
                }
                catch (Exception)
                {
                    Console.WriteLine();
                }

                if (exit == 'n')
                {
                    flag = false;
                }

                Console.Clear();
            } while (flag);
        }

        public static void WellTemperarure(Hothouse house)
        {
            Console.WriteLine("Temperature was well");
        }
    }
}
