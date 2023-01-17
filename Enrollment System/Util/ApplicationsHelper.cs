using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{
    class ApplicationsHelper
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
        public static void createApplicationFormTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Applications", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Applications Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Applications Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Applications
                (
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [StudentID] INT NOT NULL,
                    [AddressID] INT NOT NULL,
                    [ContactID] INT NOT NULL,
                    [SchoolHistoryID] INT NOT NULL,
                    [GuardianID] INT NOT NULL,
                    [Course] NCHAR(30) NOT NULL,
                    [AdmitType] NCHAR(30) NOT NULL,
                    [YearLevel] NCHAR(30) NOT NULL,
                    [SchoolYear] NCHAR(30) NOT NULL,
                    [Term] NCHAR(30) NOT NULL,
                    [SubmissionDate] DATE NOT NULL,
                    [IsRegular] BIT NOT NULL,
                    [Status] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createApplicationSubjectsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationSubjects", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Subjects Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Subjects Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationSubjects
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [SubjectID] INT NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataSet getApplications()
        {

            String select = "SELECT * FROM Applications";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static void loadApplicationForms()
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            applicationFormsManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, 
                SchoolYear, Term, SubmissionDate, Status, IsRegular FROM Applications";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm applicationForm = new ApplicationForm();
                        applicationForm.ID = reader.GetInt32(0);
                        applicationForm.StudentID = reader.GetInt32(1);
                        applicationForm.AddressID = reader.GetInt32(2);
                        applicationForm.ContactID = reader.GetInt32(3);
                        applicationForm.SchoolHistoryID = reader.GetInt32(4);
                        applicationForm.GuardianID = reader.GetInt32(5);
                        applicationForm.Course = reader.GetString(6).Trim();
                        applicationForm.AdmitType = reader.GetString(7).Trim();
                        applicationForm.YearLevel = reader.GetString(8).Trim();
                        applicationForm.SchoolYear = reader.GetString(9).Trim();
                        applicationForm.Term = reader.GetString(10).Trim();
                        applicationForm.SubmissionDate = reader.GetDateTime(11);
                        applicationForm.Status = reader.GetString(12).Trim();
                        applicationForm.IsRegular = reader.GetBoolean(13);

                        applicationFormsManager.add(applicationForm);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load application form list!");
            }
        }

        public static void addApplicationForm(ApplicationForm applicationform)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Applications(StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, SchoolYear," +
                " Term, SubmissionDate, Status, IsRegular) VALUES(@StudentID, @AddressID, @ContactID, @SchoolHistoryID, @GuardianID, @Course, @AdmitType, @YearLevel, " +
                "@SchoolYear, @Term, @SubmissionDate, @Status, @IsRegular)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", applicationform.StudentID);
                command.Parameters.AddWithValue("@AddressID", applicationform.AddressID);
                command.Parameters.AddWithValue("@ContactID", applicationform.ContactID);
                command.Parameters.AddWithValue("@SchoolHistoryID", applicationform.SchoolHistoryID);
                command.Parameters.AddWithValue("@GuardianID", applicationform.GuardianID);
                command.Parameters.AddWithValue("@Course", applicationform.Course);
                command.Parameters.AddWithValue("@AdmitType", applicationform.AdmitType);
                command.Parameters.AddWithValue("@YearLevel", applicationform.YearLevel);
                command.Parameters.AddWithValue("@SchoolYear", applicationform.SchoolYear);
                command.Parameters.AddWithValue("@Term", applicationform.Term);
                command.Parameters.AddWithValue("@SubmissionDate", applicationform.SubmissionDate);
                command.Parameters.AddWithValue("@Status", applicationform.Status);
                command.Parameters.AddWithValue("@IsRegular", applicationform.IsRegular);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeApplication(ApplicationForm applicationForm)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Applications WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", applicationForm.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateApplicationForm(ApplicationForm applicationform)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Applications SET StudentID = @StudentID, AddressID = @AddressID, ContactID = @ContactID, SchoolHistoryID = @SchoolHistoryID" +
                ", GuardianID = @GuardianID, Course = @Course, AdmitType = @AdmitType, YearLevel = @YearLevel, SchoolYear = @SchoolYear," +
                " Term = @Term, SubmissionDate = @SubmissionDate, Status = @Status, IsRegular = @IsRegular WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", applicationform.ID);
                command.Parameters.AddWithValue("@StudentID", applicationform.StudentID);
                command.Parameters.AddWithValue("@AddressID", applicationform.AddressID);
                command.Parameters.AddWithValue("@ContactID", applicationform.ContactID);
                command.Parameters.AddWithValue("@SchoolHistoryID", applicationform.SchoolHistoryID);
                command.Parameters.AddWithValue("@GuardianID", applicationform.GuardianID);
                command.Parameters.AddWithValue("@Course", applicationform.Course);
                command.Parameters.AddWithValue("@AdmitType", applicationform.AdmitType);
                command.Parameters.AddWithValue("@YearLevel", applicationform.YearLevel);
                command.Parameters.AddWithValue("@SchoolYear", applicationform.SchoolYear);
                command.Parameters.AddWithValue("@Term", applicationform.Term);
                command.Parameters.AddWithValue("@SubmissionDate", applicationform.SubmissionDate);
                command.Parameters.AddWithValue("@Status", applicationform.Status);
                command.Parameters.AddWithValue("@IsRegular", applicationform.IsRegular);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateApplicationSubject(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.SubjectIDs.Count; i++)
            {
                String query = "UPDATE ApplicationSubjects SET ApplicationID = @ApplicationID, SubjectID = @SubjectID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@SubjectID", application.SubjectIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateApplicationSchedule(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                String query = "UPDATE ApplicationSchedules SET ApplicationID = @ApplicationID, ScheduleID = @ScheduleID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@ScheduleID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateApplicationRequirements(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                String query = "UPDATE ApplicationRequirements SET ApplicationID = @ApplicationID, RequirementID = @RequirementID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@RequirementID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static int getRecentApplicationID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Applications')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
