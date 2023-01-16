using System.Collections;
using Enrollment_System.Util;

namespace Enrollment_System.Data
{
    class StudentManager
    {
        private StudentManager()
        {
            students = new ArrayList();
        }
        private static StudentManager instance = null;
        public ArrayList students { get; set; }

        public static StudentManager getInstance()
        {
            if (instance == null)
                instance = new StudentManager();
            return instance;
        }

        public void add(Student student)
        {
            students.Add(student);
        }

        public void update(Student x)
        {
            if (students.IndexOf(x) >= 0)
                students[students.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentStudentID() == 1)
                return 0;
            return DatabaseHelper.getRecentStudentID();
        }

        public void removeRecent()
        {
            if (students.Count == 0)
                return;
            students.RemoveAt(students.Count - 1);
        }

        public Student find(int Id)
        {
            for(int i = 0; i < students.Count; i++)
            {
                Student s = (Student)students[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Student findByIndex(int index)
        {
            return (Student)students[index];
        }

        public Student findByFirstName(string FirstName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student s = (Student)students[i];
                if (s.FirstName.Equals(FirstName))
                    return s;
            }
            return null;
        }

        public int findIndex(Student x)
        {
            return students.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student s = (Student)students[i];
                if (s.ID == ID)
                    students.Remove(s);
            }
        }

        public void clear()
        {
            students.Clear();
        }
    }
}
