using System.Collections;

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

        public void addStudent(Student student)
        {
            students.Add(student);
        }


        public int retrieveRecentID()
        {
            if (students.Count == 0)
                return -1;
            Student student = (Student)students[students.Count - 1];
            return student.Id;
        }

        public void removeRecent()
        {
            if (students.Count == 0)
                return;
            students.RemoveAt(students.Count - 1);
        }
    }
}
