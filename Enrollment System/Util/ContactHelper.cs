using System;
using Enrollment_System.Data;
using System.Data.SqlClient;
namespace Enrollment_System.Util
{
    class ContactHelper
    {
        public static void createContactTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Contacts", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Contacts Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Contacts Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Contacts
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [TelephoneNo] NCHAR(30),
                    [MobileNo] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadContacts()
        {
            ContactManager contactManager = ContactManager.getInstance();
            contactManager.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, TelephoneNo, MobileNo, Email FROM Contacts";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();

                        contact.ID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            contact.TelephoneNo = reader.GetString(1).Trim();
                        contact.MobileNo = reader.GetString(2).Trim();
                        contact.Email = reader.GetString(3).Trim();

                        contactManager.add(contact);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load contact list!");
            }
        }

        public static void addContact(Contact contact)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO Contacts(TelephoneNo, MobileNo, Email) VALUES(@TelephoneNo, @MobileNo, @Email)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TelephoneNo", contact.TelephoneNo);
                command.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeContact(Contact contact)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Contacts WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", contact.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeContact(int ID)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Contacts WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateContact(Contact contact)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE Contacts SET TelephoneNo = @TelephoneNo, MobileNo = @MobileNo, Email = @Email WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", contact.ID);
                command.Parameters.AddWithValue("@TelephoneNo", contact.TelephoneNo);
                command.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentContactID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT IDENT_CURRENT ('Contacts')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }


    }
}
