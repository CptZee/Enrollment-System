using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class SchoolHistoryHelper
    {
        public static void createSchoolHistoryTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM SchoolHistory", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: SchoolHistory Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: SchoolHistory Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE SchoolHistory
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [Type] NCHAR(30) NOT NULL,
                    [Name] NCHAR(30) NOT NULL,
                    [ProgramTrackSpecialization] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadSchoolHistory()
        {
            SchoolHistoryManager schoolHistories = SchoolHistoryManager.getInstance();
            schoolHistories.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, Type, Name, ProgramTrackSpecialization FROM SchoolHistory";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SchoolHistory schoolHistory = new SchoolHistory();
                        schoolHistory.ID = reader.GetInt32(0);
                        schoolHistory.Type = reader.GetString(1).Trim();
                        schoolHistory.Name = reader.GetString(2).Trim();
                        schoolHistory.ProgramTrackSpecialization = reader.GetString(3).Trim();

                        schoolHistories.add(schoolHistory);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load school history list!");
            }
        }

        public static void addSchoolHistory(SchoolHistory schoolhistory)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO SchoolHistory(Type, Name, ProgramTrackSpecialization) VALUES(@Type, @Name, @ProgramTrackSpecialization)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Type", schoolhistory.Type);
                command.Parameters.AddWithValue("@Name", schoolhistory.Name);
                command.Parameters.AddWithValue("@ProgramTrackSpecialization", schoolhistory.ProgramTrackSpecialization);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeSchoolHistory(SchoolHistory schoolHistory)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM SchoolHistory WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schoolHistory.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeSchoolHistory(int ID)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM SchoolHistory WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSchoolHistory(SchoolHistory schoolhistory)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE SchoolHistory SET Type = @Type, Name = @Name, ProgramTrackSpecialization = @ProgramTrackSpecialization WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schoolhistory.ID);
                command.Parameters.AddWithValue("@Type", schoolhistory.Type);
                command.Parameters.AddWithValue("@Name", schoolhistory.Name);
                command.Parameters.AddWithValue("@ProgramTrackSpecialization", schoolhistory.ProgramTrackSpecialization);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentSchoolHistoryID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT IDENT_CURRENT ('SchoolHistory')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
