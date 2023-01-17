using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{

    class SchoolHistoryHelper
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
        public static void createSchoolHistoryTable()
        {
            SqlConnection connection = GetConnection();
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
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [Type] NCHAR(30) NOT NULL,
                    [Name] NCHAR(30) NOT NULL,
                    [ProgramTrackSpecialization] NCHAR(30) NOT NULL,
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

        public static void loadSchoolHistory()
        {
            SchoolHistoryManager schoolHistories = SchoolHistoryManager.getInstance();
            schoolHistories.clear();
            SqlConnection connection = GetConnection();
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

        public static void addSchoolHistory(SchoolHistoryHelper schoolhistory)
        {
            SqlConnection connection = GetConnection();
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

        public static void removeSchoolHistory(SchoolHistoryHelper schoolHistory)
        {
            SqlConnection connection = GetConnection();
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
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM SchoolHistory WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSchoolHistory(SchoolHistoryHelper schoolhistory)
        {
            SqlConnection connection = GetConnection();
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
            SqlConnection connection = GetConnection();
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
