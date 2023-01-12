using System;

namespace Enrollment_System.Data
{
    class Student : User
    {
        public String StudNo { get; set; }
        public String Program { get; set; }
        public String YearLvl { get; set; }
        public String Semester { get; set; }
        public Boolean isRegular { get; set; }
    }
}
