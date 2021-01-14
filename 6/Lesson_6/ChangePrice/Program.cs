using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangePrice
{
    class Program
    {
        delegate void PriceChangeHandler();

        class Product
        {
            public event PriceChangeHandler PriceChanged;
            private float price;
            private string name;

            public Product(string name, float price)
            {
                Name = name;
                Price = price > 0 ? price : 100;
            }

            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                }
            }


            public float Price
            {
                get { return price; }
                set
                {
                    if (value < price)
                        PriceChanged();
                    price = value;
                }
            }

        }
        static void Main(string[] args)
        {
            Product p1 = new Product("water", 35);
            p1.PriceChanged += infoAboutChange;

            p1.Price = 20;
        }

        private static void infoAboutChange()
        {
            Console.WriteLine("Price was changed!!!");
        }
    }
}
