using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class ApplicationHelper
    {
        public static void createApplicationFormTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [StudentID] INT NOT NULL,
                    [AddressID] INT NOT NULL,
                    [ContactID] INT NOT NULL,
                    [SchoolHistoryID] INT NOT NULL,
                    [GuardianID] INT NOT NULL,
                    [RequirementID] INT NOT NULL,
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
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadApplicationForms()
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            applicationFormsManager.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, RequirementID, Course, AdmitType, YearLevel, 
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
                        applicationForm.RequirementID = reader.GetInt32(6);
                        applicationForm.Course = reader.GetString(7).Trim();
                        applicationForm.AdmitType = reader.GetString(8).Trim();
                        applicationForm.YearLevel = reader.GetString(9).Trim();
                        applicationForm.SchoolYear = reader.GetString(10).Trim();
                        applicationForm.Term = reader.GetString(11).Trim();
                        applicationForm.SubmissionDate = reader.GetDateTime(12);
                        applicationForm.Status = reader.GetString(13).Trim();
                        applicationForm.IsRegular = reader.GetBoolean(14);

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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO Applications(StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, RequirementID, Course, AdmitType, YearLevel, SchoolYear," +
                " Term, SubmissionDate, Status, IsRegular) VALUES(@StudentID, @AddressID, @ContactID, @SchoolHistoryID, @GuardianID, @RequirementID, @Course, @AdmitType, @YearLevel, " +
                "@SchoolYear, @Term, @SubmissionDate, @Status, @IsRegular)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", applicationform.StudentID);
                command.Parameters.AddWithValue("@AddressID", applicationform.AddressID);
                command.Parameters.AddWithValue("@ContactID", applicationform.ContactID);
                command.Parameters.AddWithValue("@SchoolHistoryID", applicationform.SchoolHistoryID);
                command.Parameters.AddWithValue("@GuardianID", applicationform.GuardianID);
                command.Parameters.AddWithValue("@RequirementID", applicationform.RequirementID);
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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE Applications SET StudentID = @StudentID, AddressID = @AddressID, ContactID = @ContactID, SchoolHistoryID = @SchoolHistoryID" +
                ", GuardianID = @GuardianID, RequirementID = @RequirementID, Course = @Course, AdmitType = @AdmitType, YearLevel = @YearLevel, SchoolYear = @SchoolYear," +
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
                command.Parameters.AddWithValue("@RequirementID", applicationform.RequirementID);
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


        public static int getRecentApplicationID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
