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

            AddressDBThread.Start();
            AdminDBThread.Start();
            ApplicationFormDBThread.Start();
            ContactDBThread.Start();
            CoursesDBThread.Start();
            GuardianDBThread.Start();
            SchoolHistoryDBThread.Start();
            StudentDBThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}
