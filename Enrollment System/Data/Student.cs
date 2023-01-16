using System;

namespace Enrollment_System.Data
{
    class Student
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; } //TODO: Add to the database!!!!
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String SuffixName { get; set; }
        public String Gender { get; set; }
        public String Status { get; set; }
        public String Citizenship { get; set; }
        public DateTime BirthDate { get; set; }
        public String Birthplace { get; set; }
        public String Religion { get; set; }
    }
}
