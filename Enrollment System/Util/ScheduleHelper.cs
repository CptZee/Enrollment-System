using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{
    class Schedule
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
        public static void createSchedulesTable()
        {
            SqlConnection connection = GetConnection();
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

        public static DataSet getSchedules()
        {

            String select = "SELECT * FROM Schedules";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static void loadSchedules()
        {
            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            scheduleManager.clear();
            SqlConnection connection = GetConnection();
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
            SqlConnection connection = GetConnection();
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
            SqlConnection connection = GetConnection();
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
            SqlConnection connection = GetConnection();
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

        public static int getRecentScheduleID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Schedules')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentSchedulesID()
        {
            SqlConnection connection = GetConnection();
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
