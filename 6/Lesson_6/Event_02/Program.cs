using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_02
{
    delegate void UI(); //делегат, що посилається на методи, які нічого не повертають і не приймають

    class MyEvent
    {
        public event UI UserEvent; //оголосити подію типу делегата UI

        //Raise event!!!
        public void OnUserEvent()
        {
            if (UserEvent != null)
                UserEvent();
            //UserEvent?.Invoke();

        }
    }

    class UserInfo
    {
        string name;
        string lastname;
        int age;

        public UserInfo(string name, string lastname, int age)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public void UserInfoHandler()
        {
            Console.WriteLine("Event was raised!!!");
            Console.WriteLine($"{Name} {Lastname} {Age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            UserInfo u1 = new UserInfo("Bill", "Gates", 40);
            UserInfo u2 = new UserInfo("Ann", "Simpson", 20);

            evt.UserEvent += u1.UserInfoHandler;
            evt.UserEvent += u2.UserInfoHandler;

            evt.UserEvent += () => Console.WriteLine("Something was happend!!!");

            evt.OnUserEvent();
        }
    }
}
