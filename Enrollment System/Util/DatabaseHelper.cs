using System;
using Enrollment_System.Data;
using System.Data.SqlClient;
using System.Data;

namespace Enrollment_System.Util
{
    /**
     * A helper class which contains all the methods regarding the datase.
     * WARNING: MUST RUN ON CHILD THREADS
     * 
     */ 
    class DatabaseHelper
    {
        //Modify depending on the computer's database. WILL ONLY WORK ON AARON's PC!
        private static String applicationsURL = @"Data Source=AARON\SQLEXPRESS;Initial Catalog=Applications;Integrated Security=True";
        private static String systemURL = @"Data Source=AARON\SQLEXPRESS;Initial Catalog=System;Integrated Security=True";

        /*
         * A simple method which returns the connection.
         * 
        **/
        public static SqlConnection getApplicationConnection()
        {
            SqlConnection connection = new SqlConnection(applicationsURL);
            return connection;
        }
        public static SqlConnection getSystemConnection()
        {
            SqlConnection connection = new SqlConnection(systemURL);
            return connection;
        }

        /**
         * A group of methods that will load the database and
         * store them as DataSets
         */
        public static DataSet getCourses()
        {
            String select = "SELECT * FROM Courses";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, getSystemConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getSubjects()
        {

            String select = "SELECT * FROM Subjects";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, getSystemConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getSchedules()
        {

            String select = "SELECT * FROM Schedules";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, getSystemConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getApplications()
        {

            String select = "SELECT * FROM Applications";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, getApplicationConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }
    }
}
