using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    enum TypeDrink
    {
        NonСarbonatedDrink,
        СarbonatedDrink,
        HotDrink,
        MilkDrink,
        AlcoholDrink,
    }

    #region comparators
    class CompareByPrice : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return Convert.ToInt32((x as Drink).Price > (y as Drink).Price);
        }
    }

    class CompareByNumberOfcal : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return Convert.ToInt32((x as Drink).NumberOfcal < (y as Drink).NumberOfcal);
        }
    }

    class CompareByProducer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return string.Compare((x as Drink).Producer, (y as Drink).Producer);
        }
    }

    class CompareByPriceDrink : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return Convert.ToInt32((x as Drink).Price < (y as Drink).Price);
        }
    }

    class CompareByNumberOfcalDrink : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return Convert.ToInt32((x as Drink).NumberOfcal > (y as Drink).NumberOfcal);
        }
    }

    class CompareByProducerDrink : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return string.Compare((x as Drink).Producer, (y as Drink).Producer);
        }
    }
    #endregion

    class Drink : IComparable, IComparable<Drink>, IEquatable<Drink>
    {
        private string name;
        private TypeDrink typeDrink;
        private string producer;
        private double numberofcal;
        private double price;

        public double Price
        {
            get { return price; }
            set {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new Exception("Price can't be low than 0");
                }
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TypeDrink Typedrink
        {
            get { return typeDrink; }
            set { typeDrink = value; }
        }

        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }

        public double NumberOfcal
        {
            get { return numberofcal; }
            set
            {
                if (value > 0)
                {
                    numberofcal = value;
                }
                else
                {
                    throw new Exception("Numberofcal can't be low than 0");
                }
            }
        }

        public Drink(string name = "none", TypeDrink typeDrink = 0, string producer = "none", double numberofcal = 1, double price = 1)
        {
            Name = name;
            Typedrink = typeDrink;
            Producer = producer;
            NumberOfcal = numberofcal;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name,-15} TypeDrink: {Typedrink,-20} Producer: {Producer,-15} NumberOfcal: {NumberOfcal,-7} Price: {Price}";
        }

        public int CompareTo(object obj)
        {
            return string.Compare(Typedrink.ToString(), (obj as Drink).Typedrink.ToString());
        }

        public int CompareTo(Drink other)
        {
            return string.Compare(Name, other.Name);
        }

        public bool Equals(Drink other)
        {
            return string.Equals(Typedrink.ToString(), (other as Drink).Typedrink.ToString());
        }

        public bool Equals(object other)
        {
            if(other is Drink)
            {
                return string.Equals(Name, (other as Drink).Name);
            }
            return string.Equals(Name, other.ToString());
        }
    }
}