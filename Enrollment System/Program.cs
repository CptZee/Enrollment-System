using System;
using System.Threading;
using Enrollment_System.Util;
using System.Windows.Forms;

namespace Enrollment_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread AddressDBThread = new Thread(new ThreadStart(DatabaseHelper.createAdressesTable));
            Thread AdminDBThread = new Thread(new ThreadStart(DatabaseHelper.createAdminTable));
            Thread ApplicationFormDBThread = new Thread(new ThreadStart(DatabaseHelper.createApplicationFormTable));
            Thread ContactDBThread = new Thread(new ThreadStart(DatabaseHelper.createContactTable));
            Thread CoursesDBThread = new Thread(new ThreadStart(DatabaseHelper.createCoursesTable));
            Thread GuardianDBThread = new Thread(new ThreadStart(DatabaseHelper.createGuardianTable));
            Thread SchoolHistoryDBThread = new Thread(new ThreadStart(DatabaseHelper.createSchoolHistoryTable));
            Thread StudentDBThread = new Thread(new ThreadStart(DatabaseHelper.createStudentsTable));


            Thread AddressLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAddresses));
            Thread AdminLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAdmins));
            Thread ApplicationFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationForms));
            Thread ContactLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadContacts));
            Thread CoursesLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadCourses));
            Thread GuardianLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadGuardians));
            Thread SchoolHistoryLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSchoolHistory));
            Thread StudentLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadStudents));

            AddressDBThread.Start();
            AdminDBThread.Start();
            ApplicationFormDBThread.Start();
            ContactDBThread.Start();
            CoursesDBThread.Start();
            GuardianDBThread.Start();
            SchoolHistoryDBThread.Start();
            StudentDBThread.Start();

            AddressLoadThread.Start();
            AdminLoadThread.Start();
            ApplicationFormLoadThread.Start();
            ContactLoadThread.Start();
            CoursesLoadThread.Start();
            GuardianLoadThread.Start();
            SchoolHistoryLoadThread.Start();
            StudentLoadThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}
