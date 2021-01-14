using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public static class Authorizations
    {
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string DateOfBirth { get; set; }

        private static List<string> GiveLogin()
        {
            using (FileStream fs = new FileStream("login.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<string>)bf.Deserialize(fs);
            }
        }

        private static List<string> GivePassword()
        {
            using (FileStream fs = new FileStream("psw.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<string>)bf.Deserialize(fs);
            }
        }

        public static bool UserLogin(string login, string psw)
        {
            if (login != "" && login != " ")
            {
                List<string> all_login = new List<string>();
                List<string> all_psw = new List<string>();

                try
                {
                    all_login = GiveLogin();
                    all_psw = GivePassword();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                for (int i = 0; i < all_login.Count; i++)
                {
                    if (login == all_login[i])
                    {
                        if (psw == all_psw[i])
                        {
                            Login = login;
                            Password = psw;
                            return true;
                        }
                    }
                }
            }

            Console.WriteLine("Inccorect password or login!");
            return false;
        }

        public static bool UserSignUp(string login, string psw, string dateofbirth)
        {
            List<string> all_login = new List<string>();
            List<string> all_psw = new List<string>();

            try
            {
                all_login = GiveLogin();
                all_psw = GivePassword();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bool flag = true;

            for (int i = 0; i < all_login.Count; i++)
            {
                if (login == all_login[i])
                {
                    flag = false;
                }
            }

            if (flag == true)
            {

                all_login.Add(login);
                using (FileStream fs = new FileStream("login.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, all_login);
                }

                all_psw.Add(psw);
                using (FileStream fs = new FileStream("psw.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, all_psw);
                }

                List<string> date = new List<string>();

                using (FileStream fs = new FileStream("date.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    date = (List<string>)bf.Deserialize(fs);
                }

                date.Add(dateofbirth);
                using (FileStream fs = new FileStream("date.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, date);
                }

                Login = login;
                Password = psw;

                return true;
            }

            Console.WriteLine("Already exist this login!");
            return false;
        }

        public static bool ChangePassword(string login, string oldpassword, string newpassword)
        {
            if (login != "" && login != " ")
            {
                List<string> all_login = new List<string>();
                List<string> all_psw = new List<string>();

                try
                {
                    all_login = GiveLogin();
                    all_psw = GivePassword();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                for (int i = 0; i < all_login.Count; i++)
                {
                    if (login == all_login[i])
                    {
                        if (oldpassword == all_psw[i])
                        {
                            Password = newpassword;
                            all_psw[i] = newpassword;

                            using (FileStream fs = new FileStream("psw.bin", FileMode.OpenOrCreate))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                bf.Serialize(fs, all_psw);
                            }

                            return true;
                        }
                    }
                }
            }

            Console.WriteLine("Inccorect password or login!");
            return false;
        }

        public static bool ChangeDate(string login, string psw, string newdate)
        {
            if (login != "" && login != " ")
            {
                List<string> all_login = new List<string>();
                List<string> all_psw = new List<string>();

                try
                {
                    all_login = GiveLogin();
                    all_psw = GivePassword();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                for (int i = 0; i < all_login.Count; i++)
                {
                    if (login == all_login[i])
                    {
                        if (psw == all_psw[i])
                        {
                            List<string> date = new List<string>();

                            using (FileStream fs = new FileStream("date.bin", FileMode.OpenOrCreate))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                date = (List<string>)bf.Deserialize(fs);
                            }

                            date[i] = newdate;
                            using (FileStream fs = new FileStream("date.bin", FileMode.OpenOrCreate))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                bf.Serialize(fs, date);
                            }
                            return true;
                        }
                    }
                }
            }

            Console.WriteLine("Inccorect password or login!");
            return false;
        }
    }
}
