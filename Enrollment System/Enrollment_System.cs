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
            Thread SubjectDBThread = new Thread(new ThreadStart(DatabaseHelper.createSubjectsTable));
            Thread ScheduleDBThread = new Thread(new ThreadStart(DatabaseHelper.createSchedulesTable));
            Thread CoursesDBThread = new Thread(new ThreadStart(DatabaseHelper.createCoursesTable));
            Thread ApplicationFormDBThread = new Thread(new ThreadStart(DatabaseHelper.createApplicationFormTable));
            Thread ApplicationSubjectDBThread = new Thread(new ThreadStart(DatabaseHelper.createApplicationSubjectsTable));
            Thread ApplicationScheduleDBThread = new Thread(new ThreadStart(DatabaseHelper.createApplicationSchedulesTable));
            Thread ApplicationRequirementDBThread = new Thread(new ThreadStart(DatabaseHelper.createApplicationRequirementsTable));
            Thread RequirementDBThread = new Thread(new ThreadStart(DatabaseHelper.createRequirementsTable));
            Thread AddressDBThread = new Thread(new ThreadStart(DatabaseHelper.createAdressesTable));
            Thread AdminDBThread = new Thread(new ThreadStart(DatabaseHelper.createAdminTable));
            Thread ContactDBThread = new Thread(new ThreadStart(DatabaseHelper.createContactTable));
            Thread GuardianDBThread = new Thread(new ThreadStart(DatabaseHelper.createGuardianTable));
            Thread SchoolHistoryDBThread = new Thread(new ThreadStart(DatabaseHelper.createSchoolHistoryTable));
            Thread StudentDBThread = new Thread(new ThreadStart(DatabaseHelper.createStudentsTable));

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
            Thread SubjectLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSubjects));
            Thread ScheduleLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSchedules));
            Thread CoursesLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadCourses));
            Thread ApplicationFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationForms));
            Thread ApplicationSubjectFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationSubjects));
            Thread ApplicationScheduleFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationSchedules));
            Thread ApplicationRequirementFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationRequirements));
            Thread RequirementLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadRequirements));
            Thread AddressLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAddresses));
            Thread AdminLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAdmins));
            Thread ContactLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadContacts));
            Thread GuardianLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadGuardians));
            Thread SchoolHistoryLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSchoolHistory));
            Thread StudentLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadStudents));

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
            DatabaseHelper.addAdmin(admin);
        }
    }
}
