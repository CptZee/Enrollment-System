﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class Student
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String SuffixName { get; set; }
        public String Gender { get; set; }
        public String Status { get; set; }
        public String Citizenship { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
