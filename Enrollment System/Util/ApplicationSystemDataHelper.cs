using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class ApplicationSystemDataHelper
    {
        public static void createApplicationSubjectsTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createApplicationSchedulesTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationSchedules", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Schedules Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Schedules Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationSchedules
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [ScheduleID] INT NOT NULL,
                    [Schedule] NCHAR(30) NOT NULL,
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

        public static void createApplicationRequirementsTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationRequirements", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Requirements Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Requirements Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationRequirements
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [RequirementID] INT NOT NULL,
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

        public static void loadApplicationSubjects()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, ApplicationID, SubjectID FROM ApplicationSubjects";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm application = applicationManager.find(reader.GetInt32(1));
                        if (application == null)
                            return;
                        application.SubjectIDs.Add(reader.GetInt32(2));
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        /**
         * WARNING: loadApplications() must be called before this!
         */
        public static void loadApplicationSchedules()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, ApplicationID, SubjectID FROM ApplicationSchedules";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm application = applicationManager.find(reader.GetInt32(1));
                        if (application == null)
                            return;
                        application.ScheduleIDs.Add(reader.GetInt32(2));
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load application schedule list!");
            }
        }

        /**
         * WARNING: loadApplications() must be called before this!
         */
        public static void loadApplicationRequirements()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, ApplicationID, RequirementID FROM ApplicationRequirements";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm application = applicationManager.find(reader.GetInt32(1));
                        if (application == null)
                            return;
                        application.RequirementID = reader.GetInt32(2);
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void addApplicationSubject(ApplicationForm application)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            connection.Open();
            for (int i = 0; i < application.SubjectIDs.Count; i++)
            {
                String query = "INSERT INTO ApplicationSubjects(ApplicationID, SubjectID) VALUES(@ApplicationID, @SubjectID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@SubjectID", application.SubjectIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void addApplicationSchedule(ApplicationForm application)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO ApplicationSchedules(ApplicationID, ScheduleID) VALUES(@ApplicationID, @ScheduleID)";
            connection.Open();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@ScheduleID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void addApplicationRequirements(ApplicationForm application)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO ApplicationRequirements(ApplicationID, RequirementID) VALUES(@ApplicationID, @RequirementID)";
            connection.Open();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@RequirementID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateApplicationSubject(ApplicationForm application)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
    }
}
