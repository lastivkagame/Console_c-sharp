using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //throw "some error c++" -- catch(const char *) !!!error in c#
            //throw new Exeption(...)
            //try - always
            //catch - if error in try
            //finaly - always

            Console.Write("Enter digit: ");

            try
            {
                int res = int.Parse(Console.ReadLine()); // null for Argument Exception
            }
            #region Universal catch
            //catch (Exception ex)
            //{
            //    if (ex.GetType().Name == "FormatException")
            //        Console.WriteLine(ex.Message);
            //     if(ex.GetType().Name == "OverflowExeption")
            //        Console.WriteLine("Number is so large or so little");
            //    else if(ex.GetType().Name == "ArgumentNullException")
            //        Console.WriteLine("No digit");
            //} 
            #endregion
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            catch
            {
                Console.WriteLine("Other exception");
            }
            finally
            {
                Console.WriteLine("Good work!");
            }

            SqlConnection sql = new SqlConnection();
            
            try
            {
                sql.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Close!");
                sql.Close();
            }
            
        }
    }
}
