using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    partial class Animal
    {
        /*private*/
        string name; //= "empty"; 
        private int age; //0
                         /*public*/
        double weight;
        const int LEGS = 4;
        public readonly int tails;

        public Animal(string name = "empty") : this(name, -1, 0) { }

        public Animal(string name, int age, double weight)
        {
            tails = 1; //ok, readonly
            Name = name;
            Age = age;
            this.weight = weight;
        }

        public void Say()
        {
            Console.WriteLine($"Hi! I'm {name}, age = {age}, weight = {weight} kg");
        }

        public string Owner { get; set; } //автопроперті - aвтоматичні властивості

        public override string ToString()
        {
            return $"ToString(): Hi! I'm {name}, age = {age}, weight = {weight} kg";
        }

        public string GetName()
        {
            return name;
        }

        public int GetAge()
        {
            return age;
        }

        public double GetWeight()
        {
            return weight;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                    age = value;
                else
                    age = 0;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                weight = value;
            }
        }
    }

    internal class Program //internal - видимий в межах збірки (public для своїх)
    {
        struct Dimensions
        {
            public int width; //=10 - error!
            public int length;

            //publuc Dimensions() - erorr!
            public Dimensions(int w, int l)
            {
                width = w;
                length = l;
            }

            public void Print()
            {
                Console.WriteLine($"Width: {width}, Length: {length}");
            }
        }

        //struct AmericanDimensions: Dimensions - не можна наслідувати але інтерфейси можна

        static void Main(string[] args)
        {
            #region structures
            //Dimensions dimensions = new Dimensions(12, 14);
            //dimensions.Print();

            //Dimensions d2 = new Dimensions();
            //d2.Print(); 
            #endregion

            Animal a1 = new Animal("Cheburek", 2, 8);
            a1.Say();

            Animal a2 = new Animal(weight: 5, name: "Tuzik", age: 3); //іменованні параметри
            a2.Say();

            Animal a3 = null; //не  проініціалізоване посилання
            Console.WriteLine(a3 == null);
            a3 = new Animal("third");
            a3.Say();

            //Console.Clear();
            Animal[] arr = { a1, a2, a3, new Animal("Fourth", 1, 1) };
            arr[0].Say();
            arr[3].Say();

            Console.WriteLine(arr[1] /*.ToString()*/);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.Clear();

            Console.WriteLine(a3);
            a3.Name = "Murzik"; // set "Murzik - value"
            Console.WriteLine(a3.Name);
            //a3.Weight = 3 - error! read only 
            Console.WriteLine(a3);


        }
    }
}
