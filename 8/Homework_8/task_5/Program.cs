/*Створити клас AppSettingHelper, який у бінарному режимі(за допомогою BinaryWriter, BinaryReader) 
дозволяє записувати та зчитувати налаштування додатку(колір консолі, назву вікна, розміри вікна).
Створити додаток для демонстрації роботи класу AppSettingHelper.*/

using System;
using System.IO;

namespace task_5
{
    [Serializable]
    public class AppSettingHelper
    {
        public ConsoleColor Console_color { get; set; }

        public ConsoleColor Text_color { get; set; }

        public string Title { get; set; }

        public int Width_window { get; set; }

        public int Height_window { get; set; }

        public AppSettingHelper()
        {
            Console_color = Console.BackgroundColor;
            Text_color = Console.ForegroundColor;
            Title = Console.Title;
            Width_window = Console.WindowWidth;
            Height_window = Console.WindowHeight;
        }

        public AppSettingHelper(ConsoleColor consoleColor, ConsoleColor textColor, string title, int widthWindow, int heightWindow)
        {
            Console_color = consoleColor;
            Text_color = textColor;
            Title = title;
            Width_window = widthWindow;
            Height_window = heightWindow;
        }

        public string FuncBinaryReader(string file)
        {
            string str = "";

            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                try
                {
                    Console_color = ChangeSomeSettings.ReturnColor(reader.ReadString());
                    Text_color = ChangeSomeSettings.ReturnColor(reader.ReadString());
                    Title = reader.ReadString();
                    Width_window = reader.ReadInt32();
                    Height_window = reader.ReadInt32();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return str;
        }

        public void FuncBinaryWritter(string file)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate)))
            {
                writer.Write(Console_color.ToString());
                writer.Write(Text_color.ToString());
                writer.Write(Title);
                writer.Write(Width_window);
                writer.Write(Height_window);
            }
        }

        public override string ToString()
        {
            return $" Console Color: { Console_color,-10} Text Color: {Text_color,-10} Title: {Title,-25} Width_window: {Width_window,-7} Height_window: {Height_window}";
        }
    }

    //клас створений для зручності зміни колір консолі, назву вікна, розміри вікна ..
    public static class ChangeSomeSettings
    {
        public static void WriteBackgroundColor(string color)
        {
            Console.BackgroundColor = ReturnColor(color);
        }

        public static void WriteTextColor(string color)
        {
            Console.ForegroundColor = ReturnColor(color);
        }

        public static void WriteNameWindow(string title)
        {
            Console.Title = title;
        }

        public static void WriteSizeWindow(int width, int height)
        {
            try
            {
                Console.WindowHeight = height;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WindowWidth = width;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static ConsoleColor ReturnColor(string yourcolor)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ConsoleColor currentBackground = ConsoleColor.White;

            foreach (var col in colors)
            {
                if (col.ToString().Contains(yourcolor))
                {
                    currentBackground = col;
                    break;
                }
            }

            return currentBackground;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AppSettingHelper app = new AppSettingHelper();

            try
            {
                Console.Write("Enter background color: ");
                ChangeSomeSettings.WriteBackgroundColor(Console.ReadLine());

                Console.Write("Enter text color: ");
                ChangeSomeSettings.WriteTextColor(Console.ReadLine());

                Console.Write("Enter title: ");
                ChangeSomeSettings.WriteNameWindow(Console.ReadLine());

                Console.Write("Enter size window(width, height): ");
                ChangeSomeSettings.WriteSizeWindow(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.Write("Enter name of file for write: ");
                AppSettingHelper app1 = new AppSettingHelper();
                app1.FuncBinaryWritter(Console.ReadLine());

                Console.Write("Enter name of file for read: ");
                AppSettingHelper app2 = new AppSettingHelper();
                app2.FuncBinaryReader(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("\t app begin settings: \n" + app);
                Console.WriteLine();
                Console.WriteLine("\t app2 settings that read of file: \n" + app2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
