using System;
using System.Collections;
using Enrollment_System.Util;

namespace Enrollment_System.Data
{
    class CourseManager
    {
        private CourseManager()
        {
            courses = new ArrayList();
        }
        private static CourseManager instance = null;
        public ArrayList courses { get; set; }

        public static CourseManager getInstance()
        {
            if (instance == null)
                instance = new CourseManager();
            return instance;
        }

        public void add(Course course)
        {
            courses.Add(course);
        }

        public void update(Course x)
        {
            if (courses.IndexOf(x) >= 0)
                courses[courses.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentCourseID() == 1)
                return 0;
            return DatabaseHelper.getRecentCourseID();
        }
        public void removeRecent()
        {
            if (courses.Count == 0)
                return;
            courses.RemoveAt(courses.Count - 1);
        }
        public Course find(int Id)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Course s = (Course)courses[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Course findByIndex(int index)
        {
            return (Course)courses[index];
        }

        public Course findByName(string Name)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Course s = (Course)courses[i];
                if (s.Name.Equals(Name))
                    return s;
            }
            return null;
        }

        public int findIndex(Course x)
        {
            return courses.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Course s = (Course)courses[i];
                if (s.ID == ID)
                    courses.Remove(s);
            }
        }

        public void clear()
        {
            courses.Clear();
        }
    }
}
