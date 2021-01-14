/*---------------------------------------------
Утворити рваний масив([][]) з байтів. Записати його у файл та прочитати з файлу. Написати відповідні методи.
Використати клас FileStream.*/
using System;
using System.IO;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows;

            Console.Write("Enter count of rows: ");

            try
            {
                rows = Convert.ToInt32(Console.ReadLine());

                if (rows <= 0)
                {
                    rows = 4;
                    Console.WriteLine("Inccorect your entered size thenfore -> rows = 4");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "\n Thenfore will be rows = 4");
                rows = 4;
            }

            byte[][] jugged = new byte[rows][]; //рваний масив = масив масивів

            FillJugged(jugged);
            PrintJugged(jugged);

            Console.ReadKey();
            Console.Clear();

            Write(jugged);

            try
            {
                Console.WriteLine("Read from file: ");
                PrintJugged(Read());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FillJugged(byte[][] jugged) // заповнення масиву 
        {
            byte temp = 1;

            for (int i = 0; i < jugged.Length; i++)
            {
                jugged[i] = new byte[i + 1];
                for (int j = 0; j < jugged[i].Length; j++)
                {
                    jugged[i][j] = temp++;
                }
            }
        }

        private static void PrintJugged(byte[][] jugged) // вивід масиву
        {
            try
            {
                Console.WriteLine();
                for (int i = 0; i < jugged.Length; i++)
                {
                    for (int j = 0; j < jugged[i].Length; j++)
                    {
                        Console.Write("\t" + jugged[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write(byte[][] arr) // запис у файл масиву
        {
            try
            {
                using (FileStream fs = new FileStream("ByteJugged.txt", FileMode.Create))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        fs.Write(arr[i], 0, arr[i].Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static byte[][] Read() // зчитування з файлу масива
        {
            using (FileStream fs = new FileStream("ByteJugged.txt", FileMode.Open, FileAccess.Read))
            {
                int k1 = 1, line = 0, count = (int)fs.Length;

                if (count == 1)
                {
                    line = 1;
                }
                else
                {
                    while (count > 0)
                    {
                        line++;
                        count -= k1++;
                    }
                }

                byte[][] readBytes = new byte[line][];

                for (int i = 0; i < line; i++)
                {
                    readBytes[i] = new byte[i + 1];
                    fs.Read(readBytes[i], 0, i + 1);
                }

                return readBytes;
            }

        }
    }
}

/*Примітка: StreamReader and StreamWriter напевно можна було зробити трішки більш простішою і універсальною(мені так зрозуміліше), 
 але тут сказано що треба використати клас FileStream тому так */
