using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class CoursesManager
    {
        private CoursesManager()
        {
            courses = new ArrayList();
        }
        private static CoursesManager instance = null;
        private ArrayList courses { get; set; }

        public static CoursesManager getInstance()
        {
            if (instance == null)
                instance = new CoursesManager();
            return instance;
        }

        public void addCourses(Course course)
        {
            courses.Add(course);
        }
    }
}
