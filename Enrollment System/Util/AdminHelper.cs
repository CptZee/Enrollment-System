using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{
    class AdminHelper
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
        public static void createAdminTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Admins", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Admins Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Admins Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Admins
                (
                    [ID] INT NOT NULL IDENTITY(1,1), 
                    [Username] NCHAR(30) NOT NULL,
                    [Password] NCHAR(30) NOT NULL,
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

        public static void loadAdmins()
        {
            AdminManager adminManager = AdminManager.getInstance();
            adminManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Username, Password FROM Admins";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Admin admin = new Admin();
                        admin.ID = reader.GetInt32(0);
                        admin.Username = reader.GetString(1).Trim();
                        admin.Password = reader.GetString(2).Trim();

                        adminManager.add(admin);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load admin list!");
            }
        }

        public static void addAdmin(AdminHelper admin)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Admins(username, password) VALUES(@username, @password)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", admin.Username);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAdmin(AdminHelper admin)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Admins WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", admin.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAdmin(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Admins WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateAdmin(AdminHelper admin)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Admins SET username = @username, password = @password WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", admin.ID);
                command.Parameters.AddWithValue("@username", admin.Username);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentAdminID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Admins')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
