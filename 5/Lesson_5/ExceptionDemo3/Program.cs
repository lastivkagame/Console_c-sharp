using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                A();
                B();
                C(null);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Divide by zero!" + ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Inccorect format!" + ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Argument is null!" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void A()
        {
            try
            {
                int res = 1 / int.Parse("0");
            }
            catch
            {
                throw; //(перегенеруй, передай вище)викидання виключення DivideByZeroException
            }
        }

        static void B()
        {
            try
            {
                int res = 1 / int.Parse("ab");
            }
            catch(FormatException ex)
            {
                throw; //(перегенеруй, передай вище)викидання виключення FormatException
            }
        }

        static void C(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value"); //(перегенеруй, передай вище)викидання виключення FormatException
            }
        }
    }
}
