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
    }
}
