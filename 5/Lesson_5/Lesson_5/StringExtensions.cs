using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    static class StringExtensions
    {
        public static int CountDigits(this string str) // ---- > str. CountDigits()
        {
            int result = str.Count(x => Char.IsDigit(x));
            return result;
        }

        /// <summary>
        /// this print aray
        /// </summary>
        /// <param name="arr"></param>
        public static void Print(this Array arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }

        public static int CountPairDigits(this int[] arr) 
        {
            int result = arr.Count(x => x % 2 == 0);
            return result;
        }

        ///<summary>
        /// Return count of even or not numbers int array
        ///</summary>
        ///<param name = "arr">int Array </param>
        ///<param name = "isEven">Define if return count of even numbers </param>
        ///<returns>count even or not numbers</returns>
    
        public static int CountIf(this int[] arr, bool isEven)
        {
            if(isEven)
            {
                return arr.Count(x => x % 2 == 0);
            }
            else
            {
                return arr.Count(x => x % 2 != 0);
            }
        }
    }
}
