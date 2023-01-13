using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void addCourses(Course course)
        {
            courses.Add(course);
        }

        public int retrieveRecentID()
        {
            if (courses.Count == 0)
                return -1;
            Course x = (Course)courses[courses.Count - 1];
            return x.ID;
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
    }
}
