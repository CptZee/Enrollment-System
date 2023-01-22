using System;
using Enrollment_System.Data;
using System.Data.SqlClient;
namespace Enrollment_System.Util
{
    class GuardianHelper
    {
        public static void createGuardianTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Guardians", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Guardians Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Guardians Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Guardians
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [FirstName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [MiddleInitial] NCHAR(30),
                    [SuffixName] NCHAR(30),
                    [MobileNumber] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    [Occupation] NCHAR(30) NOT NULL,
                    [Relation] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadGuardians()
        {
            GuardianManager guardianManager = GuardianManager.getInstance();
            guardianManager.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation FROM Guardians";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guardian guardian = new Guardian();
                        guardian.ID = reader.GetInt32(0);
                        guardian.FirstName = reader.GetString(1).Trim();
                        guardian.LastName = reader.GetString(2).Trim();

                        if (!reader.IsDBNull(3))
                            guardian.MiddleInitial = reader.GetString(3).Trim();

                        if (!reader.IsDBNull(4))
                            guardian.SuffixName = reader.GetString(4).Trim();
                        guardian.MobileNumber = reader.GetString(5).Trim();
                        guardian.Email = reader.GetString(6).Trim();
                        guardian.Occupation = reader.GetString(7).Trim();
                        guardian.Relation = reader.GetString(8).Trim();

                        guardianManager.add(guardian);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load guardian list!");
            }
        }

        public static void addGuardian(Guardian guardian)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO Guardians(FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation) " +
                "VALUES(@FirstName, @LastName, @MiddleInitial, @SuffixName, @MobileNumber, @Email, @Occupation, @Relation)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", guardian.FirstName);
                command.Parameters.AddWithValue("@LastName", guardian.LastName);
                command.Parameters.AddWithValue("@MiddleInitial", guardian.MiddleInitial);
                command.Parameters.AddWithValue("@SuffixName", guardian.SuffixName);
                command.Parameters.AddWithValue("@MobileNumber", guardian.MobileNumber);
                command.Parameters.AddWithValue("@Email", guardian.Email);
                command.Parameters.AddWithValue("@Occupation", guardian.Occupation);
                command.Parameters.AddWithValue("@Relation", guardian.Relation);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeGuardian(Guardian guardian)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Guardians WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", guardian.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeGuardian(int ID)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Guardians WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateGuardian(Guardian guardian)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE Guardians SET FirstName = @FirstName, LastName = @LastName, MiddleInitial = @MiddleInitial, " +
                "SuffixName = @SuffixName, MobileNumber = @MobileNumber, Email = @Email, Occupation = @Occupation, " +
                "Relation = @Relation WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", guardian.ID);
                command.Parameters.AddWithValue("@FirstName", guardian.FirstName);
                command.Parameters.AddWithValue("@LastName", guardian.LastName);
                command.Parameters.AddWithValue("@MiddleInitial", guardian.MiddleInitial);
                command.Parameters.AddWithValue("@SuffixName", guardian.SuffixName);
                command.Parameters.AddWithValue("@MobileNumber", guardian.MobileNumber);
                command.Parameters.AddWithValue("@Email", guardian.Email);
                command.Parameters.AddWithValue("@Occupation", guardian.Occupation);
                command.Parameters.AddWithValue("@Relation", guardian.Relation);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentGuardianID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT IDENT_CURRENT ('Guardians')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
