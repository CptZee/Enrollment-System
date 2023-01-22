using System;
using System.Threading;
using Enrollment_System.Util;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System
{
    static class Enrollment_System
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //generateDefaultAdmin(); //Debug Command! ONLY RUN IF THE ADMIN TABLE IS EMPTY!
            createTables();
            loadTables();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardFrm());
        }

        private static void createTables()
        {
            Thread SubjectDBThread = new Thread(new ThreadStart(SubjectHelper.createSubjectsTable));
            Thread ScheduleDBThread = new Thread(new ThreadStart(ScheduleHelper.createSchedulesTable));
            Thread CoursesDBThread = new Thread(new ThreadStart(CourseHelper.createCoursesTable));
            Thread ApplicationFormDBThread = new Thread(new ThreadStart(ApplicationHelper.createApplicationFormTable));
            Thread ApplicationSubjectDBThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.createApplicationSubjectsTable));
            Thread ApplicationScheduleDBThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.createApplicationSchedulesTable));
            Thread ApplicationRequirementDBThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.createApplicationRequirementsTable));
            Thread RequirementDBThread = new Thread(new ThreadStart(RequirementHelper.createRequirementsTable));
            Thread AddressDBThread = new Thread(new ThreadStart(AddressHelper.createAdressesTable));
            Thread AdminDBThread = new Thread(new ThreadStart(AdminHelper.createAdminTable));
            Thread ContactDBThread = new Thread(new ThreadStart(ContactHelper.createContactTable));
            Thread GuardianDBThread = new Thread(new ThreadStart(GuardianHelper.createGuardianTable));
            Thread SchoolHistoryDBThread = new Thread(new ThreadStart(SchoolHistoryHelper.createSchoolHistoryTable));
            Thread StudentDBThread = new Thread(new ThreadStart(StudentHelper.createStudentsTable));

            SubjectDBThread.Start();
            ScheduleDBThread.Start();
            CoursesDBThread.Start();
            ApplicationFormDBThread.Start();
            ApplicationSubjectDBThread.Start();
            ApplicationScheduleDBThread.Start();
            ApplicationRequirementDBThread.Start();
            RequirementDBThread.Start();
            AddressDBThread.Start();
            AdminDBThread.Start();
            ContactDBThread.Start();
            GuardianDBThread.Start();
            SchoolHistoryDBThread.Start();
            StudentDBThread.Start();
        }

        public static void loadTables()
        {
            Thread SubjectLoadThread = new Thread(new ThreadStart(SubjectHelper.loadSubjects));
            Thread ScheduleLoadThread = new Thread(new ThreadStart(ScheduleHelper.loadSchedules));
            Thread CoursesLoadThread = new Thread(new ThreadStart(CourseHelper.loadCourses));
            Thread ApplicationFormLoadThread = new Thread(new ThreadStart(ApplicationHelper.loadApplicationForms));
            Thread ApplicationSubjectFormLoadThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.loadApplicationSubjects));
            Thread ApplicationScheduleFormLoadThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.loadApplicationSchedules));
            Thread ApplicationRequirementFormLoadThread = new Thread(new ThreadStart(ApplicationSystemDataHelper.loadApplicationRequirements));
            Thread RequirementLoadThread = new Thread(new ThreadStart(RequirementHelper.loadRequirements));
            Thread AddressLoadThread = new Thread(new ThreadStart(AddressHelper.loadAddresses));
            Thread AdminLoadThread = new Thread(new ThreadStart(AdminHelper.loadAdmins));
            Thread ContactLoadThread = new Thread(new ThreadStart(ContactHelper.loadContacts));
            Thread GuardianLoadThread = new Thread(new ThreadStart(GuardianHelper.loadGuardians));
            Thread SchoolHistoryLoadThread = new Thread(new ThreadStart(SchoolHistoryHelper.loadSchoolHistory));
            Thread StudentLoadThread = new Thread(new ThreadStart(StudentHelper.loadStudents));

            SubjectLoadThread.Start();
            ScheduleLoadThread.Start();
            CoursesLoadThread.Start();
            ApplicationFormLoadThread.Start();
            ApplicationSubjectFormLoadThread.Start();
            ApplicationScheduleFormLoadThread.Start();
            ApplicationRequirementFormLoadThread.Start();
            RequirementLoadThread.Start();
            AddressLoadThread.Start();
            AdminLoadThread.Start();
            ContactLoadThread.Start();
            GuardianLoadThread.Start();
            SchoolHistoryLoadThread.Start();
            StudentLoadThread.Start();
        }
        
        /**
         * Generate the default admin credentials;
         * USE FOR DEBUGGING ONLY!
         * TODO: ADD AN ACTUAL FUNCTIONAL FORM WHERE AN ADMIN CAN CREATE ANOTHER ADMIN ACCOUNT! (PRIORITY: LOWEST)
         */

        private static void generateDefaultAdmin()
        {
            Admin admin = new Admin();
            admin.Username = "admin";
            admin.Password = "password";
            AdminHelper.addAdmin(admin);
        }
    }
}
