using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    partial class Airplane
    {
        const double MaxHoursAtSky = 15;
        public override string ToString() //перевантажений метод завдяки якому можна буде 
        {                        //всі нестатичні змінні класу у 2 стовпчики вивести(Console.WriteLine();)
            return $" 1.Name: {Name,-20} 6.FlightHours: {FlightHours}\n" +
                $" 2.Model: {Model,-19} 7.CountPairWings: {CountPairWings}\n" +
                $" 3.Number: {Number,-18} 8.ColorFuselage:  {ColorFuselage}\n" +
                $" 4.MaxSpeed: {MaxSpeed,-16} 9.Owner: {Owner}\n" +
                $" 5.Price: {Price,-19} 10.IsTurbineEngine: {IsTurbineEngine}";
        }

        public void Fly(double hours) // просто додає до зміної FlightHours передану к-сть годин
        {
            if (hours <= MaxHoursAtSky)
            {
                Console.WriteLine("Airplane " + Name + " is at sky now ");
                FlightHours += hours;
            }
            else
            {
                Console.WriteLine("You want too much!(Max hours at sky is 15 !)");
            }
        }
    }
}
