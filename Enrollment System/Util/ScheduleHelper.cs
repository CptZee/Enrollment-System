using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class ScheduleHelper
    {
        public static void createSchedulesTable()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Schedules", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Schedules Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Schedules Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Schedules
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [SubjectID] INT NOT NULL,
                    [StartTime] NCHAR(30) NOT NULL,
                    [EndTime] NCHAR(30) NOT NULL,
                    [Day] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadSchedules()
        {
            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            scheduleManager.clear();
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = @"SELECT ID, SubjectID, StartTime, EndTime, Day FROM Schedules";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule();
                        schedule.ID = reader.GetInt32(0);
                        schedule.SubjectID = reader.GetInt32(1);
                        schedule.StartTime = reader.GetString(2).Trim();
                        schedule.EndTime = reader.GetString(3).Trim();
                        schedule.Day = reader.GetString(4).Trim();

                        scheduleManager.add(schedule);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load schedule list!");
            }
        }


        public static void addSchedule(Schedule schedule)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "INSERT INTO Schedules(SubjectID, StartTime, EndTime, Day) VALUES(@SubjectID, @StartTime, @EndTime, @Day)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SubjectID", schedule.SubjectID);
                command.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                command.Parameters.AddWithValue("@EndTime", schedule.EndTime);
                command.Parameters.AddWithValue("@Day", schedule.Day);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }


        public static void removeSchedule(Schedule schedule)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "DELETE FROM Schedules WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schedule.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSchedule(Schedule schedule)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "UPDATE Schedules SET SubjectID = @SubjectID, StartTime = @StartTime, EndTime = @EndTime, Day = @Day WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schedule.ID);
                command.Parameters.AddWithValue("@SubjectID", schedule.SubjectID);
                command.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                command.Parameters.AddWithValue("@EndTime", schedule.EndTime);
                command.Parameters.AddWithValue("@Day", schedule.Day);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentSchedulesID()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = @"SELECT IDENT_CURRENT ('Schedules')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
