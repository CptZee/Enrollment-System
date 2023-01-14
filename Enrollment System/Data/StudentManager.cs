﻿using System.Collections;

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
            students[students.IndexOf(x)] = x;
        }

        public int retrieveRecentID()
        {
            if (students.Count == 0)
                return -1;
            Student student = (Student)students[students.Count - 1];
            return student.ID;
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

        public int findIndex(Student x)
        {
            return students.IndexOf(x);
        }

        public void clear()
        {
            students.Clear();
        }
    }
}
