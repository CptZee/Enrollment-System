using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{
    class RequirementsHelper
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
        public static void createRequirementsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Requirements", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Requirements Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Requirements Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Requirements
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [PicturePath] NCHAR(255) NOT NULL,
                    [PSAPath] NCHAR(255) NOT NULL,
                    [GoodMoralPath] NCHAR(255) NOT NULL,
                    [RecommendationPath] NCHAR(255) NOT NULL,
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

        public static void loadRequirements()
        {
            RequirementManager requirementManager = RequirementManager.getInstance();
            requirementManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, PicturePath, PSAPath, GoodMoralPath, RecommendationPath FROM Requirements";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Requirement requirement = new Requirement();

                        requirement.ID = reader.GetInt32(0);

                        if (!reader.IsDBNull(1))
                            requirement.PicturePath = reader.GetString(1).Trim();

                        if (!reader.IsDBNull(2))
                            requirement.PSAPath = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            requirement.GoodMoralPath = reader.GetString(3).Trim();

                        if (!reader.IsDBNull(4))
                            requirement.RecommendationPath = reader.GetString(3).Trim();

                        requirementManager.add(requirement);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load requirement list!");
            }
        }

        public static void addRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Requirements(PicturePath, PSAPath, GoodMoralPath, RecommendationPath) VALUES(@PicturePath, " +
                "@PSAPath, @GoodMoralPath, @RecommendationPath)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PicturePath", requirement.PicturePath);
                command.Parameters.AddWithValue("@PSAPath", requirement.PSAPath);
                command.Parameters.AddWithValue("@GoodMoralPath", requirement.GoodMoralPath);
                command.Parameters.AddWithValue("@RecommendationPath", requirement.RecommendationPath);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }


        public static void removeRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Requirement WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", requirement.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeRequirement(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Requirement WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Requirements SET PicturePath = @PicturePath, PSAPath = @PSAPath, GoodMoralPath = @GoodMoralPath, " +
                "RecommendationPath = @RecommendationPath WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", requirement.ID);
                command.Parameters.AddWithValue("@PicturePath", requirement.PicturePath);
                command.Parameters.AddWithValue("@PSAPath", requirement.PSAPath);
                command.Parameters.AddWithValue("@GoodMoralPath", requirement.GoodMoralPath);
                command.Parameters.AddWithValue("@RecommendationPath", requirement.RecommendationPath);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }


        public static int getRecentRequirementID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Requirements')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }


    }
}
