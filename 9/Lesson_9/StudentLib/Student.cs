using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Grade> grades { get; private set; }
        public Guid StudentId { get; private set; } // щось схоже на хеш код 3456-53вц- ... global unifield id

        public Student()
        {
            StudentId = Guid.NewGuid();
            grades = new List<Grade>();
        }

        public override string ToString()
        {
            return Name + " " + LastName + ", Age  " + Age + ", ID: " + StudentId;
        }

        public void AddMark(string sublect, int mark)
        {
            Grade find = grades.Find(x => x.Subject.Equals(sublect));

            if (find != null)
            {
                find.Mark = mark;
            }
            else
            {
                grades.Add(new Grade { Mark = mark, Subject = sublect });
            }
        }


    }

    [Serializable]
    public class Grade
    {
        public Grade()
        {
                
        }
        public int Mark { get; set; }
        public string Subject { get; set; }
    }
}
