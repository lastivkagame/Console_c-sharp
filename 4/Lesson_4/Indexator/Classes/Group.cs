using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator.Classes
{
    class Group
    {
        List<Student> group;

        public int Length => group.Count; // readonly property

        public Group()
        {
            group = new List<Student>();
        }

        public void AddStudent(Student st)
        {
            group.Add(st);
        }

        public Student this[int index]
        {
            get
            {
                if (index < 0 || index > Length)
                    throw new ArgumentException("index incorect");
                return group[index];
            }
            set
            {
                if (index < 0 || index > Length)
                    throw new ArgumentException("index incorect");
                group[index] = value;
            }
        }

        private Student FindByName(string name)
        {
            return group.Find(x => x.Name.Equals(name));
        }

        public Student this[string name]
        {
            get
            {
                Student temp = FindByName(name);
                if (temp != null)
                {
                    return temp;
                }
                else
                {
                    throw new InvalidOperationException("Not Found");
                }
            }
            set
            {
                Student temp = FindByName(name);
                if (temp != null)
                    temp = value;
            }
        }
    }
}
