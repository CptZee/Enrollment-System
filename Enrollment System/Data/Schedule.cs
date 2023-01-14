using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class Schedule
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public String Day { get; set; }
    }
}
