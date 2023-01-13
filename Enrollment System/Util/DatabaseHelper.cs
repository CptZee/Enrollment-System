using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    /**
     * A helper class which contains all the methods regarding the datase.
     * WARNING: MUST RUN ON CHILD THREADS
     * 
     */ 
    class DatabaseHelper
    {
        //Modify depending on the computer's database. WILL ONLY WORK ON AARON's PC!
        protected static String connectionString = @"Data Source=AARON\SQLEXPRESS;Integrated Security=True";

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
        * A simple code that will create the Courses table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createCoursesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Courses", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Courses Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Courses Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Courses
                (
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Name] NCHAR(30) NOT NULL
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
         * A simple code that will create the Addresses table.
         * 
         * @return if the table is created successfully.
         * 
         */
        public static void createAdressesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Addresses", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Addresses Table exists! Proceeding...");
            }
            catch(SqlException)
            {
                Console.WriteLine("DEBUG: Addresses Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Addresses
                (
                    [Id] INT NOT NULL PRIMARY KEY,
                    [StreetUnitNumber] NCHAR(30),
                    [Street] NCHAR(30) NOT NULL,
                    [SubdivisionVillageBldg] NCHAR(30) NOT NULL,
                    [Barangay] NCHAR(30) NOT NULL,
                    [City] NCHAR(30) NOT NULL,
                    [Province] NCHAR(30) NOT NULL,
                    [ZipCode] NCHAR(30) NOT NULL
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
         * A simple code that will create the admins table.
         * 
         * @return if the table is created successfully.
         * 
         */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Username] NCHAR(30) NOT NULL,
                    [Password] NCHAR(30) NOT NULL
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
        * A simple code that will create the Contacts table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createContactTable()
        {
            SqlConnection connection = GetConnection();
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [TelephoneNo] NCHAR(30) NOT NULL,
                    [MobileNo] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL
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
        * A simple code that will create the Guardians table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createGuardianTable()
        {
            SqlConnection connection = GetConnection();
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [FirstName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [MiddleInitial] NCHAR(30) NOT NULL,
                    [SuffixName] NCHAR(30) NOT NULL,
                    [MobileNumber] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    [Occupation] NCHAR(30) NOT NULL,
                    [Relation] NCHAR(30) NOT NULL
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
        * A simple code that will create the School History table.
        * 
        * @return if the table is created successfully.
        * 
        */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Type] NCHAR(30) NOT NULL,
                    [Name] NCHAR(30) NOT NULL,
                    [ProgramTrackSpecialization] NCHAR(30) NOT NULL
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
        * A simple code that will create the Students table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createStudentsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Students Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Students Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Students
                (
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [FirstName] NCHAR(30) NOT NULL,
                    [MiddleName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [SuffixName] NCHAR(30) NOT NULL,
                    [Gender] NCHAR(30) NOT NULL,
                    [Status] NCHAR(30) NOT NULL,
                    [Citizenship] NCHAR(30) NOT NULL,
                    [BirthDate] DATE NOT NULL
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
         * A simple code that will create the Application Forms table.
         * 
         * @return if the table is created successfully.
         * 
         */
        public static void createApplicationFormTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Applications", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Applications Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Applications Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Applications
                (
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [StudentID] INT NOT NULL,
                    [AddressID] INT NOT NULL,
                    [ContactID] INT NOT NULL,
                    [SchoolHistoryID] INT NOT NULL,
                    [GuardianID] INT NOT NULL,
                    [CourseID] NCHAR(30) NOT NULL,
                    [AdmitType] NCHAR(30) NOT NULL,
                    [YearLevel] NCHAR(30) NOT NULL,
                    [SchoolYear] NCHAR(30) NOT NULL,
                    [Term] NCHAR(30) NOT NULL,
                    [SubmissionDate] DATE NOT NULL,
                    [Status] NCHAR(30) NOT NULL
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
        /*
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
        /*
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
            */
    }
}
