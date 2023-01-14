using System;
using System.Threading;
using Enrollment_System.Util;
using System.Windows.Forms;
using Enrollment_System.Data;

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
            Thread GuardianDBThread = new Thread(new ThreadStart(DatabaseHelper.createGuardianTable));
            Thread SchoolHistoryDBThread = new Thread(new ThreadStart(DatabaseHelper.createSchoolHistoryTable));
            Thread StudentDBThread = new Thread(new ThreadStart(DatabaseHelper.createStudentsTable));
            Thread SubjectDBThread = new Thread(new ThreadStart(DatabaseHelper.createStudentsTable));
            Thread ScheduleDBThread = new Thread(new ThreadStart(DatabaseHelper.createSchedulesTable));
            Thread CoursesDBThread = new Thread(new ThreadStart(DatabaseHelper.createCoursesTable));


            Thread AddressLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAddresses));
            Thread AdminLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadAdmins));
            Thread ApplicationFormLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadApplicationForms));
            Thread ContactLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadContacts));
            Thread GuardianLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadGuardians));
            Thread SchoolHistoryLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSchoolHistory));
            Thread StudentLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadStudents));
            Thread SubjectLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSubjects));
            Thread ScheduleLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadSchedules));
            Thread CoursesLoadThread = new Thread(new ThreadStart(DatabaseHelper.loadCourses));

            AddressDBThread.Start();
            AdminDBThread.Start();
            ApplicationFormDBThread.Start();
            ContactDBThread.Start();
            GuardianDBThread.Start();
            SchoolHistoryDBThread.Start();
            StudentDBThread.Start();
            SubjectDBThread.Start();
            ScheduleDBThread.Start();
            CoursesDBThread.Start();

            AddressLoadThread.Start();
            AdminLoadThread.Start();
            ApplicationFormLoadThread.Start();
            ContactLoadThread.Start();
            GuardianLoadThread.Start();
            SchoolHistoryLoadThread.Start();
            StudentLoadThread.Start();
            SubjectLoadThread.Start();
            ScheduleLoadThread.Start();
            CoursesLoadThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}
