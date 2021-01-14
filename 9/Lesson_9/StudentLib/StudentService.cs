using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StudentLib
{
    /// <summary>
    /// Incapsulate list logic for Student
    /// </summary>
    [Serializable]
    public class StudentService : IEnumerable<Student>
    {
        List<Student> students { get; set; } = new List<Student>();

        public void ClearList()
        {
            students.Clear();
        }

        public void AddStudent(Student st)
        {
            students.Add(st);
        }

        /// <summary>
        /// Delete Student from list
        /// </summary>
        /// <param name="st">Student which would be deleted</param>
        public void DeleteStudent(Student st)
        {
            try
            {
                students.Remove(students.Find(x => x.StudentId == st.StudentId));
            }
            catch { throw; }
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Serialize_Binary(string path = "bin_students.bin")
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    //Бінарна серіалізація точна(зберігаються як відкриті так і закриті поля)
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, students);
                }
            }
            catch { throw; }
        }

        public void Serialize_XML(string path = "xml_students.xml")
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(students.GetType(), new[] { typeof(Grade) });
                xml.Serialize(new FileStream(path, FileMode.Create), students);
            }
            catch { throw; }
        }

        public void Serialize_Json(string path = "json_students.json")
        {
            try
            {
                string json = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch { throw; }
        }

        public void Deserialize_Binary(string path = "bin_students.bin")
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    students = (List<Student>)bf.Deserialize(fs);
                }
            }
            catch { throw; }
        }

        public void Deserialize_XML(string path = "xml_students.xml")
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(students.GetType(), new[] { typeof(Grade) });
                students = (List<Student>)xml.Deserialize(new FileStream(path, FileMode.Open));
            }
            catch { throw; }
        }

        public void Deserialize_Json(string path = "json_students.json")
        {
            try
            {
                string json = File.ReadAllText(path);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            catch { throw; }
        }
    }
}