using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class DatabaseHelper
    {
        //Modify depending on the computer's database. WILL ONLY WORK ON AARON's PC!
        protected static String connectionString = @"Data Source=AARON\SQLEXPRESS;Initial Catalog=EDP;Integrated Security=True";

        /*
         * A simple method which returns the connection.
         * 
        **/
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        /**
         * A simple code that will create the users table.
         * NOTE: DO NOT RUN ON THE MAIN THREAD!
         * 
         * @return if the table is created successfully.
         * 
         */
        public static void createUserTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Table exists! Proceeding...");
            }
            catch(SqlException)
            {
                Console.WriteLine("DEBUG: Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Users
                (
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [FName] NCHAR(30) NOT NULL,
                    [MName] NCHAR(30),
                    [LName] NCHAR(30) NOT NULL,
                    [Age] INT NOT NULL,
                    [Gender] NCHAR(30) NOT NULL,
                    [Municipality] NCHAR(30) NOT NULL,
                    [City] NCHAR(30) NOT NULL,
                    [PostalCode] NCHAR(30) NOT NULL,
                    [ContactNumber] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    [StudNo] NCHAR(30),
                    [Program] NCHAR(30),
                    [YearLvl] NCHAR(30),
                    [Semester] NCHAR(30),
                    [IsRegular] BIT,
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

        /**
         * A simple code that will return the users table
         * NOTE: DO NOT RUN ON THE MAIN THREAD!
         * 
         */

        public static void getUsers()
        {
            UserManager userManager = UserManager.Instance;
            SqlConnection connection = GetConnection();
            String query = @"SELECT Id, FName, MName, LName, Age, Gender, Municipality, City, PostalCode, 
                                ContactNumber, Email, StudNo, Program, YearLvl, Semester, IsRegular FROM Users";
            try {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Check if the user has a student no. which is required to become a student,
                        //if so, it will create an instance of Student and if not, a simple User.
                        User user;
                        if (reader.GetValue(11) == null)
                            user = new User();
                        else
                        {
                            user = new Student
                            {
                                StudNo = reader.GetString(11),
                                Program = reader.GetString(12),
                                YearLvl = reader.GetString(13),
                                Semester = reader.GetString(14),
                                isRegular = reader.GetBoolean(15)
                            };
                        }
                        user.Id = reader.GetInt32(0);
                        user.FName = reader.GetString(1);
                        user.MName = reader.GetString(2);
                        user.LName = reader.GetString(3);
                        user.Age = reader.GetInt32(4);
                        user.Gender = reader.GetString(5);
                        user.Municipality = reader.GetString(6);
                        user.City = reader.GetString(7);
                        user.PostalCode = reader.GetString(8);
                        user.ContactNumber = reader.GetString(9);
                        user.Email = reader.GetString(10);

                        userManager.addUser(user);
                    }
                }

                connection.Close();
                Console.WriteLine("DEBUG: User list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load user list!");
            }
        }

        /**
        * A simple code that will add a user to the database
        * NOTE: DO NOT RUN ON THE MAIN THREAD!
        * 
        */
        public static void addUser(Student user)
        {
            UserManager userManager = UserManager.Instance;
            SqlConnection connection = GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "INSERT INTO Users * VALUES(" + user.Id + ",'" + user.FName + "','" + user.MName + "','" + user.LName + "'," +
                user.Age + ",'" + user.Gender + "','" + user.Municipality + "','" + user.City + "','" + user.PostalCode + "','" + user.ContactNumber + "','" + 
                user.Email + "','" + user.StudNo + "','" + user.Program + "','" + user.YearLvl + "','" + user.Semester + "'," + user.isRegular + ")";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                adapter.InsertCommand = new SqlCommand(query, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                userManager.addUser(user);
                Console.WriteLine("DEBUG: User " + user.Id + " added to the database.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add user with the id " + user.Id);
            }
        }
    }
}
