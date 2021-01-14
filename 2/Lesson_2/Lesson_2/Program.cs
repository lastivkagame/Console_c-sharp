using System;
using System.Linq; //min(), max(), count()

namespace Lesson_2
{
    class Program
    {
        static void Main()
        {
            #region arrays int
            //value type(int, double, char, struct), reference type(class, array,string)

            //int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[10];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                //arr[i] = random.Next(15); //з нуля до 14
                arr[i] = random.Next(5, 15);
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();

            #endregion

            #region array string
            string[] array = new string[] { "red", "green", "blue" };
            //string[] array2 = new[] { "red", "green", "blue" };
            //Console.WriteLine("Size:{0} ", array.Length);

            //string[] array = { "apple", "cherry" };
            //var array = new[] { "apple", "cherry", "banana", "plum" };
            //Console.WriteLine("Size:{0}, type of array = {1} ", array.Length, array.GetType());

            //foreach(var item in array)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region array object
            //object[] obj = new object[] { "first", 45.76, 12f, 'a', new DateTime(2020, 12, 31) };

            //foreach(var item in obj)
            //{
            //    Console.WriteLine($"{ item} -- > {item.GetType()}");
            //} 
            #endregion

            #region array double
            //const int size = 10;
            //double[] darray = new double[size];

            //for(int i =0;i< darray.Length; i++)
            //{
            //    darray[i] = random.NextDouble() * 1400;
            //    Console.Write($"{darray[i], -15:N2} \t"); 
            #endregion

            #region Dia
            //Console.WriteLine("Min = " + FindMin(arr));
            //Console.WriteLine("Max = " + arr.Max());
            //Console.WriteLine("Avg = " + arr.Average());
            //Console.WriteLine("Max string: {0}", array.Max());
            //Console.WriteLine("Max string: {0}", array.Max(x =>x.Length)); // лямда ф-ції

            //ShowArray("before sort: ", array);
            //Array.Sort(array);
            //ShowArray("after sort: ", array);

            //ShowArray("before: ", array);
            //Array.Reverse(array);
            //ShowArray("after: ", array);
            #endregion

            #region Copy
            //string[] test = new string[10];
            //Array.Copy(array, 1, test, 0, 2); //копія 2 елементів масиву array з 1 - ого масиву тест починаючи з 0
            //ShowArray("copy", test);
            //array.CopyTo(test, 1);  //копія у масив тест масиву array починаючи з 1 - ого ел-ента
            //ShowArray("copyTo(test, 1) ", test); 
            #endregion

            #region Lamda
            //int elem = Array.Find(arr, (int x) => { return x % 5 == 0; });
            //Console.WriteLine("Elem = {0}", elem);

            //elem = Array.Find(arr, (int x) => { return x % 15 == 0; });
            //Console.WriteLine("Elem = {0}", elem);

            //int[] odd = Array.FindAll(arr, x => x % 2 != 0);
            //ShowArray("All odd elements", odd); 
            #endregion

            #region Clone
            //object clone = arr.Clone();
            //int[] cloneArray = clone as int[];
            //ShowArray("clone ", cloneArray);
            //cloneArray[0] = 1000;
            //ShowArray("after change ", cloneArray);
            //ShowArray("after change sourse ", arr); 

            object testStrings = array.Clone();
            //string[] result = testStrings as String[]; // приведення до типу
            string[] result = (string[])testStrings; // приведення до типу
            result[0] = new string("sunday".ToCharArray());
            ShowArray("Clone string[] ", result);
            ShowArray("Clone string[] ", array);
            #endregion
        }

        //private static void ShowArray(string message, object []arr)
        private static void ShowArray(string message, object []arr)
        {
            Console.WriteLine(message);
            foreach(var item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
        private static int FindMin(int[] arr)
        {
            return arr.Min(); 
        }
    }
}
