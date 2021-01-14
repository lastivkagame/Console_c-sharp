using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StudentLib
{
    [Serializable]
    public class Student
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("ListGrades")]
        public List<Grade> grades { get; set; }

        [XmlElement("StudentID")]
        public Guid StudentId { get; set; }

        public Student()
        {
            StudentId = Guid.NewGuid();
            grades = new List<Grade>();
        }

        public override string ToString()
        {
            return $" {Name,-15} {LastName,-15} Age: {Age,-4} ID: {StudentId}";
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

        [XmlAttribute]
        public int Mark { get; set; }

        [XmlAttribute]
        public string Subject { get; set; }
    }
}