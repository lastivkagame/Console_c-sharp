/*2. Визначити  xml - документ для збереження набору продуктів(назва, ціна, кількість).*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace task_2
{
    [Serializable]
    public class Product
    {
        [XmlElement("Name")]
        public string name;
        [XmlElement("Price")]
        public double price;
        [XmlElement("Count")]
        public int count;

        public Product(string name, double price, int count)
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public Product()
        {

        }

        public override string ToString()
        {
            return $" Name: {name,-15} PriceOne: {price,-15} Count: {count,-15}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product( "Lemon", 30.12, 4 ),
                new Product( "Tea", 15.60, 1 ),
                new Product( "Chocolate", 25.50, 2 ),
            };

            try
            {
                using (FileStream fs = new FileStream("xml_products.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(products.GetType());
                    xml.Serialize(fs, products);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            products.Clear();

            try
            {
                XmlSerializer xml2 = new XmlSerializer(products.GetType());
                products = (List<Product>)xml2.Deserialize(new FileStream("xml_products.xml", FileMode.Open));

                Console.WriteLine("\t\t - List Products - ");
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
