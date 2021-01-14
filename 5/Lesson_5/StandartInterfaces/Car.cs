using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInterfaces
{
    class CompareCars : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Car && y is Car)
            {
                return string.Compare((((Car)x).Brand), (((Car)y).Brand));
            }
            throw new ArgumentException();
        }
    }

    class CompareModel : IComparer
    { 
        public int Compare(object x, object y)
        {
            if (x is Car && y is Car)
            {
                return string.Compare((((Car)x).Model), (((Car)y).Model));
            }
            throw new ArgumentException();
        }
    }
    class Car: IComparable, ICloneable
    {
        public string Brand { get; set; }

        public string  Model { get; set; }

        public int Year { get; set; }

        public Owner Owner { get; set; }

        public int CompareTo(object obj)
        {
            return Year.CompareTo((obj as Car).Year);
        }

        public object Clone()
        {
            //є поверхневе копіювання та глибоке
            Car temp = (Car)this.MemberwiseClone(); // поверхнева копія
            temp.Owner = new Owner { Id = this.Owner.Id, Name = this.Owner.Name };
            //return this.MemberwiseClone();
            return temp;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} --- {Year} year. Owner: {Owner}";
        }
    }

    public class Owner
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return $"{Name} --- {Id}";
        }
    }

    class Garage : IEnumerable
    {
        Car[] cars;

        public Garage(int size)
        {
            cars = new Car[size > 0 ? size : 3];
        }

        public Car this[int index]
        {
            get
            {
                if (index >= 0 && index < cars.Length)
                {
                    return cars[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
            }
            set
            {
                if (index >= 0 && index < cars.Length)
                {
                    cars[index] = value;
                }
            }
        }

        public int Size
        {
            get
            {
                return cars.Length;
            }
        }

        // тож працює
        //public IEnumerator GetEnumerator()
        //{
        //    return cars.GetEnumerator();
        //}

        public IEnumerator GetEnumerator()
        {
            foreach (Car item in cars)
            {
                yield return item; // створили перелічувач, return - це значення, яке повертає наш перелічувач
                //yield - повертає управління викликаючому методу, але стан викликаного елемента зберігаєть 
                //і він продовжує всоє виконання
            }
            //можна дописати сюди ще один foreach з іншим масивом
        }

        public void Sort()
        {
            Array.Sort(cars);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(cars, comparer);
        }
    }
}
