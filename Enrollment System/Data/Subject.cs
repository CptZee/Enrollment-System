using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class Subject
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String YearLevel { get; set; }
        public String Term { get; set; }
        public String Prerequisite { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public String Day { get; set; }
    }
}
