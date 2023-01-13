using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    public class ApplicationForm
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int AddressID { get; set; }
        public int ContactID { get; set; }
        public int SchoolHistoryID { get; set; }
        public ArrayList GuardianIDs { get; set; }
        public String Course { get; set; }
        public String AdmitType { get; set; }
        public String YearLevel { get; set; }
        public String SchoolYear { get; set; }
        public String Term { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
