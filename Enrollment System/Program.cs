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
            //Run the creation of the tables.
            Thread thread = new Thread(new ThreadStart(DatabaseHelper.createUserTable));
            //Load the user list
            thread = new Thread(new ThreadStart(DatabaseHelper.getUsers));



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}
