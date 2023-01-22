using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class AddressHelper
    {
        public static void createAdressesTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Addresses", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Addresses Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Addresses Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Addresses
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [StreetUnitNumber] NCHAR(30),
                    [Street] NCHAR(30),
                    [SubdivisionVillageBldg] NCHAR(30),
                    [Barangay] NCHAR(30) NOT NULL,
                    [City] NCHAR(30) NOT NULL,
                    [Province] NCHAR(30) NOT NULL,
                    [ZipCode] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadAddresses()
        {
            AddressManager addressManager = AddressManager.getInstance();
            addressManager.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT ID, StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode FROM Addresses";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Address address = new Address();

                        address.ID = reader.GetInt32(0);

                        if (!reader.IsDBNull(1))
                            address.StreetUnitNumber = reader.GetString(1).Trim();

                        if (!reader.IsDBNull(2))
                            address.Street = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            address.SubdivisionVillageBldg = reader.GetString(3).Trim();
                        address.Barangay = reader.GetString(4).Trim();
                        address.City = reader.GetString(5).Trim();
                        address.Province = reader.GetString(6).Trim();
                        address.ZipCode = reader.GetString(7).Trim();

                        addressManager.add(address);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load address list!");
            }
        }

        public static void addAddress(Address address)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "INSERT INTO Addresses(StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode) VALUES(" +
                "@StreetUnitNumber, @Street, @SubdivisionVillageBldg, @Barangay, @City, @Province, @ZipCode)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StreetUnitNumber", address.StreetUnitNumber);
                command.Parameters.AddWithValue("@Street", address.Street);
                command.Parameters.AddWithValue("@SubdivisionVillageBldg", address.SubdivisionVillageBldg);
                command.Parameters.AddWithValue("@Barangay", address.Barangay);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@Province", address.Province);
                command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAddress(Address address)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Addresses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", address.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAddress(int ID)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Addresses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateAddress(Address address)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE Addresses SET StreetUnitNumber = @StreetUnitNumber, Street = @Street, SubdivisionVillageBldg = @SubdivisionVillageBldg" +
                ", Barangay = @Barangay, City = @City, Province = @Province, ZipCode = @ZipCode WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", address.ID);
                command.Parameters.AddWithValue("@StreetUnitNumber", address.StreetUnitNumber);
                command.Parameters.AddWithValue("@Street", address.Street);
                command.Parameters.AddWithValue("@SubdivisionVillageBldg", address.SubdivisionVillageBldg);
                command.Parameters.AddWithValue("@Barangay", address.Barangay);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@Province", address.Province);
                command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static int getRecentAddressID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT IDENT_CURRENT ('Addresses')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
