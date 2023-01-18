using System;
using System.Collections;

namespace Enrollment_System.Data
{
    public class ApplicationForm
    {
        public ApplicationForm()
        {
            SubjectIDs = new ArrayList();
            ScheduleIDs = new ArrayList();
        }
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int AddressID { get; set; }
        public int ContactID { get; set; }
        public int SchoolHistoryID { get; set; }
        public int GuardianID { get; set; }
        public int RequirementID { get; set; } //TODO: Add to the database.
        public ArrayList SubjectIDs { get; set; }
        public ArrayList ScheduleIDs { get; set; }
        public String Course { get; set; }
        public String AdmitType { get; set; }
        public String YearLevel { get; set; }
        public String SchoolYear { get; set; }
        public String Term { get; set; }
        public DateTime SubmissionDate { get; set; }
        public Boolean IsRegular { get; set; }
        public String Status { get; set; }
    }
}
